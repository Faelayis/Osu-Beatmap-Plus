using Microsoft.UI.Xaml.Controls;
using Osu.Beatmap.Plus.ViewModels;
using Squirrel;

namespace Osu.Beatmap.Plus.Views;

public sealed partial class SettingsPage : Page
{
    public SettingsViewModel ViewModel
    {
        get;
    }

    public SettingsPage()
    {
        ViewModel = App.GetService<SettingsViewModel>();
        InitializeComponent();
    }

    private void Button_CheckForUpdate(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        Task.Run(UpdateMyApp);
    }

    private static async Task UpdateMyApp()
    {
        using UpdateManager updateManager = new GithubUpdateManager("https://github.com/Faelayis/Osu-Beatmap-Plus");
        if (!updateManager.IsInstalledApp)
        {
            App.MainWindow.DispatcherQueue.TryEnqueue(() =>
            {
                App.MainWindow.ShowMessageDialogAsync("Not Found update.exe", "Notification");
                App.MainWindow.BringToFront();
            });
            return;
        }

        var updateInfo = await updateManager.CheckForUpdate();
        if (updateInfo != null)
        {
            var release = await updateManager.UpdateApp();
            if (release != null)
            {
                App.MainWindow.DispatcherQueue.TryEnqueue(() =>
                {
                    App.MainWindow.ShowMessageDialogAsync($"Update To {release.Version}", "Notification");
                    App.MainWindow.BringToFront();
                });
                UpdateManager.RestartApp();
            }
        }
    }
}
