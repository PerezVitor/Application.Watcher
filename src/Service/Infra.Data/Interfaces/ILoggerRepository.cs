using Service.Domain.Entities;

namespace Service.Infra.Data.Interfaces;
internal interface ILoggerRepository
{
    Task Save(List<LoggerModel> log);
}
