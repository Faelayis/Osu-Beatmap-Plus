namespace Osu.Beatmap.Plus.Core.Models;

public class BeatmapsModels
{
    public string Path
    {
        get; set;
    }
    public ICollection<BeatmapsDetails> Details
    {
        get; set;
    }
}
