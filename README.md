<h1 align="center">
  EasyLog
</h1>
<p align="center">
  Simple and easy to use logging system.
</p>

## How to use?
- Install Easy-Log to your project from nuget
  ``dotnet add package Easy-Log``
- You can either use global instance ``Log`` or create your own
````csharp
var options = new LoggerOptions
{
    ConsoleLogging = true, // Log to console
    ShowDateAndTime = true, // Show Date and time with the log prefix
    FileLogging = true, // Allow log to file
    FileOutputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App.log") // File output path
};
Logger log = new Logger(options);
````
If you use global instance you can set options by calling
````csharp
Log.SetOptions(options);
````

## LogTypes
Easy-Log has flexible log types where you can create your own using ``ILogType`` interface
- Here is example
````csharp
public class Verbose : ILogType
{
    public string Prefix => "VERBOSE"; // Set log prefix
    public Color PrefixColor => Color.Gray; // Set prefix color
    public Color ArgColor => Color.Gray; //Set args color
}
````

## Logging
To log you can use ``Write`` or ``WriteLine`` function. If you want log Exception you can use ``LogException``

````csharp
/* structure */
instance.WriteLine<ILogType>(string, args)
instance.Write<ILogType>(string, args)

Log.WriteLine<Debug>("Processing data - ID: {} Status: {}", 419, "In Progress");
Log.WriteLine<Info>("Task completed successfully - ID: {}", 613);
Log.WriteLine<Warning>("Unexpected input detected - Code: {}", "ABC123");
Log.WriteLine<Error>("Critical error occurred - Code: {}", "X987");

try
{
    List<int> list = [];
    var item = list[10];
}
catch (Exception e)
{
    Log.LogException(e);
}
````