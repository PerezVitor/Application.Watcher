using Microsoft.AspNetCore.Http;
using Microsoft.IO;
using Service.Application.Middleware.Interface;
using Service.Domain;
using Service.Domain.Entities;

namespace Service.Application.Middleware;
internal class AppMiddleware
{
    protected readonly RecyclableMemoryStreamManager _recyclableMemoryStreamManager;
    protected readonly RequestDelegate _next;
    private readonly IRequest _requestLog;
    private readonly IResponse _responseLog;
    private readonly IException _exceptionLog;

    public AppMiddleware(
        RequestDelegate next,
        IRequest requestLog,
        IResponse responseLog,
        IException exceptionLog
    )
    {
        _recyclableMemoryStreamManager = new RecyclableMemoryStreamManager();
        _next = next;
        _requestLog = requestLog;
        _responseLog = responseLog;
        _exceptionLog = exceptionLog;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        Guid id = Guid.NewGuid();
        RequestModel _requestModel = null;

        try
        {
            _requestModel = await _requestLog.Log(id, context, _recyclableMemoryStreamManager);
            await _responseLog.Log(id, _next, context, _recyclableMemoryStreamManager);
        }
        catch (Exception ex)
        {
            await _exceptionLog.Log(id, _requestModel, ex);
            throw;
        }
    }
}
