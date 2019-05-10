using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class KatalogArtikelDTO
    {
        public Guid KatalogArtikelGuid { get; set; }
        public string KatalogNummer { get; set; }
        public string Bezeichnung { get; set; }
        /// <summary>
        /// Einer der Werte aus der KatalogArtikelArt-Enum
        /// </summary>
        public string Art { get; set; }
        public Guid WarenGruppeGuid { get; set; }
        public string ImageFileName { get; set; }
        public string Einheit { get; set; }
        
        // Regeln für die Bestellung
        public bool MengeMussGanzZahligSein { get; set; }
        public bool NurAlsVEBestellbar { get; set; }

        // Eigenschaften
        public bool IstZuschnittArtikel { get; set; }
        public bool IstBestellfixSonderfarbBestellbar { get; set; }
        public bool NichtRabattfaehig { get; set; }
        public bool IstEKPArtikel { get; set; }
        public bool IstGewebeArtikel { get; set; }
        public decimal GewichtInKg { get; set; } // Gewicht pro Mengeneinheit
        public Guid MaterialGuid { get; set; }
        public IList<KatalogArtikelFarbZuordnungDTO> MoeglicheFarben { get; set; }

        /// <summary>
        /// Für Art = ProfilArtikel
        /// </summary>
        public int ProfilLaengeMM { get; set; }

        public bool Freigabe_IBOS { get; set; }
        public bool Freigabe_BestellFix { get; set; }
        public bool Freigabe_ARTOS { get; set; }

        /// <summary>
        /// Preis des Artikels (pro VE?)
        /// </summary>
        public decimal  Preis { get; set; }
        public decimal StaffelPreis { get; set; }
        public decimal StaffelMenge { get; set; }
        public decimal VEMenge { get; set; }
        public decimal VEPreis { get; set; }

        public string Status { get; set; }
        public DateTime? GueltigAb { get; set; }
        public DateTime? GueltigBis { get; set; }
        /// <summary>
        /// Mögliche Ersatzartikel für diesen Artikel
        /// </summary>
        public List<Guid> ErsatzArtikel { get; set; }
        /// <summary>
        /// Internes Feld - mappt den Machine/UI-Bezeichner auf die Frontend-Anzeige
        /// </summary>
        public string FrontendLogik { get; set; }
        /// <summary>
        /// Für Art = FertigElementArtikel
        /// </summary>
        public Guid VarianteGuid { get; set; }
        public DateTime ChangedDate { get; set; }
        public long Version { get; set; }
        public bool IstTechnischerArtikel { get; set; }
        public decimal BasisBestellMenge { get; set; }

        public KatalogArtikelDTO()
        {
            MoeglicheFarben = new ObservableCollection<KatalogArtikelFarbZuordnungDTO>();
        }
    }
}
