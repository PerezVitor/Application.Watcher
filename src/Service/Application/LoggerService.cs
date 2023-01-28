using Service.Domain.Entities;
using System.Runtime.CompilerServices;

namespace Service.Application;
public static class LoggerService
{
    public static void Log(string message,
        [CallerMemberName] string callerName = "",
        [CallerFilePath] string filePath = "",
        [CallerLineNumber] int lineNumber = 0,
        string level = "Info"
    )
    {
        var log = new LoggerModel
        {
            Message = message,
            Timestamp = DateTime.Now,
            CallingFrom = Path.GetFileName(filePath),
            CallingMethod = callerName,
            LineNumber = lineNumber,
            LogLevel = level
        };

        TimerBackgroundService.AddLog(log);
    }

    public static void LogError(
        string message,
        [CallerMemberName] string callerName = "",
        [CallerFilePath] string filePath = "",
        [CallerLineNumber] int lineNumber = 0
    )
    {
        Log(message, callerName, filePath, lineNumber, "Error");
    }

    public static void LogWarning(
        string message,
        [CallerMemberName] string callerName = "",
        [CallerFilePath] string filePath = "",
        [CallerLineNumber] int lineNumber = 0
    )
    {
        Log(message, callerName, filePath, lineNumber, "Warning");
    }
}
