using Microsoft.AspNetCore.Http;
using Microsoft.IO;
using Service.Application.Extensions;
using Service.Domain.Entities;

namespace Service.Application;
public class AppMiddleware
{
    private static RequestModel? RequestLog { get; set; }
    private readonly RequestDelegate _next;
    private readonly RecyclableMemoryStreamManager _recyclableMemoryStreamManager;

    public AppMiddleware(RequestDelegate next)
    {
        _next = next;
        _recyclableMemoryStreamManager = new RecyclableMemoryStreamManager();
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await LogRequest(context);
            await LogResponse(context);
        }
        catch (Exception ex)
        {
            LogException(ex);
            throw;
        }
    }

    public static void LogException(Exception ex)
    {
        var ExceptionLog = new ExceptionModel
        {
            EncounteredAt = DateTime.Now,
            Message = ex.Message,
            StackTrace = ex.StackTrace,
            Source = ex.Source,
            TypeOf = ex.GetType().ToString(),
            Path = RequestLog?.Path,
            Method = RequestLog?.Method,
            QueryString = RequestLog?.QueryString,
            RequestBody = RequestLog?.RequestBody
        };

        TimerBackgroundService.AddException(ExceptionLog);
    }

    private async Task LogRequest(HttpContext context)
    {
        var requestBodyDto = GetRequestModel(context.Request);

        if (context.Request.ContentLength > 1)
        {
            requestBodyDto.RequestBody = await GetBody(context.Request);
            context.Request.Body.Position = 0;
        }

        RequestLog = requestBodyDto;
        TimerBackgroundService.AddResquest(RequestLog);
    }

    private static RequestModel GetRequestModel(HttpRequest request)
    {
        return new RequestModel()
        {
            RequestBody = string.Empty,
            Host = request.Host.ToString(),
            Path = request.Path.ToString(),
            Method = request.Method.ToString(),
            QueryString = request.QueryString.ToString(),
            StartTime = DateTime.Now,
            Headers = request.GetContentOrEmpty()
        };
    }

    public async Task<string> GetBody(HttpRequest request)
    {
        request.EnableBuffering();
        await using var requestStream = _recyclableMemoryStreamManager.GetStream();
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

    private async Task LogResponse(HttpContext context)
    {
        using var originalBodyStream = context.Response.Body;
        ResponseModel response = new();
        try
        {
            using var originalResponseBody = _recyclableMemoryStreamManager.GetStream();

            context.Response.Body = originalResponseBody;
            await _next(context);
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var responseBody = await new StreamReader(context.Response.Body).ReadToEndAsync();
            context.Response.Body.Seek(0, SeekOrigin.Begin);

            response = new ResponseModel
            {
                ResponseBody = responseBody,
                ResponseStatus = context.Response.StatusCode,
                FinishTime = DateTime.Now,
                Headers = context.Response.GetContentOrEmpty()
            };

            await originalResponseBody.CopyToAsync(originalBodyStream);
        }
        catch (OutOfMemoryException)
        {
            response = new ResponseModel
            {
                ResponseBody = "OutOfMemoryException occured while trying to read response body",
                ResponseStatus = context.Response.StatusCode,
                FinishTime = DateTime.Now,
                Headers = context.Response.GetContentOrEmpty()
            };
        }
        finally
        {
            TimerBackgroundService.AddResponse(response);
            context.Response.Body = originalBodyStream;
        }
    }
}
