namespace Gandalan.IDAS.WebApi.DTO;

public interface ILayoutBelegDruck
{
    #region Properties
    #region FirmenLogo
    bool ShowLogo { get; set; }
    int LogoPositionX { get; set; }
    int LogoPositionY { get; set; }
    int LogoSizeWidth { get; set; }
    int LogoSizeHeight { get; set; }
    #endregion

    #region BelegTabelle
    int TabellePositionX { get; set; }
    int TabellePositionY_Seite1 { get; set; }
    int TabellePositionY_AbSeite2 { get; set; }
    int TabelleHoehe_Seite1 { get; set; }
    int TabelleHoehe_AbSeite2 { get; set; }
    int TabelleBreite { get; set; }
    #endregion

    int BriefkopfPositionX { get; set; }
    int BriefkopfPositionY { get; set; }
    int FusszeilePositionX { get; set; }
    int FusszeilePositionY { get; set; }

    int SeitenrandLinks { get; set; }
    int SeitenrandRechts { get; set; }
    int SeitenrandUnten { get; set; }
    int SeitenrandOben { get; set; }

    int KommissionPositionY { get; set; }

    int SeitenzaehlerPositionX { get; set; }
    int SeitenzaehlerPositionY_Seite1 { get; set; }
    int SeitenzaehlerPositionY_AbSeite2 { get; set; }

    int AnschriftPositionX { get; set; }
    int AnschriftPositionY { get; set; }

    int MicroAnschriftPositionX { get; set; }
    int MicroAnschriftPositionY { get; set; }
    bool ShowMicroAnschrift { get; set; }

    int BelegKopfPositionX { get; set; }  //Belegnummer/Belegdatum/Kundennr. e.c.t
    int BelegKopfPositionY { get; set; }
    int BelegKopfPositionY_AbSeite2 { get; set; }

    bool ShowHistorie { get; set; }
    bool IsBlankoDruck { get; set; } //Sollen Firmendaten (Briefkopf/Logo/e.c.t)  ausgegeben werden?
    bool IsBestellfixBeleg { get; set; }
    bool IsDiagnoseDruck { get; set; }

    #endregion

}