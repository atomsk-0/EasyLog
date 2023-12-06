namespace EasyLog.Entities;

public struct LoggerOptions()
{
    public bool ConsoleLogging = true;
    public bool ShowDateAndTime = true;
    
    public bool FileLogging = false;
    public string FileOutputPath = string.Empty;
}