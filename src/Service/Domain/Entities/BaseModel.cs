using Service.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Domain.Entities;
public abstract class BaseModel : Interfaces.IProcess
{
    protected BaseModel() => IsExecuted = false;

    [Key]
    public int Id { get; set; }
    public Guid CycleId { get; set; }
    public static string ApplicationName => AppOptionsStatic.ApplicationName;

    [NotMapped]
    public bool IsExecuted { get; set; }
    public void SetExecuted() => IsExecuted = true;
}
