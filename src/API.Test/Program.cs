using Service;
using Service.Application.Log;
using Service.Application.Log.Inteface;

#region Services
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAppWatcherServices();
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
    app.MapGet("log", (ILoggerService _logger) => { _logger.Log("Hello!"); });
    app.MapGet("log-warning", (ILoggerService _logger) => { _logger.LogWarning("Be Careful"); });
    app.MapGet("log-error", (ILoggerService _logger) => { _logger.LogError("Something was wrong"); });
    app.MapGet("exception", () => { throw new Exception("New Exception thrown"); });
}