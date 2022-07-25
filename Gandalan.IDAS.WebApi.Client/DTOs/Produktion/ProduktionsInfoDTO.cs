using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.WebApi.Client.DTOs.Produktion
{
    public class ProduktionsInfoDTO
    {
        public long VorgangsNummer { get; set; }
        public Guid VorgangsGuid { get; set; }

        public List<ProduktionsInfoBelegDTO> BelegInfos { get; set; } = new List<ProduktionsInfoBelegDTO>();
    }

    public class ProduktionsInfoBelegDTO
    {
        public Guid BelegGuid { get; set; }
        public string BelegTitel { get; set; } // z.B. 'AB vom 17.07.2021'
        public DateTime ErstellDatum { get; set; }

        public List<ProduktionsInfoBelegPositionDTO> PositionenInfos { get; set; } = new List<ProduktionsInfoBelegPositionDTO> { };
    }

    public class ProduktionsInfoBelegPositionDTO
    {
        public Guid BelegPosGuid { get; set; }
        public Guid NachfolgeBelegPosGuid { get; set; }
        public int BelegPositionsNummer { get; set; }
        public string VariantenName { get; set; }
        public string Katalognummer { get; set; }
        public decimal Menge { get; set; }
        public string BelegPositionInfos { get; set; }

        public Guid? SerieGuid { get; set; }
        public bool IstGeplanteSerie { get; set; }
        public string SerieName { get; set; }
        public bool IsAktiv { get; set; }
        public bool IstAlternativPosition { get; set; }

        public DateTime? LieferDatum { get; set; }
        public DateTime? ProduktionsDatum { get; set; }

        public List<ProduktionsInfoBelegPositionAVDTO> AvBelegPositionenInfos { get; set; } = new List<ProduktionsInfoBelegPositionAVDTO> { };

    }

    public class ProduktionsInfoBelegPositionAVDTO
    {
        private ProduktionsStatiWerteDTO _aktuellerStatus;
        public Guid AvBelegPositionGuid { get; set; }
        public string PCode { get; set; }
        public Guid? ZugeodneteSerie { get; set; }
        public string ZugeodneteSerieName { get; set; }

        public ProduktionsStatiWerteDTO AktuellerStatus
        {
            get { return _aktuellerStatus; }
            set
            {
                _aktuellerStatus = value;
                IstFuerAVBereitgestellt = (_aktuellerStatus & ProduktionsStatiWerteDTO.FuerAVBereitgestellt) > 0;
                IstAVBerechnet = (_aktuellerStatus & ProduktionsStatiWerteDTO.AVBerechnet) > 0;
                IstAVAbgeschlossen = (_aktuellerStatus & ProduktionsStatiWerteDTO.AVAbgeschlossen) > 0;
                IstSerieZugeordnet = (_aktuellerStatus & ProduktionsStatiWerteDTO.SerieZugeordnet) > 0;
                IstInProduktion = (_aktuellerStatus & ProduktionsStatiWerteDTO.InProduktion) > 0;
                IstProduktionAbgeschlossen = (_aktuellerStatus & ProduktionsStatiWerteDTO.ProduktionAbgeschlossen) > 0;
                IstVersandVorbereitung = (_aktuellerStatus & ProduktionsStatiWerteDTO.VersandVorbereitung) > 0;
                IstVersandAbgeschlossen = (_aktuellerStatus & ProduktionsStatiWerteDTO.VersandAbgeschlossen) > 0;
                IstProduktionUnterbrochen = (_aktuellerStatus & ProduktionsStatiWerteDTO.ProduktionUnterbrochen) > 0;
                IstFehler = (_aktuellerStatus & ProduktionsStatiWerteDTO.Fehler) > 0;
            }
        }
        public bool IstFuerAVBereitgestellt { get; private set; }
        public bool IstAVBerechnet { get; private set; }
        public bool IstAVAbgeschlossen { get; set; }
        public bool IstSerieZugeordnet { get; set; }
        public bool IstInProduktion { get; set; }
        public bool IstProduktionAbgeschlossen { get; set; }
        public bool IstVersandVorbereitung { get; set; }
        public bool IstVersandAbgeschlossen { get; set; }
        public bool IstProduktionUnterbrochen { get; set; }
        public bool IstFehler { get; set; }

        public int AktuelleProzent { get; set; }
        public string AktuellerText { get; set; }
        public int GesamtMinuten { get; set; }


        public List<ProduktionsStatusHistorieDTO> Historie { get; set; } = new List<ProduktionsStatusHistorieDTO>();
    }
}
