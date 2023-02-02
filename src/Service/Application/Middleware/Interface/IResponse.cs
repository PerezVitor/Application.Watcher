using Microsoft.AspNetCore.Http;
using Microsoft.IO;

namespace Service.Application.Middleware.Interface;
public interface IResponse
{
    Task Run(Guid id, RequestDelegate next, HttpContext context, RecyclableMemoryStreamManager recyclableMemoryStreamManager);
}