using System.ComponentModel;
using Osu.Beatmap.Plus.Core.Contracts.Services;
using Osu.Beatmap.Plus.Core.Models;
using Osu.Beatmap.Plus.Core.Utilities;
using OsuParsers.Decoders;

namespace Osu.Beatmap.Plus.Core.Services;

public class OsuDataService : IOsuDataService
{
    private List<BeatmapsDetails> _allOrders;
    private int amount
    {
        get; set;
    }
    public OsuDataService()
    {
    }

    private static IEnumerable<BeatmapsDetails> AllOrders()
    {
        var companies = AllCompanies();
        return companies.SelectMany(c => c.Details);
    }
    private static IEnumerable<BeatmapsModels> AllCompanies()
    {
        if (FindDirectory.GetOsuFolder().Length == 0) return null;
        var dirsSongs = Directory.GetDirectories(@$"{FindDirectory.GetOsuFolder()}", "*", SearchOption.AllDirectories);
        var beatmapsCollection = new List<BeatmapsModels>();

        foreach (var dir in dirsSongs)
        {
            var file = System.IO.Directory.GetFiles(dir, "*.osu", SearchOption.TopDirectoryOnly);
            if (file.Length > 0)
            {
                var beatmap = BeatmapDecoder.Decode(file[0]);
                beatmapsCollection.Add(new BeatmapsModels()
                {
                    Path = file[0],
                    Details = new List<BeatmapsDetails>()
                {
                    new BeatmapsDetails()
                    {
                        ID = beatmap.MetadataSection.BeatmapID,
                        Title = beatmap.MetadataSection.Title,
                        Artist = beatmap.MetadataSection.Artist,
                        Creator = beatmap.MetadataSection.Creator,
                        Version = beatmap.MetadataSection.Version,
                        Tags = beatmap.MetadataSection.Tags,
                        Source = beatmap.MetadataSection.Source,
                        TagsString = beatmap.MetadataSection.TagsString,
                    }}
                });
            }
        }

        return beatmapsCollection;
    }

    public async Task<IEnumerable<BeatmapsDetails>> GetOsuBeatmaps()
    {
        _allOrders ??= new List<BeatmapsDetails>(AllOrders());

        await Task.CompletedTask;
        return _allOrders;
    }
}
