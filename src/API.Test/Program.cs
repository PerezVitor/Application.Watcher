using Service;
using Service.Application.Log.Inteface;

#region Services
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAppWatcherServices(opt =>
{
    opt.ConnectionString = builder.Configuration.GetConnectionString("AppWatcher");
    opt.ApplicationName = "API.Test";
});
#endregion

#region App
var app = builder.Build();
MapEndpoints(app);
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseRouting();
app.AddWatcher();
app.Run();
#endregion

static void MapEndpoints(WebApplication app)
{
    app.MapGet("request-response", () => {});
    app.MapGet("request-response-with-query-string", (string text) => { });
    app.MapPost("exception", (AppData app) => { throw new Exception("New Exception thrown"); });
    app.MapDelete("log-error", (ILoggerService _logger) => { AppLog.LogError(_logger); });
    app.MapPut("log-warning", (ILoggerService _logger) => { AppLog.LogWarning(_logger); });
    app.MapPost("log", (ILoggerService _logger, AppData app) => 
    {
        AppLog.Log(_logger);
        return app;
    });
}

public static class AppLog
{
    public static void LogError(ILoggerService _logger) => _logger.LogError("Something was wrong");
    public static void LogWarning(ILoggerService _logger) => _logger.LogWarning("Be Careful");
    public static void Log(ILoggerService _logger) => _logger.Log("Hello!");
}

public sealed record AppData (string name, string message);