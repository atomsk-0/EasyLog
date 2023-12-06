using System.Drawing;
using EasyLog.Entities;

namespace Sample;

/* You can add more log types your self */

public class Verbose : ILogType
{
    public string Prefix => "VERBOSE";
    public Color PrefixColor => Color.Gray;
    public Color ArgColor => Color.Gray;
}