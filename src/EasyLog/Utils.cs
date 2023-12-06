using System.Drawing;
using Pastel;

namespace EasyLog;

internal static class Utils
{
    internal static string ColorizeMessageArgs(string str, Color color, params object[] args)
    {
        return args.Select(arg => arg.ToString()!).Aggregate(str, (current, sArg) => current.Replace(sArg, sArg.Pastel(color)));
    }
    
    /* This makes possible to just have {} instead like this {0}, {1}... */
    internal static string Format(string str, params object[] args)
    {
        for (var i = 0; i < args.Length; i++)
        {
            str = str.ReplaceFirst("{}", "{" + i + "}");
        }
        return string.Format(str, args);
    }
    
    internal static string ReplaceFirst(this string text, string search, string replace)
    {
        var pos = text.IndexOf(search, StringComparison.Ordinal);
        return pos < 0 ? text : string.Concat(text.AsSpan(0, pos), replace, text.AsSpan(pos + search.Length));
    }
}