using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Gandalan.Client.Common.Dialogs;
using Gandalan.IDAS.WebApi.Client;
using Gandalan.IDAS.WebApi.Client.Settings;

namespace Gandalan.Controls.WPF.Dialogs
{
    /// <summary>
    /// Interaktionslogik für LoginWindow_v2.xaml
    /// </summary>
    public partial class LoginWindow_v2 : Window
    {
        private WebApiSettings _webApiSettings;
        private LoginWindowViewModel_v2 _viewModel;
        private string _statusText;

        public LoginWindow_v2()
        {
            InitializeComponent();
        }

        public LoginWindow_v2(WebApiSettings webApiSettings)
        {
            _webApiSettings = webApiSettings;
            _viewModel = new LoginWindowViewModel_v2(_webApiSettings);

            foreach (var window in Application.Current.Windows)
                if (window is Window wpfWindow && wpfWindow.IsVisible)
                {
                    Owner = wpfWindow;
                    break;
                }

            InitializeComponent();
            DataContext = _viewModel;
        }

        public void Show(WebApiSettings webApiSettings)
        {
            _webApiSettings = webApiSettings;
            ShowDialog();
        }

        private void switchToLoginFields(object sender, RoutedEventArgs e)
        {
            _viewModel.ShowLoggedInEnvironments = !_viewModel.ShowLoggedInEnvironments;
        }

        private async void useAuthTokenButtonClick(object sender, RoutedEventArgs e)
        {
            _viewModel.LoginInProgress = true;
            _viewModel.StatusText = null;
            var settings = (sender as Button)?.Tag as WebApiSettings;
            if (settings != null && await testConnection(settings))
            {
                _webApiSettings.CopyToThis(settings);
                DialogResult = true;
                Close();
            }
            _viewModel.LoginInProgress = false;
            _viewModel.StatusText = "Fehler: " + _statusText;

            if (_statusText == "Invalid password")
            {
                _viewModel.ShowLoggedInEnvironments = false;
                _viewModel.UserName = settings.UserName;
            }
        }

        private async void anmeldenButtonClick(object sender, RoutedEventArgs e)
        {
            _viewModel.LoginInProgress = true;
            _viewModel.StatusText = null;
            _webApiSettings.Url = _viewModel.ServerEnvironment.Url;
            _webApiSettings.UserName = _viewModel.UserName;
            _webApiSettings.Passwort = passwordBox.Password;
            _webApiSettings.FriendlyName = _viewModel.ServerEnvironment.FriendlyName;
            _webApiSettings.AuthToken = null;


            if (await testConnection(_webApiSettings))
            {
                if (_viewModel.SaveCredentials)
                    _webApiSettings.Save();
                DialogResult = true;                
                Close();
            }
            _viewModel.LoginInProgress = false;
            _viewModel.StatusText= "Fehler: " + _statusText;
        }

        private async Task<bool> testConnection(WebApiSettings settings)
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
            catch (Exception e)
            {
                _statusText = e.Message;
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
            pwVergessenDialog.ShowDialog();
        }

        private void einrichtenButton_Click(object sender, RoutedEventArgs e)
        {
            var setupDialog = new SetupDialog();
            setupDialog.Settings = _viewModel.ServerEnvironment;
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
