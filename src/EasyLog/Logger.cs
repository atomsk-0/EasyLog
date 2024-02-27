using System.Text;
using EasyLog.Entities;
using EasyLog.LogTypes;
using Pastel;

namespace EasyLog;

public class Logger
{
    private readonly StreamWriter? _fileStream;
    private readonly LoggerOptions _loggerOptions;
    private readonly Dictionary<Type, ILogType> _logTypeCache = new();

    public Logger(LoggerOptions loggerOptions)
    {
        _loggerOptions = loggerOptions;
        if (!loggerOptions.FileLogging) return;
        if (string.IsNullOrEmpty(loggerOptions.FileOutputPath))
        {
            throw new Exception("When File logging is enabled, file output path cannot be empty or null");
        }
        _fileStream = File.CreateText(loggerOptions.FileOutputPath);
        _fileStream.AutoFlush = true;
    }

    public void WriteLine<T>(string str, params object[] args) where T : ILogType, new()
    {
        Write<T>($"{str}\n", args);
    }

    public void Write<T>(string str, params object[] args) where T : ILogType, new()
    {
        var logType = GetLogType<T>();
        var sb = new StringBuilder();
        if (_loggerOptions.ShowDateAndTime)
        {
            sb.Append($"[{DateTime.Now.ToLongTimeString()}] ");
        }
        sb.Append($"{logType.Prefix}: ".Pastel(logType.PrefixColor));
        sb.Append(Utils.Format(str, args));

        if (_loggerOptions.ConsoleLogging)
        {
            var colorized = Utils.ColorizeMessageArgs(sb.ToString(), logType.ArgColor, args);
            Console.Write(colorized);
        }

        _fileStream?.Write(sb.ToString());
    }

    public void LogException(Exception ex)
    {
        var sb = new StringBuilder();
        sb.AppendLine("An exception has occurred:".Pastel(GetLogType<Error>().PrefixColor));
        sb.AppendLine(ex.GetType().FullName.Pastel(GetLogType<Error>().PrefixColor) ?? "Unknown Source".Pastel(GetLogType<Error>().PrefixColor));
        sb.AppendLine(ex.Message.Pastel(GetLogType<Error>().PrefixColor));
        sb.AppendLine(ex.StackTrace.Pastel(GetLogType<Error>().PrefixColor) ?? "No stacktrace".Pastel(GetLogType<Error>().PrefixColor));
        WriteLine<Error>(sb.ToString());
    }
    
    private T GetLogType<T>() where T : ILogType, new()
    {
        var type = typeof(T);
        if (!_logTypeCache.TryGetValue(type, out var logType))
        {
            logType = new T();
            _logTypeCache[type] = logType;
        }
        return (T)logType;
    }
}