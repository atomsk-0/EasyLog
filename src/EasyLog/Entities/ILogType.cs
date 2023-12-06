using System.Drawing;

namespace EasyLog.Entities;

public interface ILogType
{
    public string Prefix { get; }
    public Color PrefixColor { get; }
    public Color ArgColor { get; }
}