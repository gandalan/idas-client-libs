using Gandalan.IDAS.Client.Contracts.Contracts.ReportData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.ProduktionsServices
{
    public interface ISaegeListeAufbereitenService {
        /// <summary>
        /// Sortiert und Gruppiert die Eingangsdaten und bereitet sie für den Sägelistendruck vor
        /// </summary>
        /// <param name="groupedProperty">Property, nachdem groupiert werden soll (Level 1)</param>
        /// <param name="items">Items die aufbereitet werden sollen</param>
        /// <returns></returns>
        Task<IEnumerable<IMaterialReportData>> SortAndGroup(string groupedProperty, IEnumerable<IMaterialReportItem> items);
        /// <summary>
        /// Sortiert und Gruppiert die Eingangsdaten und bereitet sie für den Sägelistendruck vor
        /// </summary>
        /// <param name="groupedProperty">Property, nachdem groupiert werden soll (Level 1)</param>
        /// <param name="items">Items die aufbereitet werden sollen</param>
        /// <param name="secondLevelGroup">Property, nachdem groupiert werden soll (Level 2)</param>
        /// <returns></returns>
        Task<IEnumerable<IMaterialReportData>> SortAndGroup(string groupedProperty, IEnumerable<IMaterialReportItem> items, string secondLevelGroup);
    }
}