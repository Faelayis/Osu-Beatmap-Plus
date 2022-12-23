namespace Osu.Beatmap.Plus.Contracts.Services;

public interface IActivationService
{
    Task ActivateAsync(object activationArgs);
}
