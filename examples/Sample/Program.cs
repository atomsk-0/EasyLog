using EasyLog;
using EasyLog.Entities;
using EasyLog.LogTypes;

/* Directly use static one if you only need 1 log instance */
var options = new LoggerOptions
{
    ConsoleLogging = true, // Log to console
    ShowDateAndTime = true, // Show Date and time with the log prefix
    FileLogging = true, // Allow log to file
    FileOutputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App.log") // File output path
};

/* Or make your own instance: */
//var log = new Logger(options);

Log.SetOptions(options);
Log.WriteLine<Debug>("Hello World ARG 0: {} ARG 2: {}", 419, 500);
Log.WriteLine<Info>("Hello World ARG 0: {}", 613);
Log.WriteLine<Warning>("Hello World ARG 0: {}", 74);
Log.WriteLine<Error>("Hello World ARG 0: {}", 42);

try
{
    List<int> list = [];
    var item = list[10];
}
catch (Exception e)
{
    Log.LogException(e);
}

Console.ReadKey();