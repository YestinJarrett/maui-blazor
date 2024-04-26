using System.Security.Claims;

namespace MauiBlazor.WebApp.Authentication;

public class LocalAuthenticationService : IAuthenticationService
{
    private ClaimsPrincipal? _currentUser;
    
    // Returns the current user or an anonymous user if no user is signed in
    public ClaimsPrincipal CurrentUser
    {
        get => _currentUser ?? new ClaimsPrincipal();
        private set
        {
            _currentUser = value;

            UserChangedEvent?.Invoke(_currentUser);
        }
    }
    
    // Event that is triggered when the user changes
    public event Action<ClaimsPrincipal>? UserChangedEvent;
    
    public void Login(string email)
    {
        // Set the current user to the user with the provided email
        CurrentUser = new ClaimsPrincipal(new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, email),
        }, "LocalAccount"));
    }

    public void Logout()
    {
        // Set the current user to an anonymous user
        CurrentUser = new ClaimsPrincipal();
    }

    public bool IsAuthenticated()
    {
        return _currentUser?.Identity?.IsAuthenticated ?? false;
    }
}