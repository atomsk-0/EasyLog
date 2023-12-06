using System.Text;
using EasyLog.Entities;
using EasyLog.LogTypes;
using Pastel;

namespace EasyLog;

public class Logger
{
    private readonly StreamWriter? _fileStream;
    private readonly LoggerOptions _loggerOptions;

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
        var formatted = Utils.Format(str, args);
        var logType = new T();
        var dat = "";
        if (_loggerOptions.ShowDateAndTime)
        {
            dat = $"[{DateTime.Now.ToLongTimeString()}] ";
        }
        
        if (_loggerOptions.ConsoleLogging)
        {
            var colorized = Utils.ColorizeMessageArgs(formatted, logType.ArgColor, args);
            Console.Write(dat.Pastel(ConsoleColor.DarkGray) + $"{logType.Prefix}: ".Pastel(logType.PrefixColor) +  colorized);
        }
        
        
        _fileStream?.Write($"{dat}{logType.Prefix}: {formatted}");
    }
    
    public void LogException(Exception ex)
    {
        WriteLine<Error>("Exception: {}\nMessage: {}\nStackTrace: {}", ex.GetType().FullName ?? "Unknown Source", ex.Message, ex.StackTrace ?? "No stacktrace");
    }
}