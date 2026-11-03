namespace Gandalan.IDAS.WebApi.Client.Contracts.Report;

public interface IEtikettenPrintLayoutSettings
{
    string DruckerName { get; set; }
    IPapierFormat Papierformat { get; }
    double LabelWidthMm { get; set; }
    double LabelHeightMm { get; set; }
    int CountHorizontal { get; set; }
    int CountVertikal { get; set; }
    double MarginHorizontalMm { get; set; }
    double MarginVertikalMm { get; set; }
    double FirstLabelXMm { get; set; }
    double FirstLabelYMm { get; set; }
    double IMarginLeftMm { get; set; }
    double IMarginRightMm { get; set; }
    double IMarginTopMm { get; set; }
    double IMarginBottomMm { get; set; }
    bool Landscape { get; set; }
    bool PrintFrame { get; set; }
    string HDevModeData { get; set; }
    int Dpi { get; set; }
    double ContentOffsetXMm { get; set; }
    double ContentOffsetYMm { get; set; }
    string PaperSourceName { get; set; }

    /// <summary>
    /// Internes Flag (nicht in der UI sichtbar): Zeigt an, ob der Benutzer die Etiketten-Druckeinstellungen
    /// geprüft hat und sie aktuell sind. Wird beim Speichern der Einstellungen auf <c>true</c> gesetzt.
    /// Initial (auch bei bereits vorhandenen Einstellungen) <c>false</c>, damit der Etikettendruck erst nach
    /// einer Prüfung durch den Benutzer möglich ist.
    /// </summary>
    bool SettingsGeprueft { get; set; }
}
