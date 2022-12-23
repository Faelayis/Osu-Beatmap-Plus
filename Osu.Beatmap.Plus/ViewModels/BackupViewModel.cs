using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Osu.Beatmap.Plus.Contracts.ViewModels;
using Osu.Beatmap.Plus.Core.Contracts.Services;
using Osu.Beatmap.Plus.Core.Models;

namespace Osu.Beatmap.Plus.ViewModels;

public partial class BackupViewModel : ObservableRecipient, INavigationAware
{
    private readonly IOsuDataService _OsuDataService;
    public ObservableCollection<BeatmapsDetails> Source { get; } = new ObservableCollection<BeatmapsDetails>();
    public BackupViewModel(IOsuDataService OsuDataService)
    {
        _OsuDataService = OsuDataService;
    }

    public async void OnNavigatedTo(object parameter)
    {
        await ImportBeatmaps();
    }

    public void OnNavigatedFrom()
    {

    }

    [RelayCommand]
    private async Task ImportBeatmaps()
    {
        Source.Clear();
        var data = await _OsuDataService.GetOsuBeatmaps();
        foreach (var item in data)
        {
            Source.Add(item);
        }
    }
}
