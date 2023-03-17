using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.Logging;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Gandalan.IDAS.WebApi.Client.Wpf.Dialogs
{
    /// <summary>
    /// Interaktionslogik für LoginWindow_v2.xaml
    /// </summary>
    public partial class LoginWindow_v2 : Window
    {
        private IWebApiConfig _webApiSettings;
        private LoginWindowViewModel_v2 _viewModel;
        private string _statusText;
        private readonly Logger _logger;

        //public LoginWindow_v2()
        //{
        //    InitializeComponent();
        //}

        public LoginWindow_v2(IWebApiConfig webApiSettings)
        {
            _webApiSettings = webApiSettings;
            _viewModel = new LoginWindowViewModel_v2(_webApiSettings);
            if (Application.Current != null && Application.Current.Windows != null)
            {
                foreach (var window in Application.Current.Windows)
                    if (window is Window wpfWindow && wpfWindow.IsVisible)
                    {
                        Owner = wpfWindow;
                        break;
                    }

            }
            InitializeComponent();
            DataContext = _viewModel;

            _logger = Logger.GetInstance();
        }

        //public IWebApiConfig Show(IWebApiConfig webApiSettings)
        //{
        //    _webApiSettings = webApiSettings;
        //    _viewModel = new LoginWindowViewModel_v2();
            
        //    ShowDialog();

        //    return _webApiSettings;
        //}

        private void switchToLoginFields(object sender, RoutedEventArgs e)
        {
            _viewModel.ShowLoggedInEnvironments = !_viewModel.ShowLoggedInEnvironments;
        }

        private async void useAuthTokenButtonClick(object sender, RoutedEventArgs e)
        {
            _viewModel.LoginInProgress = true;
            _viewModel.StatusText = null;
            var settings = (sender as Button)?.Tag as IWebApiConfig;
            if (settings != null && await testConnection(settings))
            {
                _webApiSettings.CopyToThis(settings);
                DialogResult = true;
                Close();

                _logger.Log($"Connected to backend URL: {settings.Url}");
            }
            _viewModel.LoginInProgress = false;
            _viewModel.StatusText = "Fehler: " + _statusText;

            if (_statusText == "Invalid password" || _statusText == "Error")
            {
                _viewModel.ShowLoggedInEnvironments = false;
                _viewModel.UserName = settings.UserName;
            }
            else if (_statusText != null &&
                       !_statusText.Contains("Invalid user") &&
                       !_statusText.Contains("Login Exception")) // Do not log exception twice
            {
                _logger.Log($"URL: {settings.Url}: {_statusText}", LogLevel.Fehler);
            }
        }

        private async void anmeldenButtonClick(object sender, RoutedEventArgs e)
        {
            _viewModel.LoginInProgress = true;
            _viewModel.StatusText = null;
            // reflect change to env as from selected dropdown
            _webApiSettings.CopyToThis(_viewModel.ServerEnvironment);
            _webApiSettings.UserName = _viewModel.UserName;
            _webApiSettings.Passwort = passwordBox.Password;
            _webApiSettings.AuthToken = null;

            if (await testConnection(_webApiSettings))
            {
                if (_viewModel.SaveCredentials)
                    _webApiSettings.Save();
                DialogResult = true;                
                Close();

                _logger.Log($"Connected to backend URL: {_webApiSettings.Url}");
            }
            _viewModel.LoginInProgress = false;
            _viewModel.StatusText= "Fehler: " + _statusText;

            if (_statusText != null &&
                _statusText != "Invalid password" &&
                !_statusText.Contains("Invalid user") &&
                !_statusText.Contains("Login Exception")) // Do not log exception twice
            {
                _logger.Log($"URL: {_webApiSettings.Url}: {_statusText}", LogLevel.Fehler);
            }
        }

        private async Task<bool> testConnection(IWebApiConfig settings)
        {
            WebRoutinenBase wrb = new WebRoutinenBase(settings);
            try
            {
                if (settings.AuthToken != null)
                {
                    var refreshResult = wrb.RefreshToken(settings.AuthToken.Token);
                    if (refreshResult != null)
                    {
                        settings.AuthToken = refreshResult;
                        return true;
                    }
                }
                
                var result = await wrb.LoginAsync();
               
                _statusText = wrb.Status;
                if (_statusText.Contains("<title>"))
                    _statusText = internalStripHtml(_statusText);

                if (result)
                    settings.AuthToken = wrb.AuthToken;
                return result;
            }
            catch (Exception ex)
            {
                _statusText = ex.Message;
                var msg = $"Login Exception ({ex.GetType().Name}) Message: {ex.Message}{Environment.NewLine}Stacktrace: {ex.StackTrace}";
                _logger.Log(msg, LogLevel.Fehler);

                return false;
            }
        }

        private string internalStripHtml(string htmlString)
        {
            var result = htmlString;
            if (result.ToLower().Contains("<title>") && result.ToLower().Contains("<title>"))
            {
                var start = result.IndexOf("<title>") + 7;
                var end = result.IndexOf("</title>");
                result = $"Interner Serverfehler (\"{result.Substring(start, end - start)}\"). Bitte versuchen Sie es zu einem späteren Zeitpunkt erneut.";
            }
            return result;
        }

        private void abbrechenButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void pwResetButton_Click(object sender, RoutedEventArgs e)
        {
            var pwVergessenDialog = new PasswordResetDialog();
            pwVergessenDialog.Email = _viewModel.UserName;
            pwVergessenDialog.Settings = _viewModel.ServerEnvironment;
            pwVergessenDialog.Owner = Application.Current.MainWindow;
            pwVergessenDialog.ShowDialog();
        }

        private void einrichtenButton_Click(object sender, RoutedEventArgs e)
        {
            var setupDialog = new SetupDialog();
            setupDialog.Settings = _viewModel.ServerEnvironment;
            setupDialog.Owner = Application.Current.MainWindow;
            setupDialog.ShowDialog();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.E) && Keyboard.Modifiers.HasFlag(ModifierKeys.Control) && _viewModel != null)
            {
                _viewModel.ShowServerSelection = !_viewModel.ShowServerSelection;
            }
        }
    }
}
