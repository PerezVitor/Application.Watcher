using Microsoft.AspNetCore.Http;
using Microsoft.IO;
using Service.Domain.Entities;

namespace Service.Application.Middleware.Interface;
public interface IRequest
{
    Task<RequestModel> Log(Guid id, HttpContext context, RecyclableMemoryStreamManager recyclableMemoryStreamManager);
}