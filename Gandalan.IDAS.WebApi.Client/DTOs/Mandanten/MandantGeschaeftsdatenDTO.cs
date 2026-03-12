using System;
using System.ComponentModel;

using Gandalan.IDAS.Data.IBOS3.Mandanten;

namespace Gandalan.IDAS.WebApi.Client.DTOs.Mandanten;

public class MandantGeschaeftsdatenDTO : INotifyPropertyChanged
{
    public Guid MandantGeschaeftsdatenGuid { get; set; }
    public Guid MandantGuid { get; set; }

    public GeschaeftsdatenTyp Typ { get; set; }
    public string Bezeichnung { get; set; }

    public string Firmenname { get; set; }

    public string Zusatz { get; set; }

    public string UmsatzsteuerId { get; set; }

    public string Steuernummer { get; set; }

    public string HandelsregisterGericht { get; set; }
    public string Handelsregisternummer { get; set; }

    public string Anrede { get; set; }
    public string Titel { get; set; }
    public string Vorname { get; set; }
    public string Nachname { get; set; }

    public string Mailadresse { get; set; }

    public string Telefonnummer { get; set; }

    public string AdressZeile1 { get; set; }

    public string AdressZeile2 { get; set; }

    public string AdressZeile3 { get; set; }

    public string Postleitzahl { get; set; }

    public string Ort { get; set; }

    public string Land { get; set; }

    public DateTime ErstellDatum { get; set; }
    public DateTime AenderungsDatum { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;
}
