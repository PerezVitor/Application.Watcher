using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.IO;
using Service.Application.Extensions;
using Service.Application.Middleware.Interface;
using Service.Application.Services;
using Service.Domain.Entities;

namespace Service.Application.Middleware;
public class AppMiddlewareRequest : IRequest
{
    private readonly IMapper _mapper;
    public AppMiddlewareRequest(IMapper mapper) => _mapper = mapper;

    public async Task<RequestModel> Run(Guid id, HttpContext context, RecyclableMemoryStreamManager recyclableMemoryStreamManager)
    {
        RequestModel _requestModel = new();
        _requestModel = GetRequestModel(_requestModel, id, context);

        await GetRequestBody(_requestModel, context, recyclableMemoryStreamManager);
        
        WatcherService.AddResquest(_requestModel);
        return _requestModel;
    }

    private async Task GetRequestBody(RequestModel requestModel, HttpContext context, RecyclableMemoryStreamManager recyclableMemoryStreamManager)
    {
        if (context.Request.ContentLength > 1)
        {
            requestModel.RequestBody = await GetBody(context.Request, recyclableMemoryStreamManager);
            context.Request.Body.Position = 0;
        }
    }

    public static async Task<string> GetBody(HttpRequest request, RecyclableMemoryStreamManager recyclableMemoryStreamManager)
    {
        request.EnableBuffering();
        await using (var requestStream = recyclableMemoryStreamManager.GetStream())
        {
            await request.Body.CopyToAsync(requestStream);
            return ReadStreamInChunks(requestStream);
        }
    }

    public static string ReadStreamInChunks(Stream stream)
    {
        const int readChunkBufferLength = 4096;
        stream.Seek(0, SeekOrigin.Begin);
        using var textWriter = new StringWriter();
        using var reader = new StreamReader(stream);
        var readChunk = new char[readChunkBufferLength];
        int readChunkLength;

        do
        {
            readChunkLength = reader.ReadBlock(readChunk, 0, readChunkBufferLength);
            textWriter.Write(readChunk, 0, readChunkLength);
        } while (readChunkLength > 0);

        return textWriter.ToString();
    }

    private RequestModel GetRequestModel(RequestModel _requestModel, Guid id, HttpContext context)
    {
        _mapper.Map(context.Request, _requestModel);
        _requestModel.CycleId = id;
        _requestModel.Headers = context.Request.GetContentOrEmpty();
        _requestModel.IpAddress = context.Connection.RemoteIpAddress.ToString();

        return _requestModel;
    }
}
