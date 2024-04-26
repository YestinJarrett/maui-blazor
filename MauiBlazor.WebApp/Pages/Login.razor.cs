using System.ComponentModel.DataAnnotations;
using MauiBlazor.WebApp.Authentication;
using MauiBlazor.WebApp.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace MauiBlazor.WebApp.Pages;

public partial class Login
{
    # region Services

    [Inject]
    private NavigationManager NavigationManager { get; init; } = null!;

    [Inject]
    private IAuthenticationService AuthenticationService { get; init; } = null!;

    # endregion

    # region Properties

    [Required]
    [EmailAddress]
    private string Email { get; set; } = string.Empty;

    # endregion

    protected override void OnInitialized()
    {
        bool isAuthenticated = AuthenticationService.IsAuthenticated();

        if (isAuthenticated)
        {
            NavigationManager.NavigateTo(Routes.Index);
            return;
        }

        base.OnInitialized();
    }

    private void LoginUser()
    {
        // Log in the user
        AuthenticationService.Login(Email);

        // Navigate to the home page
        NavigationManager.NavigateTo(Routes.Index);
    }
}