using Service.Domain.Interfaces;

namespace Service.Application.Commands;
internal class BaseCommand<T> : MediatR.IRequest
where T : class, IProcess
{
    private readonly List<T> _listData;
    public BaseCommand(List<T> listData) => _listData = listData;
    internal List<T> GetData() => _listData;

    internal void SetExecuted()
    {
        foreach (var item in _listData)
            item.SetExecuted();
    }
}
