using Service.Domain.Entities;

namespace Service.Infra.Data.Interfaces;
internal interface IRequestRepository
{
    Task Save(List<RequestModel> request);
}
