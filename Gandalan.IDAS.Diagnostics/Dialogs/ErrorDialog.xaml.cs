using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Gandalan.Client.Contracts.AppServices;
using Gandalan.Client.Contracts.DataServices;
using Gandalan.Client.Contracts.UIServices;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.Diagnostics.Utils;
using Gandalan.IDAS.Logging;
using Gandalan.IDAS.Web;
using PropertyChanged;

namespace Gandalan.IDAS.Diagnostics.Dialogs;

/// <summary>
/// Interaction logic for ErrorDialog.xaml
/// </summary>
public partial class ErrorDialog : Window, IErrorDialog, INotifyPropertyChanged
{
    private const string Seperator = "------------------------------------------------------------------";
    private readonly IInternalMailService _internalMailService;
    private readonly IWebApiConfig _apiConfig;
    private readonly IApplicationConfig _applicationConfig;

    /// <inheritdoc />
    public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    /// Die aktuelle Exception zum aktuellen Fehler
    /// </summary>
    public Exception Exception { get; private set; }
    /// <summary>
    /// Nachricht zum aktuellen Fehler
    /// </summary>
    public string Message { get; private set; }
    /// <summary>
    /// Details (StackTrace, etc.) zum aktuellen Fehler
    /// </summary>
    public string DetailsString { get; private set; }
    /// <summary>
    /// Gibt an, ob der Fehler fatal ist (Programm muss beendet werden)
    /// </summary>
    public bool IsFatal { get; private set; }
    /// <summary>
    /// Gibt an, ob nach dem Fehler weitergemacht werden kann. (Inverse von <see cref="IsFatal"/>)
    /// </summary>
    [DependsOn(nameof(IsFatal))]
    public bool CanContinue => !IsFatal;
    /// <summary>
    /// Gibt an, ob ein Fehlerbericht gesendet werden sollte.
    /// </summary>
    public bool ShouldSend { get; set; }
    /// <summary>
    /// Hinweis des Nutzers zum aktuellen Fehler.
    /// </summary>
    public string Hinweis { get; set; }

    /// <summary>
    /// Konstruktor
    /// </summary>
    /// <param name="internalMailService"><see cref="IInternalMailService"/> zum Senden der Fehlermail</param>
    /// <param name="apiConfig"><see cref="IWebApiConfig"/> des Nutzers</param>
    /// <param name="applicationConfig"><see cref="IApplicationConfig"/> der Anwendung</param>
    public ErrorDialog(IInternalMailService internalMailService, IWebApiConfig apiConfig, IApplicationConfig applicationConfig)
    {
        DataContext = this;
        InitializeComponent();
        Owner = Application.Current.MainWindow != this ? Application.Current.MainWindow : null;
        Topmost = true;
        _internalMailService = internalMailService;
        _apiConfig = apiConfig;
        _applicationConfig = applicationConfig;
    }

    /// <inheritdoc/>
    public bool ShowError(string title = null, string message = null, Exception exception = null, bool isFatal = false)
    {
        Message = message;
        Exception = exception;
        Title = title;
        Hinweis = string.Empty;
        ShouldSend = false;
        IsFatal = isFatal;
        return ShowDialog() ?? false;
    }

    private void detailButtonClick(object sender, RoutedEventArgs e)
    {
        DetailPanel.Visibility = DetailPanel.Visibility == Visibility.Collapsed
            ? Visibility.Visible
            : Visibility.Collapsed;
        DetailButton.Content = DetailPanel.Visibility == Visibility.Visible ? "<<" : "Details >>";
    }

    private void beendenButtonClick(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
        Close();
    }

    private void weiterButtonClick(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }

    private void dialogLoaded(object sender, RoutedEventArgs e)
    {
        buildDetails();
    }

