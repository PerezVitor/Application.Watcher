namespace Service.Domain.Entities;
public class ExceptionModel : BaseModel
{
    public string Message { get; set; }
    public string TypeOf { get; set; }
    public string Source { get; set; }
    public string Path { get; set; }
    public string Method { get; set; }
    public string QueryString { get; set; }
    public string RequestBody { get; set; }
    public DateTime EncounteredAt { get; set; }
    public string StackTrace { get; set; }

    public ExceptionModel() => EncounteredAt = DateTime.Now;
    public override void InsertLog() => Console.WriteLine("Exception {0} - {1}", StackTrace, Id);
}
