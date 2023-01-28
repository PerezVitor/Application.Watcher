namespace Service.Application.DTO;
public class LogDto
{
    public string message { get; set; }
    public string level { get; set; }
    public string callerName { get; set; }
    public string filePath { get; set; }
    public int lineNumber { get; set; }
}
