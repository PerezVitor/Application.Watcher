namespace Service.Domain.Entities;
public abstract class BaseModel : Interfaces.IProcessamento
{
    public bool IsExecuted { get; set; }
    public Guid Id { get; set; }
    protected BaseModel() => IsExecuted = false;

    public abstract void InsertLog();
    public void SetExecuted() => IsExecuted = true;
}
