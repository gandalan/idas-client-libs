using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.WebApi.Data.DTOs.AV
{
    /// <summary>
    /// Ergebniss des PCodeSuche Controller. 
    /// Der Controller kann verschiedene Informationen im Zusammenhang mit einem PCode zurückliefern.
    /// </summary>
    public class PCodeSuchResultDTO
    {
        /// <summary>
        /// BelegPosition die dem PCode zugeordnet ist.
        /// </summary>
        public BelegPositionDTO Position { get; set; }
        /// <summary>
        /// Vorgang die dem PCode zugeordnet ist.
        /// </summary>
        public VorgangDTO Vorgang { get; set; }
        /// <summary>
        /// BelegPositionAV die dem PCode zugeordnet ist.
        /// </summary>
        public BelegPositionAVDTO BelegpositionAV { get; set; }
        /// <summary>
        /// Alle MaterialBeschaffungsJobs die für diese Position erstellt wurden.
        /// </summary>
        public List<MaterialBeschaffungsJobDTO> MaterialBeschaffungsJobs { get; set; }
        /// <summary>
        /// Liste aller Vorgänge die eine Position haben, die diesem PCode zugeordnet ist (z.B. Beschichtungspositionen)
        /// </summary>
        public List<VorgangDTO> NachfolgeVorgaenge { get; set; }

        /// <summary>
        /// Parameterloser Konstruktor um die Listen zu initialisieren.
        /// </summary>
        public PCodeSuchResultDTO()
        {
            MaterialBeschaffungsJobs = new List<MaterialBeschaffungsJobDTO>();
            NachfolgeVorgaenge = new List<VorgangDTO>();
        }
    }
}
