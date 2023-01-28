using Service.Application;

#region Services
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHostedService<TimerBackgroundService>();
#endregion

#region App
var app = builder.Build();
MapEndpoints(app);
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseRouting();
app.UseMiddleware<AppMiddleware>();
app.Run();
#endregion

static void MapEndpoints(WebApplication app)
{
    app.MapGet("request-response", () => {});
    app.MapGet("log", () => { LoggerService.Log("Hello!"); });
    app.MapGet("log-warning", () => { LoggerService.LogWarning("Be Careful"); });
    app.MapGet("log-error", () => { LoggerService.LogError("Something was wrong"); });
    app.MapGet("exception", () => { throw new Exception("New Exception thrown"); });
}