using Service.Domain.Entities;

namespace Service.Application.Commands;
internal class ResponseCommand : BaseCommand<ResponseModel>
{
    public ResponseCommand(List<ResponseModel> responses) : base(responses) { }
}
