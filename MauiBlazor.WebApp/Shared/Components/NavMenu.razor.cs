using MauiBlazor.WebApp.Authentication;
using MauiBlazor.WebApp.Constants;
using Microsoft.AspNetCore.Components;

namespace MauiBlazor.WebApp.Shared.Components;

public partial class NavMenu
{
    # region Services

    [Inject]
    private IAuthenticationService AuthenticationService { get; init; } = null!;

    [Inject]
    private NavigationManager NavigationManager { get; set; } = null!;

    # endregion

    # region Properties

    private bool _collapseNavMenu = true;

    private string? NavMenuCssClass => _collapseNavMenu ? "collapse" : null;

    # endregion

    private void ToggleNavMenu()
    {
        _collapseNavMenu = !_collapseNavMenu;
    }

    private void Logout()
    {
        AuthenticationService.Logout();

        NavigationManager.NavigateTo(Routes.Login);
    }
}