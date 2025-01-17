using System;
using System.ComponentModel;

namespace Gandalan.IDAS.WebApi.DTO;

public class MandantDTO : INotifyPropertyChanged
{
    public string Name { get; set; } // "name": "RSD Systeme GmbH",
    public string Beschreibung { get; set; } //"description": null,
    public DateTime ErstellDatum { get; set; } //    "created_at": "2013-10-30T09:55:11.904+01:00",
    public DateTime AenderungsDatum { get; set; } //    "updated_at": "2013-10-30T09:55:13.699+01:00",
    public string AdminEmail { get; set; } //    "email": "wolfgang.marquardt@rsd-systeme.de",
    public Guid MandantGuid { get; set; }
    public long SIC_CMS_Producer_Id { get; set; }
    public string DongleNummer { get; set; }
    public Guid ProduzentMandantGuid { get; set; }
    public string KundenNummerBeimProduzenten { get; set; }
    public bool IstAktiv { get; set; }
    public bool IstHaendler { get; set; }
    public bool IstProduzent { get; set; }
    public bool ErbtAuswahlOhneSprosse { get; set; }
    public bool StammdatenbearbeitungGesperrt { get; set; }
    public string NeherKundennummer { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;
}
