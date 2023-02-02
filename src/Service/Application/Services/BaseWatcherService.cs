using Microsoft.Extensions.Hosting;
using Service.Domain.Entities;
using Service.Domain.Models;

namespace Service.Application.Services;
internal class BaseWatcherService : BackgroundService
{
    protected static readonly List<RequestModel> Requests = new(AppOptionsStatic.ListLogsLength);
    protected static readonly List<ResponseModel> Responses = new(AppOptionsStatic.ListLogsLength);
    protected static readonly List<ExceptionModel> Exceptions = new(AppOptionsStatic.ListLogsLength);
    protected static readonly List<LoggerModel> Logs = new(AppOptionsStatic.ListLogsLength);

    internal static void AddResquest(RequestModel data) => Requests.Add(data);
    internal static void AddResponse(ResponseModel data) => Responses.Add(data);
    internal static void AddException(ExceptionModel data) => Exceptions.Add(data);
    internal static void AddLog(LoggerModel data) => Logs.Add(data);
    protected override Task ExecuteAsync(CancellationToken stoppingToken) { return Task.CompletedTask; }
}
