using MediatR;
using Service.Application.Commands;
using Service.Infra.Data.Interfaces;

namespace Service.Domain.Entities;
internal class ExceptionHandler : IRequestHandler<ExceptionCommand>
{
    private readonly IExceptionRepository _exceptionRepository;
    public ExceptionHandler(IExceptionRepository exceptionRepository) 
        => _exceptionRepository = exceptionRepository;

    public async Task<Unit> Handle(ExceptionCommand exception, CancellationToken cancellationToken)
    {
        await _exceptionRepository.Save(exception.GetData());
        exception.SetExecuted();
        return Unit.Value;
    }
}
