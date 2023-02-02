using Service.Domain.Entities;

namespace Service.Application.Commands;
internal class ExceptionCommand : BaseCommand<ExceptionModel>
{
    public ExceptionCommand(List<ExceptionModel> exceptions) : base(exceptions) { }
}
