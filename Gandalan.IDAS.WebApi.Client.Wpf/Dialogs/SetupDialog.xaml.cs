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
using Gandalan.IDAS.WebApi.Client.BusinessRoutinen;
using Gandalan.IDAS.WebApi.Client.Settings;
using System.ComponentModel;
using Gandalan.IDAS.Web;
using Gandalan.IDAS.WebApi.Client;

namespace Gandalan.Client.Common.Dialogs
{
    /// <summary>
    /// Interaction logic for SetupDialog.xaml
    /// </summary>
    public partial class SetupDialog : Window, INotifyPropertyChanged
    {
        public string Email { get; set; }
        public WebApiSettings Settings { get; set; }

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
            InProgress = true;
            AppWebRoutinen service = new AppWebRoutinen(Settings);
            string serviceResult;
            try
            {
                serviceResult = await Task<string>.Factory.StartNew(() => service.AktiviereMandant(Email?.Trim()));
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
