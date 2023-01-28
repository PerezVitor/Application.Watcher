﻿using AutoMapper;
using Service.Application.Log;
using Service.Application.Middleware.Interface;
using Service.Domain.Entities;

namespace Service.Application.Middleware;
internal class AppMiddlewareException : IException
{
    private readonly IMapper _mapper;
    public AppMiddlewareException(IMapper mapper) => _mapper = mapper;

    public Task Log(Guid id, RequestModel request, Exception exception)
    {
        ExceptionModel _exceptionLogger = new();
        _mapper.Map(request, _exceptionLogger);
        _mapper.Map(exception, _exceptionLogger);
        _exceptionLogger.Id = id;

        LogBackgroundService.AddException(_exceptionLogger);
        return Task.CompletedTask;
    }
}
