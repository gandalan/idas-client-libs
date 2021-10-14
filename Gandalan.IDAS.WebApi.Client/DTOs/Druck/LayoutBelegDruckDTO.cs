using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class LayoutBelegDruckDTO : ILayoutBelegDruck
    {
        #region public Properties
        #region FirmenLogo
        public bool ShowLogo { get; set; }
        public int LogoPositionX { get; set; }
        public int LogoPositionY { get; set; }
        public int LogoSizeWidth { get; set; }
        public int LogoSizeHeight { get; set; }
        #endregion

        #region BelegTabelle
        public int TabellePositionX { get; set; }
        public int TabellePositionY_Seite1 { get; set; }
        public int TabellePositionY_AbSeite2 { get; set; }
        public int TabelleHoehe_Seite1 { get; set; }
        public int TabelleHoehe_AbSeite2 { get; set; }
        public int TabelleBreite { get; set; }
        #endregion

        public int BriefkopfPositionX { get; set; }
        public int BriefkopfPositionY { get; set; }
        public int FusszeilePositionX { get; set; }
        public int FusszeilePositionY { get; set; }

        public int SeitenrandLinks { get; set; }
        public int SeitenrandRechts { get; set; }
        public int SeitenrandUnten { get; set; }
        public int SeitenrandOben { get; set; }

        public int KommissionPositionY { get; set; }

        public int SeitenzaehlerPositionX { get; set; }
        public int SeitenzaehlerPositionY_Seite1 { get; set; }
        public int SeitenzaehlerPositionY_AbSeite2 { get; set; }

        public int AnschriftPositionX { get; set; }
        public int AnschriftPositionY { get; set; }
        public int MicroAnschriftPositionX { get; set; }
        public int MicroAnschriftPositionY { get; set; }
        public bool ShowMicroAnschrift { get; set; }

        public int BelegkopfPositionX { get; set; }  //Belegnummer/Belegdatum/Kundennr. e.c.t
        public int BelegkopfPositionY { get; set; }
        public int BelegKopfPositionY_AbSeite2 { get; set; }

        public bool ShowHistorie { get; set; }
        public bool IsBlankoDruck { get; set; } //Sollen Firmendaten (Briefkopf/Logo/e.c.t)  ausgegeben werden?
        [JsonIgnore]
        public bool IsBestellfixBeleg { get; set; }
        [JsonIgnore]
        public bool IsDiagnoseDruck { get; set; }
        #endregion

        public LayoutBelegDruckDTO()
        { }
    }
}