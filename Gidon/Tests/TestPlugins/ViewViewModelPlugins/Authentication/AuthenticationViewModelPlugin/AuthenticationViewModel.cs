using NP.DependencyInjection.Attributes;
using NP.Utilities;
using NP.Utilities.BasicServices;
using NP.Utilities.PluginUtils;

namespace AuthenticationViewModelPlugin;

[RegisterType(typeof(IPlugin), resolutionKey: "AuthenticationVM", isSingleton: true)]
public class AuthenticationViewModel : VMBase, IPlugin
{
    [Inject(typeof(IAuthenticationService))]
    // Authentication service that comes from the container
    public IAuthenticationService? TheAuthenticationService
    {
        get;
        private set;
    }

    #region UserName Property
    private string? _userName;

    // notifiable property
    public string? UserName
    {
        get
        {
            return this._userName;
        }
        set
        {
            if (this._userName == value)
            {
                return;
            }

            this._userName = value;
            this.OnPropertyChanged(nameof(UserName));
            this.OnPropertyChanged(nameof(CanAuthenticate));
        }
    }
    #endregion UserName Property


    #region Password Property
    private string? _password;

    // notifiable property
    public string? Password
    {
        get
        {
            return this._password;
        }
        set
        {
            if (this._password == value)
            {
                return;
            }

            this._password = value;
            this.OnPropertyChanged(nameof(Password));
            this.OnPropertyChanged(nameof(CanAuthenticate));
        }
    }
    #endregion Password Property

    // change notification fires when either UserName or Password change
    public bool CanAuthenticate =>
        (!string.IsNullOrEmpty(UserName)) && (!string.IsNullOrEmpty(Password));

    // method to call in order to try to authenticate a user
    public void Authenticate()
    {
        TheAuthenticationService?.Authenticate(UserName, Password);

        OnPropertyChanged(nameof(IsAuthenticated));
    }

    // method to exit the application
    public void ExitApplication()
    {
        Environment.Exit(0);
    }

    // IsAuthenticated property 
    // whose change notification fires within Authenticate() method
    public bool IsAuthenticated => TheAuthenticationService?.IsAuthenticated ?? false;
}
