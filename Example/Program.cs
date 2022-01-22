using System;
using EasyLog;

namespace Example
{
    class Program
    {
        static Logger log = new Logger();
        static Config cfg = new Config();
        
        //If you want change logger settings you can do that in this example i will not change it
        static void SetConfig()
        {
            cfg.LogPath = "NewLog.log";//Set path where you want log to be saved
            cfg.Date = false;//If this is set to true it will add date to the log
            cfg.Console = false;//If this is set to true it will print the log to Console too
        }
        static void Main(string[] args)
        {
            //SetConfig();
            log.cfg = cfg;
            Console.Title = "Easy Log Example";

            log.Info("Hello from log, this is info");
            log.Debug("Hello from log, this is debug");
            log.Warning("Hello from log, this is warning");
            log.Error("Hello from log, this is error");
            Console.ReadKey();
        }
    }
}
