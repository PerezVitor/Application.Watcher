using AutoMapper;
using Microsoft.AspNetCore.Http;
using Service.Application.DTO;
using Service.Domain.Entities;

namespace Service.Application.Mappings;
internal class MapModels : Profile
{
    public MapModels()
    {
        #region Exception Model
        CreateMap<RequestModel, ExceptionModel>().ReverseMap();
        CreateMap<Exception, ExceptionModel>().ReverseMap();
        #endregion

        #region Request Model
        CreateMap<HttpRequest, RequestModel>().ReverseMap();
        #endregion

        #region Log Model
        CreateMap<LogDto, LoggerModel>().ReverseMap();
        #endregion
    }
}
