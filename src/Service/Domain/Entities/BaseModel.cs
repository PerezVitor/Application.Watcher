using Service.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Domain.Entities;
public abstract class BaseModel : Interfaces.IProcess
{
    protected BaseModel()
    {
        IsExecuted = false;
        ApplicationName = AppOptionsStatic.ApplicationName;
    }

    [Key]
    public long Id { get; set; }
    public Guid CycleId { get; set; }
    public string ApplicationName { get; private set; }

    [NotMapped]
    public bool IsExecuted { get; set; }
    public void SetExecuted() => IsExecuted = true;
}
