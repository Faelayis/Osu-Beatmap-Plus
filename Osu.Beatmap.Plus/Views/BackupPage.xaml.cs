using Microsoft.UI.Xaml.Controls;
using Osu.Beatmap.Plus.ViewModels;

namespace Osu.Beatmap.Plus.Views;
public sealed partial class BackupPage : Page
{
    public BackupViewModel ViewModel
    {
        get;
    }

    public BackupPage()
    {
        ViewModel = App.GetService<BackupViewModel>();
        InitializeComponent();
    }
}
