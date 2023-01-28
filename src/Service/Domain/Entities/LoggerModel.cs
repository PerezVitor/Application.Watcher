using Service.Domain.Interfaces;

namespace Service.Domain.Entities;
public class LoggerModel : IProcessamento
{
    public string? Message { get; set; }
    public DateTime Timestamp { get; set; }
    public string? CallingFrom { get; set; }
    public string? CallingMethod { get; set; }
    public int LineNumber { get; set; }
    public string? LogLevel { get; set; }
    public bool IsExecuted { get; set; }

    public void InsertLog() => Console.WriteLine("Log {0} {1}", LogLevel, Message);
    public void SetExecuted() => IsExecuted = true;
}
