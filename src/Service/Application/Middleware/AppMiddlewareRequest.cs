using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.IO;
using Service.Application.Middleware.Interface;
using Service.Application.Services;
using Service.Domain.Entities;

namespace Service.Application.Middleware;
public class AppMiddlewareRequest : IRequest
{
    private readonly IMapper _mapper;
    public AppMiddlewareRequest(IMapper mapper) => _mapper = mapper;

    public async Task<RequestModel> Log(Guid id, HttpContext context, RecyclableMemoryStreamManager recyclableMemoryStreamManager)
    {
        RequestModel _requestModel = new();
        _requestModel = GetRequestModel(_requestModel, id, context.Request);

        if (context.Request.ContentLength > 1)
        {
            var requestBody = await GetBody(context.Request, recyclableMemoryStreamManager);
            _mapper.Map(requestBody, _requestModel.RequestBody);
            context.Request.Body.Position = 0;
        }

        WatcherService.AddResquest(_requestModel);
        return _requestModel;
    }

    public static async Task<string> GetBody(HttpRequest request, RecyclableMemoryStreamManager recyclableMemoryStreamManager)
    {
        request.EnableBuffering();
        await using var requestStream = recyclableMemoryStreamManager.GetStream();
        await request.Body.CopyToAsync(requestStream);
        return ReadStreamInChunks(requestStream);
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

    private RequestModel GetRequestModel(RequestModel _requestModel, Guid id, HttpRequest request)
    {
        _mapper.Map(request, _requestModel);
        _requestModel.CycleId = id;

        return _requestModel;
    }
}
