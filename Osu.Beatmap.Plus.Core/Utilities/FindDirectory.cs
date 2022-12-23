using Microsoft.Win32;

namespace Osu.Beatmap.Plus.Core.Utilities;
internal class FindDirectory
{
    public static string GetOsuFolder()
    {
        const String keyName1 = @"HKEY_CLASSES_ROOT\osu\shell\open\command";
        const String keyName2 = @"HKEY_CLASSES_ROOT\osu!\shell\open\command";
        var songsPath = String.Empty;
        string path;
        try
        {
            path = Registry.GetValue(keyName1, String.Empty, String.Empty).ToString();
            if (path == String.Empty)
                path = Registry.GetValue(keyName2, String.Empty, String.Empty).ToString();
            if (path != String.Empty)
            {
                path = path.Remove(0, 1);
                path = path.Split('\"')[0];
                path = System.IO.Path.GetDirectoryName(path);

                var iniPath = System.IO.Path.Combine(path, "osu!." + Environment.UserName + ".cfg");
                StreamReader s = File.OpenText(iniPath);

                while (!s.EndOfStream && !(songsPath != String.Empty))
                {
                    var l = s.ReadLine();
                    if (l.StartsWith("#"))
                        continue;
                    string[] separator = { " = " };
                    var kv = l.Split(separator, StringSplitOptions.None);
                    if (kv[0] == "BeatmapDirectory")
                        songsPath = kv[1];
                }
                if (songsPath == string.Empty)
                    songsPath = System.IO.Path.Combine(path, "Songs");
            }
        }
        catch
        {
            return "";
        }
        if (System.IO.Path.IsPathRooted(songsPath))
            return songsPath;
        else
            return System.IO.Path.Combine(path, songsPath);
    }
}
