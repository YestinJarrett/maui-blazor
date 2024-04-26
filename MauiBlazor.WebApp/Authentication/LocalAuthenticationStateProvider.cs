using Microsoft.AspNetCore.Components.Authorization;

namespace MauiBlazor.WebApp.Authentication;

public class LocalAuthenticationStateProvider : AuthenticationStateProvider
{
    private AuthenticationState _currentUser;

    public LocalAuthenticationStateProvider(IAuthenticationService authenticationService)
    {
        _currentUser = new AuthenticationState(authenticationService.CurrentUser);

        authenticationService.UserChangedEvent += (newUser) =>
        {
            _currentUser = new AuthenticationState(newUser);
            NotifyAuthenticationStateChanged(Task.FromResult(_currentUser));
        };
    }

    public override Task<AuthenticationState> GetAuthenticationStateAsync() => Task.FromResult(_currentUser);
}