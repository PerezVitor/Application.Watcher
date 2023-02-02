namespace Service.Domain.Models;
public class AppOptions
{
    /// <summary>
    /// The connection string must be from the Sql Server database
    /// </summary>
    public string ConnectionString { get; set; }
    public string ApplicationName { get; set; }
}