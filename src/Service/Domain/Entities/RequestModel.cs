using Service.Domain.Interfaces;

namespace Service.Domain.Entities;
public class RequestModel : IProcessamento
{
    public string? RequestBody { get; set; }
    public string? QueryString { get; set; }
    public string? Path { get; set; }
    public string? Headers { get; set; }
    public string? Method { get; set; }
    public string? Host { get; set; }
    public string? IpAddress { get; set; }
    public DateTime StartTime { get; set; }
    public bool IsExecuted { get; set; }

    public void InsertLog() => Console.WriteLine("Request {0}", StartTime);
    public void SetExecuted() => IsExecuted = true;
}
