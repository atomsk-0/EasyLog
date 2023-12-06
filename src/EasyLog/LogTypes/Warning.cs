using System.Drawing;
using EasyLog.Entities;

namespace EasyLog.LogTypes;

public class Warning : ILogType
{
    public string Prefix => "WRN";
    public Color PrefixColor => Color.Tomato;
    public Color ArgColor => Color.Tomato;
}