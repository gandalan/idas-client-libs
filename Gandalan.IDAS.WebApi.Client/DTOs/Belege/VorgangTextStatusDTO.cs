using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.DTO
{

    public class VorgangTextStatusDTO
    {
        /// <summary>
        /// Liste von eindeutigen GUIDs
        /// </summary>
        public List<Guid> VorgangGuids { get; set; }

        /// <summary>
        /// Status der in das Feld TextStatus für alle Vorgänge gesetzt werden soll.
        /// </summary>
        public string NeuerTextStatus { get; set; }
    }
}
