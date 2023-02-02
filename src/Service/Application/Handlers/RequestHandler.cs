using MediatR;
using Service.Application.Commands;
using Service.Infra.Data.Interfaces;

namespace Service.Domain.Entities;
internal class RequestHandler : IRequestHandler<RequestCommand>
{
    private readonly IRequestRepository _requestRepository;
    public RequestHandler(IRequestRepository requestRepository) => _requestRepository = requestRepository;

    public async Task<Unit> Handle(RequestCommand request, CancellationToken cancellationToken)
    {
        await _requestRepository.Save(request.GetData());
        request.SetExecuted();
        return Unit.Value;
    }
}
