namespace Service.Domain.Entities;
public class LoggerModel : BaseModel
{
    public string Message { get; set; }
    public DateTime Timestamp { get; set; }
    public string CallingFrom { get; set; }
    public string CallingMethod { get; set; }
    public int LineNumber { get; set; }
    public string LogLevel { get; set; }

    public LoggerModel() => Timestamp = DateTime.Now;
    public override void InsertLog() => Console.WriteLine("Log {0} {1} {2}", LogLevel, Message, Id);
}
