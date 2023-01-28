using Microsoft.Extensions.Hosting;
using Service.Domain.Entities;
using Service.Domain.Interfaces;

namespace Service.Application;
public class TimerBackgroundService : BackgroundService
{
    private static readonly List<RequestModel> Requests = new();
    private static readonly List<ResponseModel> Responses = new();
    private static readonly List<ExceptionModel> Exceptions = new();
    private static readonly List<LoggerModel> Logs = new();

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine("Iniciando o Background Service");
        while (!stoppingToken.IsCancellationRequested)
        {
            Task.WaitAll(new Task[] {
                Process(Requests),
                Process(Responses),
                Process(Exceptions),
                Process(Logs)
            }, cancellationToken: stoppingToken);

            await Task.Delay(5000, stoppingToken);
        }
    }

    private static Task Process<T>(List<T> list) where T : class, IProcessamento
    {
        if (list.Any())
        {
            list.RemoveAll(row => row.IsExecuted);
            foreach (var item in list)
            {
                item.InsertLog();
                item.SetExecuted();
            }
        }

        return Task.CompletedTask;
    }

    public static void AddResquest(RequestModel data) => Requests.Add(data);
    public static void AddResponse(ResponseModel data) => Responses.Add(data);
    public static void AddException(ExceptionModel data) => Exceptions.Add(data);
    public static void AddLog(LoggerModel data) => Logs.Add(data);
}