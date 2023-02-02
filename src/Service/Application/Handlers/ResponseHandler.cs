using MediatR;
using Service.Application.Commands;
using Service.Infra.Data.Interfaces;

namespace Service.Domain.Entities;
internal class ResponseHandler : IRequestHandler<ResponseCommand>
{
    private readonly IResponseRepository _responseRepository;
    public ResponseHandler(IResponseRepository responseRepository) => _responseRepository = responseRepository;

    public async Task<Unit> Handle(ResponseCommand response, CancellationToken cancellationToken)
    {
        await _responseRepository.Save(response.GetData());
        response.SetExecuted();
        return Unit.Value;
    }
}
