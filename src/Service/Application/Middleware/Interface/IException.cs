using Service.Domain.Entities;

namespace Service.Application.Middleware.Interface;
public interface IException
{
    Task Run(Guid id, RequestModel request, Exception exception);
}