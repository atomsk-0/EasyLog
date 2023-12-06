using System.Drawing;
using EasyLog.Entities;

namespace EasyLog.LogTypes;

public class Info : ILogType
{
    public string Prefix => "INFO";
    public Color PrefixColor => Color.DodgerBlue;
    public Color ArgColor => Color.DodgerBlue;
}