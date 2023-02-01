using Service.Application.DTO;
using Service.Application.Log.Inteface;
using Service.Application.Middleware.Interface;
using System.Runtime.CompilerServices;

namespace Service.Application.Log;
internal class LoggerService : ILoggerService
{
    private readonly ILog _iLog;
    public LoggerService(ILog iLog) => _iLog = iLog;

    public async Task Log(string message, string level = "Info", [CallerMemberName] string callerName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
    {
        var log = new LogDto
        {
            callerName = callerName,
            level = level,
            filePath = Path.GetFileName(filePath),
            lineNumber = lineNumber,
            message = message
        };

        await _iLog.Log(log);
    }

    public async Task LogError(string message, [CallerMemberName] string callerName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        => await Log(message, "Error", callerName, filePath, lineNumber);


    public async Task LogWarning(string message, [CallerMemberName] string callerName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        => await Log(message, "Warning", callerName, filePath, lineNumber);
}
