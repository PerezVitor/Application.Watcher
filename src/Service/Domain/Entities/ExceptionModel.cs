using Service.Domain.Interfaces;

namespace Service.Domain.Entities;
public class ExceptionModel : IProcessamento
{
    public string? Message { get; set; }
    public string? TypeOf { get; set; }
    public string? Source { get; set; }
    public string? Path { get; set; }
    public string? Method { get; set; }
    public string? QueryString { get; set; }
    public string? RequestBody { get; set; }
    public DateTime EncounteredAt { get; set; }
    public string? StackTrace { get; set; }
    public bool IsExecuted { get; set; }

    public void InsertLog() => Console.WriteLine("Exception {0}", StackTrace);
    public void SetExecuted() => IsExecuted = true;
}
