using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLog
{
    public class Config
    {
        public string LogPath = Environment.CurrentDirectory + @"\Application.log";
        public bool Date = true;
        public bool Console = true;
        public bool ClearOnStart = true;
    }
}
