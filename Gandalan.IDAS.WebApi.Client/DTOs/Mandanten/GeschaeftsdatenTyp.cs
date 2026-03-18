namespace Gandalan.IDAS.Data.IBOS3.Mandanten;

public enum GeschaeftsdatenTyp
{
    Allgemein = 0,

    /// <summary>Eingetragener Firmensitz (relevant als Rechnungssteller in ZUGFeRD)</summary>
    Firmensitz = 1,

    /// <summary>Abweichende Rechnungsanschrift</summary>
    Rechnungsanschrift = 2,

    /// <summary>Lieferanschrift / Wareneingang</summary>
    Lieferanschrift = 3,

    /// <summary>Postanschrift / Briefkastenadresse</summary>
    Postanschrift = 4,

    /// <summary>Niederlassung / Zweigstelle</summary>
    Niederlassung = 5,

    /// <summary>Lageradresse / Warenlager</summary>
    Lageradresse = 6,

    /// <summary>Sonstige Adresse</summary>
    Sonstige = 99,
}
