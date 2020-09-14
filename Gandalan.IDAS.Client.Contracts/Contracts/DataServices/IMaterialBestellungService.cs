using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Contracts.DataServices
{
    public interface IMaterialBestellungService
    {
        /// <summary>
        /// Bestellt eine Liste von MaterialItemDTOs. Dabei werden alle BeschaffungsServices berücksichtigt, die das Material 
        /// beschaffen können. Für die Bestellung ausgewählt wird der mit der kürzesten Lieferzeit, oder bei ignoreLieferzeit = true, der mit
        /// der höchsten Priorität laut Einstellungen. Wird für ein Material kein Service gefunden, so wird für das Material trotzdem ein Beschaffungsjob erstellt.
        /// Dieser verbleibt jedoch im Status "Erstellt" und kann später erneut bestellt werden.
        /// </summary>
        /// <param name="materialListe">Zu bestellendes Material</param>
        /// <param name="ignoreLieferzeit">Lieferzeit ignorieren</param>
        /// <returns>Liste der erstellten MaterialBeschaffungsJobDTOs</returns>
        IList<MaterialBeschaffungsJobDTO> Bestellung(IList<MaterialItemDTO> materialListe, bool ignoreLieferzeit = false);

        MaterialBeschaffungsJobDTO Bestellung(MaterialItemDTO material, bool ignoreLieferzeit = false);

        IList<MaterialBeschaffungsJobDTO> Bestellung(IList<MaterialBeschaffungsJobDTO> beschaffungsJobs, bool ignoreLieferzeit = false);

        MaterialBeschaffungsJobDTO Bestellung(MaterialBeschaffungsJobDTO beschaffungsJob, bool ignoreLieferzeit = false);
    }
}
