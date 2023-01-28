using Service.Domain.Interfaces;

namespace Service.Domain.Entities;
public class ResponseModel : IProcessamento
{
    public string? ResponseBody { get; set; }
    public int ResponseStatus { get; set; }
    public string? Headers { get; set; }
    public DateTime FinishTime { get; set; }
    public bool IsExecuted { get; set; }

    public void InsertLog() => Console.WriteLine("Response {0}", FinishTime);
    public void SetExecuted() => IsExecuted = true;
}
