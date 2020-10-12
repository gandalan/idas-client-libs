﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.DTO
{
    /// <summary>
    /// DTO für die IBOS3 Ablageverwaltung
    /// </summary>
    public class AblageFachDTO
    {
        public Guid AblageFachGuid { get; set; }

        [JsonIgnore]
        public bool Belegt
        {
            get
            {
                return BelegPositionAVGuid != Guid.Empty;
            }
        }

        public int FachNr { get; set; }

        /// <summary>
        /// GUIDs der ProduktGrupptenDTOs, die im Ablagefach abgelegt werden können
        /// </summary>
        public IList<Guid> ProduktGruppenGuids { get; set; } = new List<Guid>();

        /// <summary>
        /// GUIDs der aktuell im Ablagefach abgelegten MaterialbedarfDTOs
        /// </summary>
        public IList<Guid> MaterialBedarfGuids { get; set; } = new List<Guid>();

        /// <summary>
        /// Guid der BelegPositionAV -> Ist diese Guid schon gesetzt, aber noch kein Material zugeordnet, dann ist das Fach für die Position reserviert
        /// </summary>
        public Guid BelegPositionAVGuid { get; set; }

    }
}
