using Osu.Beatmap.Plus.Core.Models;

namespace Osu.Beatmap.Plus.Core.Contracts.Services;
public interface IOsuDataService
{
    Task<IEnumerable<BeatmapsDetails>> GetOsuBeatmaps();
}
