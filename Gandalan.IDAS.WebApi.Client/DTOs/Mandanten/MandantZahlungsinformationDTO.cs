using System;
using System.ComponentModel;

namespace Gandalan.IDAS.WebApi.Client.DTOs.Mandanten;

public class MandantZahlungsinformationDTO : INotifyPropertyChanged
{
    public Guid MandantZahlungsinformationGuid { get; set; }
    public Guid MandantGuid { get; set; }

    public string Bezeichnung { get; set; }

    public string IBAN { get; set; }

    public string Kontoinhaber { get; set; }

    public string BIC { get; set; }

    public string Bankname { get; set; }

    public DateTime ErstellDatum { get; set; }
    public DateTime AenderungsDatum { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;
}
