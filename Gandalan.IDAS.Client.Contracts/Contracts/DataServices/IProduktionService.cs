using Gandalan.IDAS.WebApi.Data.DTOs.PositionsDaten;
using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.Client.Common.Contracts.DataServices
{
    public class ProduktionsDaten : INotifyPropertyChanged
    {
        public PositionsDatenDTO PositionsDaten { get; set; }
        public List<MaterialbedarfDTO> Material { get; set; }
        public List<EtikettDTO> Etiketten { get; set; }
        public List<ProduktionDTO> Bearbeitungen { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public interface IProduktionService
    {
        Task<ProduktionsDaten> GetDaten(BelegPositionDTO belegPosition, IArtikelAssetsService artikelAssetsService);
        bool CanHandle(string variantenName);
    }
}
