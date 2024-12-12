using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.Settings;

namespace Gandalan.IDAS.WebApi.Client.Wpf.Dialogs;

public class LoginWindowViewModel_v2 : INotifyPropertyChanged
{
    private string _url;
    private string _userName;
    private string _passwort;

    public event PropertyChangedEventHandler PropertyChanged;

    public string Title => "Neher Cloud - Anmeldung";
    public bool LoginInProgress { get; set; }
    public bool ShowServerSelection { get; set; }

    public bool EnvAlsDefault { get; set; }

    public string Url
    {
        get => _url;
        set
        {
            _url = value;
            //SetOrClearMessage("Url", string.IsNullOrEmpty(_url), "Ungültige Serveradresse");
        }
    }

    /*private static void SetOrClearMessage(string v1, bool v2, string v3)
    {
        // TODO
    }*/

    public string UserName
    {
        get => _userName;
        set
        {
            _userName = value;
            //SetOrClearMessage("UserName", string.IsNullOrEmpty(_userName), "Ungültiger Benutzername");
        }
    }

    public string Passwort
    {
        get => _passwort;
        set
        {
            _passwort = value;
            //SetOrClearMessage("Passwort", string.IsNullOrEmpty(_passwort), "Ungültiges Passwort");
        }
    }

    public bool SaveCredentials { get; set; } = true;

    public IEnumerable<IWebApiConfig> AlleEnvironments { get; private set; }
    public IWebApiConfig ServerEnvironment { get; set; }
    public IEnumerable<IWebApiConfig> LoggedInEnvironments { get; set; }

    public bool ShowLoggedInEnvironments { get; set; }
    public bool ShowLoginFields => !ShowLoggedInEnvironments;
    public string StatusText { get; set; }

    public string PlainPassword { get; set; }
    public bool ShowPlainPassword { get; set; }
    public bool HidePlainPassword => !ShowPlainPassword;
    public string PasswordInputWarning { get; set; }
    public bool ShowPasswordInputWarning { get; set; }

    public LoginWindowViewModel_v2(IWebApiConfig webApiSettings)
    {
        AlleEnvironments = WebApiConfigurations.GetAll();
        LoggedInEnvironments = AlleEnvironments.Where(e => e.AuthToken != null && e.AuthToken.Token != Guid.Empty);
        ShowLoggedInEnvironments = LoggedInEnvironments.AnyOptimized();
        ServerEnvironment = AlleEnvironments.FirstOrDefault(e => e.FriendlyName.Equals(webApiSettings.FriendlyName, StringComparison.InvariantCultureIgnoreCase));

#if DEBUG
        ShowServerSelection = true;
#endif
    }

    /*public LoginWindowViewModel_v2()
    {
#if DEBUG
        ShowServerSelection = true;
#endif
    }*/
}
