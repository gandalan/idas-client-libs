using Gandalan.IDAS.WebApi.Client;
using Gandalan.IDAS.WebApi.Client.Settings;
using System.ComponentModel;
using System.Windows;

namespace Gandalan.Client.Common.Dialogs
{
    /// <summary>
    /// Interaction logic for PasswordResetDialog.xaml
    /// </summary>
    public partial class PasswordResetDialog : Window, INotifyPropertyChanged
    {
        public string Email { get; set; }
        public bool InProgress { get; set; } = false;
        public WebApiSettings Settings { get; set; }

        public PasswordResetDialog()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = this;
        }

        private async void passwordZuruecksetzen_Click(object sender, RoutedEventArgs e)
        {
            InProgress = true;

            if (string.IsNullOrEmpty(Email))
            {
                MessageBox.Show("Geben Sie im Feld \"E-Mail\" Ihre E-Mail Adresse ein und klicken Sie diesen Button erneut, um sich ein neues Passwort zusenden zu lassen",
                     "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            BenutzerWebRoutinen service = new BenutzerWebRoutinen(Settings);
            try
            {
                var info = await service.PasswortResetAsync(Email);

                MessageBox.Show("Passwort erfolgreich zurückgesetzt.", "Info vom System", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Info vom System", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            finally
            {
                InProgress = false;
            }
            
            DialogResult = true;
            Close();
        }

        private void abbrechenButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
