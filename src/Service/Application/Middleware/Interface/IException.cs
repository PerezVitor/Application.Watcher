using Service.Domain.Entities;

namespace Service.Application.Middleware.Interface;
public interface IException
{
    Task Log(Guid id, RequestModel request, Exception exception);
}