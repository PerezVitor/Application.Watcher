using Service.Domain.Entities;

namespace Service.Application.Commands;
internal class RequestCommand : BaseCommand<RequestModel>
{
    public RequestCommand(List<RequestModel> requests) : base(requests) { }
}
