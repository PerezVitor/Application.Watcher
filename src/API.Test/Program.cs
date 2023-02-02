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
    app.MapPost("log", (ILoggerService _logger) => { _logger.Log("Hello!"); });
    app.MapPut("log-warning", (ILoggerService _logger) => { _logger.LogWarning("Be Careful"); });
    app.MapDelete("log-error", (ILoggerService _logger) => { _logger.LogError("Something was wrong"); });
    app.MapPost("exception", () => { throw new Exception("New Exception thrown"); });
}