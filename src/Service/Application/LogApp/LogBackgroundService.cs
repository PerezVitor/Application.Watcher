using Microsoft.Extensions.Hosting;
using Service.Application.LogApp;
using Service.Domain.Entities;

namespace Service.Application.Log;
internal class LogBackgroundService : BackgroundService
{
    private static readonly List<RequestModel> Requests = new();
    private static readonly List<ResponseModel> Responses = new();
    private static readonly List<ExceptionModel> Exceptions = new();
    private static readonly List<LoggerModel> Logs = new();
    //private readonly LogDbProcess _logDbProcess;

    //public LogBackgroundService(LogDbProcess logDbProcess) => _logDbProcess = logDbProcess;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine("Iniciando o Background Service");
        while (!stoppingToken.IsCancellationRequested)
        {
            LogDbProcess _logDbProcess = new();
            Task.WaitAll(new Task[] {
                _logDbProcess.Process(Requests),
                _logDbProcess.Process(Responses),
                _logDbProcess.Process(Exceptions),
                _logDbProcess.Process(Logs)
            }, cancellationToken: stoppingToken);

            _logDbProcess.SaveChanges();
            await Task.Delay(5000, stoppingToken);
        }
    }

    internal static void AddResquest(RequestModel data) => Requests.Add(data);
    internal static void AddResponse(ResponseModel data) => Responses.Add(data);
    internal static void AddException(ExceptionModel data) => Exceptions.Add(data);
    internal static void AddLog(LoggerModel data) => Logs.Add(data);
}