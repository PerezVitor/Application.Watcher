namespace Service.Domain.Interfaces;
public interface IProcessamento
{
    public int Id { get; set; }
    public Guid IdSecundario { get; set; }
    public bool IsExecuted { get; set; }
    
    public void SetExecuted();
    public void InsertLog();
}