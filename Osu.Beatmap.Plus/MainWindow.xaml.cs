using Osu.Beatmap.Plus.Helpers;

namespace Osu.Beatmap.Plus;

public sealed partial class MainWindow : WindowEx
{
    public MainWindow()
    {
        InitializeComponent();

        AppWindow.SetIcon(Path.Combine(AppContext.BaseDirectory, "Assets/applicationIcon.ico"));
        Content = null;
        Title = "AppDisplayName".GetLocalized();
    }
}
