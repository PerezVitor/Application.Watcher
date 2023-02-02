using MediatR;
using Microsoft.Extensions.Hosting;
using Service.Application.Commands;
using Service.Domain.Entities;

namespace Service.Application.Services;
internal class WatcherService : BackgroundService
{
    private static readonly List<RequestModel> Requests = new(10000);
    private static readonly List<ResponseModel> Responses = new(10000);
    private static readonly List<ExceptionModel> Exceptions = new(10000);
    private static readonly List<LoggerModel> Logs = new(10000);
    private readonly IMediator _mediator;
    public WatcherService(IMediator mediator) => _mediator = mediator;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine("Iniciando o Background Service");
        while (!stoppingToken.IsCancellationRequested)
        {
            if (Exceptions.Any())
            {
                Exceptions.RemoveAll(row => row.IsExecuted);
                await Process(new ExceptionCommand(Exceptions.Take(1000).ToList()));
            }

            if (Responses.Any())
            {
                Responses.RemoveAll(row => row.IsExecuted);
                await Process(new ResponseCommand(Responses.Take(1000).ToList()));
            }

            if (Requests.Any())
            {
                Requests.RemoveAll(row => row.IsExecuted);
                await Process(new RequestCommand(Requests.Take(1000).ToList()));
            }

            if (Logs.Any())
            {
                Logs.RemoveAll(row => row.IsExecuted);
                await Process(new LoggerCommand(Logs.Take(1000).ToList()));
            }

            await Task.Delay(10000, stoppingToken);
        }
    }

    internal async Task Process<T>(T handlerModel) => await _mediator.Send(handlerModel);
    internal static void AddResquest(RequestModel data) => Requests.Add(data);
    internal static void AddResponse(ResponseModel data) => Responses.Add(data);
    internal static void AddException(ExceptionModel data) => Exceptions.Add(data);
    internal static void AddLog(LoggerModel data) => Logs.Add(data);
}