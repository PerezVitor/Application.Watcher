﻿namespace Service.Domain.Entities;
public class ResponseModel : BaseModel
{
    public string ResponseBody { get; set; }
    public int ResponseStatus { get; set; }
    public string Headers { get; set; }
    public DateTime FinishTime { get; set; }

    public ResponseModel() => FinishTime = DateTime.Now;
}
