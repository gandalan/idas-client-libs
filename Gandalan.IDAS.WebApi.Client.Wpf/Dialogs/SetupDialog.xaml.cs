using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.Web;
using Gandalan.IDAS.WebApi.Client.BusinessRoutinen;
using System.ComponentModel;
using System.Windows;

namespace Gandalan.IDAS.WebApi.Client.Wpf.Dialogs
{
    /// <summary>
    /// Interaction logic for SetupDialog.xaml
    /// </summary>
    public partial class SetupDialog : Window, INotifyPropertyChanged
    {
        public string Email { get; set; }
        public IWebApiConfig Settings { get; set; }

        public bool InProgress { get; set; } = false;

        public SetupDialog()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = this;
        }

        private async void speichernButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Email))
            {
                MessageBox.Show("Geben Sie im Feld \"E-Mail\" Eine gültige E-Mail Adresse ein und klicken Sie diesen Button erneut, um den Produzenten zu aktivieren.",
                    "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            InProgress = true;
            var service = new AppWebRoutinen(Settings);
            try
            {
                await service.AktiviereMandantAsync(Email.Trim());
            }
            catch (ApiException)
            {
                return;
            }
            finally
            {
                InProgress = false;
            }

            MessageBox.Show("Produzent wurde erfolgreich eingerichtet.", "Info vom System", MessageBoxButton.OK, MessageBoxImage.Information);
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
