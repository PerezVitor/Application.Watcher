using MediatR;
using Service.Application.Commands;
using Service.Infra.Data.Interfaces;

namespace Service.Domain.Entities;
internal class LoggerHandler : IRequestHandler<LoggerCommand>
{
    private readonly ILoggerRepository _loggerRepository;
    public LoggerHandler(ILoggerRepository loggerRepository) => _loggerRepository = loggerRepository;

    public async Task<Unit> Handle(LoggerCommand log, CancellationToken cancellationToken)
    {
        await _loggerRepository.Save(log.GetData());
        log.SetExecuted();
        return Unit.Value;
    }
}
