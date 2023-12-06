using System.Drawing;
using EasyLog.Entities;

namespace EasyLog.LogTypes;

public class Error : ILogType
{
    public string Prefix => "ERR";
    public Color PrefixColor => Color.Crimson;
    public Color ArgColor => Color.Crimson;
}