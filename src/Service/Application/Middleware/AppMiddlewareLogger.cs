using AutoMapper;
using Service.Application.DTO;
using Service.Application.Log;
using Service.Application.Middleware.Interface;
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
        _loggerModel.IdSecundario = Guid.NewGuid();

        LogBackgroundService.AddLog(_loggerModel);
        return Task.CompletedTask;
    }
}
