using Service.Domain.Entities;

namespace Service.Application.Commands;
internal class LoggerCommand : BaseCommand<LoggerModel>
{
    public LoggerCommand(List<LoggerModel> logs) : base(logs) { }
}
