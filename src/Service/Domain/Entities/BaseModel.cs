using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Domain.Entities;
public abstract class BaseModel : Interfaces.IProcessamento
{
    protected BaseModel() => IsExecuted = false;

    [Key]
    public int Id { get; set; }
    public Guid IdSecundario { get; set; }
    public static string ApplicationName => AppOptionsStatic.ApplicationName;

    [NotMapped]
    public bool IsExecuted { get; set; }

    public abstract void InsertLog();
    public void SetExecuted() => IsExecuted = true;
}
