namespace Osu.Beatmap.Plus.Core.Models;

public class BeatmapsDetails
{
    public int ID
    {
        get; set;
    }
    public string Title
    {
        get; set;
    }
    public string TitleUnicode
    {
        get; set;
    }
    public string Artist
    {
        get; set;
    }
    public string Creator
    {
        get; set;
    }
    public string Version
    {
        get; set;
    }
    public string Source
    {
        get; set;
    }
    public string TagsString
    {
        get; set;
    }
    public string[] Tags
    {
        get; set;
    }
}
