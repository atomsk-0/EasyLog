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

Console.ReadKey();