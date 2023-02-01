namespace Service.Domain.Entities;
public class RequestModel : BaseModel
{
    public string RequestBody { get; set; }
    public string QueryString { get; set; }
    public string Path { get; set; }
    public string Headers { get; set; }
    public string Method { get; set; }
    public string Host { get; set; }
    public string IpAddress { get; set; }
    public DateTime StartTime { get; set; }

    public RequestModel() => StartTime = DateTime.Now;
    public override void InsertLog() => Console.WriteLine("Request {0} {1} {2}", StartTime, IdSecundario, ApplicationName);
}
