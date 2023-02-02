using Service.Domain.Entities;

namespace Service.Infra.Data.Interfaces;
internal interface IExceptionRepository
{
    Task Save(List<ExceptionModel> exception);
}
