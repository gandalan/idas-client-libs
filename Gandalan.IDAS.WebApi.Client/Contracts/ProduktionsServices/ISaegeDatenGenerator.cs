using Gandalan.IDAS.WebApi.Data.DTOs.Reports;
using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.ProduktionsServices
{
    public interface ISaegeDatenGenerator
    {
        /// <summary>
        /// Information zur Säge (Hersteller, Modellnummer usw.)
        /// </summary>
        string Modell { get; }
        /// <summary>
        /// Erzeugt die Sägedaten.
        /// </summary>
        /// <param name="material"></param>
        /// <returns>Modellabhängige Daten zur Übermittlung an die Maschine</returns>
        string GenerateContent(IList<MaterialbedarfDTO> material);

        string GenerateContent(SerienSaegelisteDataDTO saegeDaten);
    }
}
