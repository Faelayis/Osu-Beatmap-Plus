using Microsoft.UI.Xaml.Controls;

using Osu.Beatmap.Plus.ViewModels;

namespace Osu.Beatmap.Plus.Views;

public sealed partial class MainPage : Page
{
    public MainViewModel ViewModel
    {
        get;
    }

    public MainPage()
    {
        ViewModel = App.GetService<MainViewModel>();
        InitializeComponent();
    }
}
