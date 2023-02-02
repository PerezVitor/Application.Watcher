namespace Service.Domain.Models;
internal static class AppOptionsStatic
{
    public static string ApplicationName { get; set; }
    public static string ConnectionString { get; set; }
    public static int ListLogsLength { get; set; }
    public static int ListLogInsertLength { get; set; }
    public static int BackgroundServiceTimer { get; set; }
}