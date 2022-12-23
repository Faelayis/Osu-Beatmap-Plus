using Microsoft.UI.Xaml;

using Osu.Beatmap.Plus.Contracts.Services;
using Osu.Beatmap.Plus.ViewModels;

namespace Osu.Beatmap.Plus.Activation;

public class DefaultActivationHandler : ActivationHandler<LaunchActivatedEventArgs>
{
    private readonly INavigationService _navigationService;

    public DefaultActivationHandler(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    protected override bool CanHandleInternal(LaunchActivatedEventArgs args)
    {
        // None of the ActivationHandlers has handled the activation.
        return _navigationService.Frame?.Content == null;
    }

    protected async override Task HandleInternalAsync(LaunchActivatedEventArgs args)
    {
        _navigationService.NavigateTo(typeof(BackupViewModel).FullName!, args.Arguments);

        await Task.CompletedTask;
    }
}
