using Service.Domain.Entities;

namespace Service.Infra.Data.Interfaces;
internal interface IResponseRepository
{
    Task Save(List<ResponseModel> response);
}
