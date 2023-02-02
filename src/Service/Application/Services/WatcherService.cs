using MediatR;
using Service.Application.Commands;
using Service.Domain.Models;

namespace Service.Application.Services;
internal class WatcherService : BaseWatcherService
{
    private readonly IMediator _mediator;
    public WatcherService(IMediator mediator) => _mediator = mediator;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine("Iniciando o Background Service");
        while (!stoppingToken.IsCancellationRequested)
        {
            await ProcessExceptions();
            await ProcessLogs();
            await ProcessRequests();
            await ProcessResponses();

            await Task.Delay(AppOptionsStatic.BackgroundServiceTimer, stoppingToken);
        }
    }

    #region Service Process Methods
    private async Task ProcessResponses()
    {
        if (!Responses.Any())
            return;

        Responses.RemoveAll(row => row.IsExecuted);
        await Process(new ResponseCommand(Responses.Take(AppOptionsStatic.ListLogInsertLength).ToList()));
    }

    private async Task ProcessRequests()
    {
        if (!Requests.Any())
            return;

        Requests.RemoveAll(row => row.IsExecuted);
        await Process(new RequestCommand(Requests.Take(AppOptionsStatic.ListLogInsertLength).ToList()));
    }

    private async Task ProcessLogs()
    {
        if (!Logs.Any())
            return;

        Logs.RemoveAll(row => row.IsExecuted);
        await Process(new LoggerCommand(Logs.Take(AppOptionsStatic.ListLogInsertLength).ToList()));
    }

    
    private async Task ProcessExceptions()
    {
        if (!Exceptions.Any())
            return;

        Exceptions.RemoveAll(row => row.IsExecuted);
        await Process(new ExceptionCommand(Exceptions.Take(AppOptionsStatic.ListLogInsertLength).ToList()));
    }

    internal async Task Process<T>(T handlerModel) => await _mediator.Send(handlerModel);
    #endregion
}