using AutoMapper;
using Service.Application.DTO;
using Service.Application.Middleware.Interface;
using Service.Application.Services;
using Service.Domain.Entities;

namespace Service.Application.Middleware;
internal class AppMiddlewareLogger : ILog
{
    private readonly IMapper _mapper;
    public AppMiddlewareLogger(IMapper mapper) => _mapper = mapper;

    public Task Log(LogDto log)
    {
        LoggerModel _loggerModel = new();

        _mapper.Map(log, _loggerModel);
        _loggerModel.CycleId = Guid.NewGuid();

        WatcherService.AddLog(_loggerModel);
        return Task.CompletedTask;
    }
}
