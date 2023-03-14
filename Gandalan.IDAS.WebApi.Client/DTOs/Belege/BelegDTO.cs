using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Gandalan.IDAS.WebApi.Util;
using Newtonsoft.Json;
using PropertyChanged;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class BelegDTO : IDTOWithApplicationSpecificProperties, INotifyPropertyChanged
    {
        public Guid BelegGuid { get; set; }
        public string BelegArt { get; set; }
        public long BelegNummer { get; set; }
        public int BelegJahr { get; set; }
        public DateTime BelegDatum { get; set; }
        public DateTime AenderungsDatum { get; set; }
        public BeleganschriftDTO BelegAdresse { get; set; }
        public BeleganschriftDTO VersandAdresse { get; set; }
        public bool VersandAdresseGleichBelegAdresse { get; set; }
        public string AusfuehrungsDatum { get; set; }
        public string Terminwunsch { get; set; }
        public string InterneNotiz { get; set; }
        public string BemerkungFuerKunde { get; set; }
        public bool IstSelbstabholer { get; set; }
        public string BelegTitelUeberschrift { get; set; }
        public string BelegTitelZeile1 { get; set; }
        public string BelegTitelZeile2 { get; set; }
        public string Schlusstext { get; set; }
        public string AktuellerStatusCode { get; set; }
        public string AktuellerStatusText { get; set; }
        public string Ansprechpartner { get; set; }
        public string AnsprechpartnerKunde { get; set; }

        public virtual IList<Guid> Positionen { get; set; }
        public virtual IList<BelegSaldoDTO> Salden { get; set; }
        public IList<BelegHistorieDTO> Historie { get; set; }
        public Dictionary<string, PropertyValueCollection> ApplicationSpecificProperties { get; set; }

        [JsonIgnore]
        public ObservableCollection<BelegPositionDTO> PositionsObjekte { get; set; }
        public string TextFuerAnschreiben { get; set; }
        public bool IstGesperrt { get; set; }
        /// <summary>
        /// Gültige Werte: "NichtFreigegeben", "Freigegeben", "Abgerechnet"
        /// </summary>
        public string FakturaKennzeichen { get; set; }

        public string ExterneReferenznummer { get; set; }
        public Guid? ExterneMandantenGuid { get; set; }
        public long? SammelbelegNummer { get; set; }
        public Guid? SammelbelegGuid { get; set; }

        public BelegDTO()
        {
            Positionen = new ObservableCollection<Guid>();
            Salden = new ObservableCollection<BelegSaldoDTO>();
            Historie = new ObservableCollection<BelegHistorieDTO>();
            PositionsObjekte = new ObservableCollection<BelegPositionDTO>();
            BelegDatum = DateTime.UtcNow;
            AenderungsDatum = DateTime.UtcNow;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void SetupObjekte(VorgangDTO vorgang)
        {
            PositionsObjekte = new ObservableCollection<BelegPositionDTO>();
            Positionen.ForEach(p =>
            {
                var pos = vorgang.Positionen.FirstOrDefault(pp => pp.BelegPositionGuid == p);
                if (pos != null)
                    this.PositionsObjekte.Add(pos);
            });
        }


    }
}
