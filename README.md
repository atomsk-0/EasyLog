<h1 align="center">
  EasyLog
</h1>
<p align="center">
  A simple and user-friendly logging system for .NET projects.
</p>

<img src="https://i.imgur.com/NKhyA4h.png" align="middle">

## Installation
Install Easy-Log in your project using NuGet Package Manager Console:
```bash
dotnet add package Easy-Log
```

## Getting Started
You can use the global instance `Log` or create your own instance with custom options.
```csharp
var options = new LoggerOptions
{
    ConsoleLogging = true,         // Log to console
    ShowDateAndTime = true,        // Show Date and time with the log prefix
    FileLogging = true,            // Allow log to file
    FileOutputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App.log") // File output path
};
Logger log = new Logger(options);
```

If you are using the global instance, set options like this:
```csharp
Log.SetOptions(options);
```

## Log Types
Easy-Log supports flexible log types. You can create your own by implementing the `ILogType` interface. Here's an example:
```csharp
public class Verbose : ILogType
{
    public string Prefix => "VERBOSE"; // Set log prefix
    public Color PrefixColor => Color.Gray; // Set prefix color
    public Color ArgColor => Color.Gray; // Set args color
}
```

## Logging
To log messages, use the `Write` or `WriteLine` functions. For logging exceptions, use `LogException`.

```csharp
/* structure */
instance.WriteLine<ILogType>(string, args)
instance.Write<ILogType>(string, args)
    
Log.WriteLine<Debug>("Hello World ARG 0: {} ARG 2: {}", 419, 500);
Log.WriteLine<Info>("Hello World ARG 0: {}", 613);
Log.WriteLine<Warning>("Hello World ARG 0: {}", 74);
Log.WriteLine<Error>("Hello World ARG 0: {}", 42);

try
{
    List<int> list = new List<int>();
    var item = list[10];
}
catch (Exception e)
{
    Log.LogException(e);
}
```