using EasyLog.Entities;

namespace EasyLog;

public static class Log
{
    private static Logger _logger = new(new LoggerOptions());

    public static void SetOptions(LoggerOptions loggerOptions)
        => _logger = new Logger(loggerOptions);

    public static void WriteLine<T>(string str, params object[] args) where T : ILogType, new()
        => _logger.WriteLine<T>(str, args);

    public static void Write<T>(string str, params object[] args) where T : ILogType, new()
        => _logger.Write<T>(str, args);

    public static void LogException(Exception ex)
        => _logger.LogException(ex);
}