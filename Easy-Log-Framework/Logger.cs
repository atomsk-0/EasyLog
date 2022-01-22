using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EasyLog
{
    public class Logger
    {
        public Config cfg;
        private bool start = true;
        public void Debug(string log)
        {
            if (File.Exists(cfg.LogPath) && start) File.Delete(cfg.LogPath);
            start = false;
            if (cfg.Date) log = "DEBUG | [" + DateTime.Now.ToString() + "] " + log + log + "\n";
            else log = "[DEBUG] " + log;
            if (cfg.Console) Console.WriteLine(log, Console.ForegroundColor = ConsoleColor.Yellow);
            File.AppendAllText(cfg.LogPath, log);
        }
        public void Info(string log)
        {
            if (File.Exists(cfg.LogPath) && start) File.Delete(cfg.LogPath);
            start = false;
            if (cfg.Date) log = "INFO | [" + DateTime.Now.ToString() + "] " + log + log + "\n";
            else log = "[INFO] " + log;
            if (cfg.Console) Console.WriteLine(log, Console.ForegroundColor = ConsoleColor.Blue);
            File.AppendAllText(cfg.LogPath, log);
        }
        public void Warning(string log)
        {
            if (File.Exists(cfg.LogPath) && start) File.Delete(cfg.LogPath);
            start = false;
            if (cfg.Date) log = "WARN | [" + DateTime.Now.ToString() + "] " + log + "\n";
            else log = "[WARN] " + log;
            if (cfg.Console) Console.WriteLine(log, Console.ForegroundColor = ConsoleColor.DarkYellow);
            File.AppendAllText(cfg.LogPath, log);
        }
        public void Error(string log)
        {
            if (File.Exists(cfg.LogPath) && start) File.Delete(cfg.LogPath);
            start = false;
            if (cfg.Date) log = "ERROR | [" + DateTime.Now.ToString() + "] " + log + log + "\n";
            else log = "[ERROR] " + log;
            if (cfg.Console) Console.WriteLine(log, Console.ForegroundColor = ConsoleColor.Red);
            File.AppendAllText(cfg.LogPath, log);
        }
    }
}