    private void buildDetails()
    {
        var version = Assembly.GetEntryAssembly()?.GetName().Version.ToString();
        var userName = _apiConfig.UserName;
        var server = new Uri(_apiConfig.Url).Host;
        var currentEnvironment = _apiConfig.FriendlyName;
        var mandantGuid = _apiConfig.AuthToken?.MandantGuid ?? Guid.Empty;
        var userGuid = _apiConfig.AuthToken?.Benutzer?.BenutzerGuid ?? Guid.Empty;

        var sb = new StringBuilder();
        sb.AppendLine($"Fehlerbericht / {DateTime.Now.ToString(CultureInfo.InvariantCulture)}");
        sb.AppendLine($"Windows-Rechnername: {Environment.MachineName}");
        sb.AppendLine($"Windows-Benutzer: {Environment.UserName}");
        sb.AppendLine($"Windows-Domäne: {Environment.UserDomainName}");
        sb.AppendLine($"Windows-Version: {DiagnosticsUtils.GetOSVersion()}");
        sb.AppendLine(Seperator);

        sb.AppendLine($"Programmversion: {_applicationConfig.ApplicationName} {version}");
        sb.AppendLine($"Server: {server}");
        sb.AppendLine($"User: {userName}");
        sb.AppendLine($"Umgebung: {currentEnvironment}");
        sb.AppendLine($"Mandant Guid: {mandantGuid}");
        sb.AppendLine($"Benutzer Guid: {userGuid}");
        sb.AppendLine(Seperator);

        if (AddonRegistry.AddonPackages.Count > 0)
        {
            sb.AppendLine("Add-Ons:");
            AddonRegistry.AddonPackages.ForEach(x => sb.AppendLine(x));
            sb.AppendLine(Seperator);
        }

        sb.AppendLine();

        if (Exception == null)
        {
            sb.AppendLine(Message);
        }

        if (Exception != null)
        {
            sb.AppendLine(buildDump(Exception));
        }

        DetailsString = sb.ToString();
    }

    private static string buildDump(Exception ex)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Art des Fehlers: {ex.GetType().FullName}");
        sb.AppendLine($"Meldung: {ex.Message}");
        sb.AppendLine($"Quelle: {ex.Source}");

        if (ex is ApiException apiException && !string.IsNullOrEmpty(apiException.ExceptionString))
        {
            sb.AppendLine("Response Exception Data:");
            sb.AppendLine($"{apiException.ExceptionString}");
        }

        if (ex.Data.Count > 0)
        {
            sb.AppendLine("Exception Data:");

            var dataDetails = new StringBuilder();
            foreach (DictionaryEntry entry in ex.Data)
            {
                dataDetails.AppendLine($"{entry.Key}: {entry.Value}");
            }

            sb.AppendLine($"{dataDetails}");
        }

        sb.AppendLine("Stacktrace:");
        sb.AppendLine(ex.StackTrace);
        sb.AppendLine();

        if (ex.InnerException != null)
        {
            sb.AppendLine(buildDump(ex.InnerException));
        }

        return sb.ToString();
    }

    private async void DialogClosing(object sender, CancelEventArgs e)
    {
        if (Exception != null && ShouldSend)
        {
            if (IsFatal)
            {
                //In the fatal case we can't use async as the process will terminate before sending the report so we have to block
                Task.Run(sendReport).GetAwaiter().GetResult();
            }
            else
            {
                await sendReport();
            }
        }
    }

    private void folderOpenButtonClick(object sender, RoutedEventArgs e)
    {
        Process.Start("explorer", $"/e,{Logger.LogDateiPfad}");
    }

    private async Task sendReport()
    {
        try
        {
            L.Info("Sending error report email");
            var version = Assembly.GetEntryAssembly()?.GetName().Version.ToString();
            var name = Assembly.GetEntryAssembly()?.GetName().Name;
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Fehlerbericht von {Environment.UserName}@{Environment.UserDomainName}");
            if (!string.IsNullOrWhiteSpace(Hinweis))
            {
                stringBuilder.Append("Hinweis des Nutzers: ");
                stringBuilder.AppendLine(Hinweis);
            }
            stringBuilder.AppendLine(Seperator);
            stringBuilder.AppendLine($"Version: {version}");
            stringBuilder.AppendLine($"Name: {name}");
            stringBuilder.AppendLine(Seperator);
            stringBuilder.AppendLine(DetailsString);

            var inhalt = stringBuilder.ToString();

            var zipFile = await DiagnosticsUtils.CreateDiagnoseZipFile();

            await _internalMailService.SendMailAsync(_applicationConfig.ErrorReportingMail, _applicationConfig.ErrorReportingMail, $"[{_apiConfig.FriendlyName}] Fehlermeldung", inhalt, [zipFile]);
            MessageBox.Show("Vielen Dank, Ihr Fehlerbericht wurde gesendet. Wir bemühen uns um eine schnelle Lösung. In dringenden Fällen wenden Sie sich bitte an die Gandalan Hotline.",
                "Gesendet", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        catch (Exception ex)
        {
            L.Fehler(ex, "Cannot send error report email");
            MessageBox.Show("Leider konnte der Fehlerbericht nicht per E-Mail verschickt werden. Wenden Sie sich bitte an die Gandalan Hotline.",
                "Sendefehler", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
