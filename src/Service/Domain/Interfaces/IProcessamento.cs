namespace Service.Domain.Interfaces;
public interface IProcessamento
{
    public Guid Id { get; set; }
    public bool IsExecuted { get; set; }
    public void InsertLog();
    public void SetExecuted();
}