using Microsoft.AspNetCore.Http;
using Microsoft.IO;
using Service.Application.Extensions;
using Service.Application.Middleware.Interface;
using Service.Application.Services;
using Service.Domain.Entities;

namespace Service.Application.Middleware;
public class AppMiddlewareResponse : IResponse
{
    public async Task Log(Guid id, RequestDelegate next, HttpContext context, RecyclableMemoryStreamManager recyclableMemoryStreamManager)
    {
        ResponseModel _responseModel = new();
        using (var originalBodyStream = context.Response.Body)
        {
            try
            {
                using (var originalResponseBody = recyclableMemoryStreamManager.GetStream())
                {
                    context.Response.Body = originalResponseBody;
                    await next(context);
                    context.Response.Body.Seek(0, SeekOrigin.Begin);
                    string responseBody = await new StreamReader(context.Response.Body).ReadToEndAsync();
                    context.Response.Body.Seek(0, SeekOrigin.Begin);

                    _responseModel.ResponseBody = responseBody;
                    await originalResponseBody.CopyToAsync(originalBodyStream);
                }
            }
            catch (OutOfMemoryException)
            {
                _responseModel.ResponseBody = "OutOfMemoryException occured while trying to read response body";
            }
            finally
            {
                _responseModel.CycleId = id;
                _responseModel.ResponseStatus = context.Response.StatusCode;
                _responseModel.Headers = context.Response.GetContentOrEmpty();

                WatcherService.AddResponse(_responseModel);
                context.Response.Body = originalBodyStream;
            }
        }
    }
}
