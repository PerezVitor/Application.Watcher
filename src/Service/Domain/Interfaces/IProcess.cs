namespace Service.Domain.Interfaces;
public interface IProcess
{
    public int Id { get; set; }
    public Guid CycleId { get; set; }
    public bool IsExecuted { get; set; }
    
    public void SetExecuted();
}