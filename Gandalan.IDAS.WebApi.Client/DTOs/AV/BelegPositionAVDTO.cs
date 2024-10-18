using System;

namespace Gandalan.IDAS.WebApi.DTO;

public class BelegPositionAVDTO
{
    public Guid BelegPositionAVGuid { get; set; }
    public Guid SerieGuid { get; set; }

    public Guid BelegPositionGuid { get; set; }
    public Guid VorgangGuid { get; set; }
    public Guid BelegGuid { get; set; }

    public DateTime Bereitgestellt { get; set; }
    public DateTime? Berechnet { get; set; }
    public bool IstBerechnet { get; set; }
    /// <summary>
    /// Counter for how often the calculation of this AVBelegPosition has failed.
    /// Gets reset to 0 when calculation was successful or re-calculation was triggered (updated position or manually).
    /// </summary>
    public int FailedCalculationsCount { get; set; }
    public bool IstProduziert { get; set; }
    public bool IstGeloescht { get; set; }
    public bool IstStorniert { get; set; }
    public bool HatSonderwuensche { get; set; }
    public bool CheckGesamtbedarf { get; set; }
    public string SonderwunschText { get; set; }
    public string Variante { get; set; }
    public string ArtikelNummer { get; set; }
    public string Kommission { get; set; }
    public string Kunde { get; set; }
    public string Pcode { get; set; }
    public string Fehlerlog { get; set; }

    /// <summary>
    /// Gültige Werte: "NichtFreigegeben", "Freigegeben", "Abgerechnet"
    /// </summary>
    public string FakturaKennzeichen { get; set; }

    public bool IstAusserhalbGewaehrleistung { get; set; }
    public decimal KapazitaetsBedarf { get; set; }

    public virtual BelegPositionDTO Position { get; set; }
    public virtual ProduktionsDatenDTO ProduktionsDaten { get; set; }
    public bool IstGedruckt { get; set; }

    public DateTime ErfassungsDatum { get; set; }
    public DateTime ChangedDate { get; set; }

    public BelegPositionAVDTO()
    {
        if (BelegPositionAVGuid.Equals(Guid.Empty))
        {
            BelegPositionAVGuid = Guid.NewGuid();
        }
    }

    public BelegPositionAVDTO(BelegPositionDTO position)
    {
        if (BelegPositionAVGuid.Equals(Guid.Empty))
        {
            BelegPositionAVGuid = Guid.NewGuid();
        }

        BelegPositionGuid = position.BelegPositionGuid;
        Bereitgestellt = DateTime.UtcNow;
        Berechnet = null;
        IstBerechnet = false;
        IstProduziert = false;
        HatSonderwuensche = !string.IsNullOrEmpty(position.Besonderheiten);
        SonderwunschText = position.SonderwunschText;
        Variante = position.Variante;
        ArtikelNummer = position.ArtikelNummer;
        Position = position;
        ErfassungsDatum = position.ErfassungsDatum;
        IstAusserhalbGewaehrleistung = position.IstAusserhalbGewaehrleistung;
    }
}
