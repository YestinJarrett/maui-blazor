using System.Security.Claims;

namespace MauiBlazor.WebApp.Authentication;

public interface IAuthenticationService
{
    // Returns the current user or an anonymous user if no user is signed in
    ClaimsPrincipal CurrentUser { get; }

    // Event that is triggered when the user changes
    event Action<ClaimsPrincipal>? UserChangedEvent;
    
    /// <summary>
    /// Logs in the user with the provided email.
    /// </summary>
    /// <param name="email">The email of the user to log in.</param>
    void Login(string email);

    /// <summary>
    /// Logs out the currently authenticated user.
    /// </summary>
    void Logout();

    /// <summary>
    /// Checks whether the user is authenticated or not.
    /// </summary>
    /// <returns>A boolean value indicating whether the user is authenticated.</returns>
    bool IsAuthenticated();
}