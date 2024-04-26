using MauiBlazor.WebApp.Authentication;
using MauiBlazor.WebApp.Constants;
using Microsoft.AspNetCore.Components;

namespace MauiBlazor.WebApp.Shared.Layouts;

public partial class MainLayout
{
    [Inject]
    private IAuthenticationService AuthenticationService { get; init; } = null!;

    [Inject]
    private NavigationManager NavigationManager { get; init; } = null!;

    protected override void OnInitialized()
    {
        bool isAuthenticated = AuthenticationService.IsAuthenticated();
        
        if (!isAuthenticated)
        {
            NavigationManager.NavigateTo(Routes.Login);
        }
    }
}