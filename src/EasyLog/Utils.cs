using System.Drawing;
using System.Text;
using Pastel;

namespace EasyLog;

internal static class Utils
{
    internal static string ColorizeMessageArgs(string str, Color color, params object[] args)
    {
        var sb = new StringBuilder(str);
        foreach (var arg in args)
        {
            var sArg = arg.ToString()!;
            sb.Replace(sArg, sArg.Pastel(color));
        }
        return sb.ToString();
    }
    
    /* This makes possible to just have {} instead like this {0}, {1}... */
    internal static string Format(string str, params object[] args)
    {
        var sb = new StringBuilder(str);
        for (var i = 0; i < args.Length; i++)
        {
            sb.ReplaceFirst("{}", "{" + i + "}");
        }
        return string.Format(sb.ToString(), args);
    }

    private static void ReplaceFirst(this StringBuilder sb, string search, string replace)
    {
        var pos = sb.ToString().IndexOf(search, StringComparison.Ordinal);
        if (pos < 0) return;
        sb.Remove(pos, search.Length);
        sb.Insert(pos, replace);
    }
}