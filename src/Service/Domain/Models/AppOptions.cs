namespace Service.Domain.Models;
public class AppOptions
{
    /// <summary>
    /// The connection string must be from the Sql Server database
    /// </summary>
    public string ConnectionString { get; set; }

    /// <summary>
    /// Name of the application that is processing the logs
    /// </summary>
    public string ApplicationName { get; set; }

    /// <summary>
    /// Maximum number of logs that can be stored for service processing
    /// Default value: 10000
    /// </summary>
    public int ListLogsLength { get; set; }

    /// <summary>
    /// Number of logs that will be entered into the database at each service run
    /// Default value: 10000
    /// </summary>
    public int ListLogInsertLength { get; set; }

    /// <summary>
    /// Time the log processing service will wait for next run
    /// Default value: 60000 ms
    /// </summary>
    public int BackgroundServiceTimer { get; set; }

    public AppOptions()
    {
        ListLogsLength = 10000;
        ListLogInsertLength = 10000;
        BackgroundServiceTimer = 60000;
    }
}