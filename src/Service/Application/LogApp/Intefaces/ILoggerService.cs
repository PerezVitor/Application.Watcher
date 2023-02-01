using System.Runtime.CompilerServices;

namespace Service.Application.Log.Inteface;
public interface ILoggerService
{
    Task Log(string message, string level = "Info", [CallerMemberName] string callerName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);
    Task LogError(string message, [CallerMemberName] string callerName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);
    Task LogWarning(string message, [CallerMemberName] string callerName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);
}