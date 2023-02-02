namespace Service.Application.DTO;
public class LogDto
{
    public string Message { get; set; }
    public string LogLevel { get; set; }
    public string CallingFrom { get; set; }
    public string CallingMethod { get; set; }
    public int LineNumber { get; set; }
}
