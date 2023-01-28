using Service.Application.DTO;

namespace Service.Application.Middleware.Interface;
public interface ILog
{
    Task Log(LogDto log);
}
