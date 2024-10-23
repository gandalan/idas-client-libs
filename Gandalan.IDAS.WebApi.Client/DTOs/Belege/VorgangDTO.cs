using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Gandalan.IDAS.WebApi.Util;
using Newtonsoft.Json;

namespace Gandalan.IDAS.WebApi.DTO;

public class VorgangDTO : IDTOWithApplicationSpecificProperties, INotifyPropertyChanged
{
    /// <summary>
    /// Eindeutige GUID
    /// </summary>
    public Guid VorgangGuid { get; set; }

    /// <summary>
    /// Sichtbare Vorgangsnummer/zur Info für Kunden usw.
    /// </summary>
    public long VorgangsNummer { get; set; }

    /// <summary>
    /// Kundennummer (aus Kontakt-Objekt)
    /// </summary>
    public string KundenNummer { get; set; }

    /// <summary>
    /// End- oder Firmenkunde (aus Kontakt-Objekt)
    /// </summary>
    public bool IstEndkunde { get; set; }

    /// <summary>
    /// Standard-Kommission des Vorgangs
    /// </summary>
    public string Kommission { get; set; }

    /// <summary>
    /// Kommission2 des Vorgangs
    /// </summary>
    public string Kommission2 { get; set; }

    /// <summary>
    /// Erstelldatum des Vorgangs
    /// </summary>
    public DateTime ErstellDatum { get; set; }

    /// <summary>
    /// Letztes Änderungsdatum des Vorgangs
    /// </summary>
    public DateTime AenderungsDatum { get; set; }

    /// <summary>
    /// Liste und Daten der Belege zu diesem Vorgang
    /// </summary>
    public virtual IList<BelegDTO> Belege { get; set; }

    /// <summary>
    /// Liste und Daten der Postionen in diesem Vorgang
    /// </summary>
    public virtual IList<BelegPositionDTO> Positionen { get; set; }

    public virtual IList<Guid> Nachrichten { get; set; }
    public virtual IList<VorgangHistorieDTO> Historie { get; set; }

    /// <summary>
    /// Ersteller-/Besitzerbenutzer des Vorgangs
    /// </summary>
    public virtual BenutzerDTO Besitzer { get; set; }

    /// <summary>
    /// Kontakt für diese Vorgang (Dummy-Kontakt, falls noch nicht erfasst)
    /// </summary>
    public virtual KontaktDTO Kunde { get; set; }

    public Guid KundeGuid { get; set; }

    public string AktuellerStatus { get; set; }

    /// <summary>
    /// Gültige Werte: "NichtFreigegeben", "Freigegeben", "Abgerechnet"
    /// </summary>
    public string FakturaKennzeichen { get; set; }

    public string TextStatus { get; set; }
    public bool IstTestbeleg { get; set; }
    public string WaehrungsSymbol { get; set; }
    public decimal WaehrungsFaktor { get; set; }
    public bool IstBrutto { get; set; }
    public Dictionary<string, PropertyValueCollection> ApplicationSpecificProperties { get; set; }
    public bool IstZustimmungErteilt { get; set; }

    public string InterneNotiz { get; set; }
    public string BemerkungFuerKunde { get; set; }
    public Guid OriginalVorgangGuid { get; set; }
    public Guid OriginalMandantGuid { get; set; }
    public long? OriginalVorgangsNummer { get; set; }
    public Guid OriginalAppGuid { get; set; }
    public bool InnergemeinschaftlichOhneMwSt { get; set; }
    public Guid ZielVorgangGuid { get; set; }

    public VorgangDTO()
    {
        Belege = [];
        Positionen = [];
        Nachrichten = [];
        Historie = [];
        ErstellDatum = DateTime.UtcNow;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public void Dump()
    {
        File.WriteAllText($@"c:\temp\dumps\dump-{VorgangsNummer}.json", JsonConvert.SerializeObject(this, Formatting.Indented));
    }
}
