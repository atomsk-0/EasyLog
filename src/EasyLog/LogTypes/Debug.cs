using System.Drawing;
using EasyLog.Entities;

namespace EasyLog.LogTypes;

public class Debug : ILogType
{
    public string Prefix => "DBG";
    public Color PrefixColor => Color.MediumSlateBlue;
    public Color ArgColor => Color.MediumSlateBlue;
}