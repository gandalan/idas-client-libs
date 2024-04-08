using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class WerteListeDTO
    {
        public WerteListeDTO()
        {
            Items = [];
        }

        public string Name { get; set; }
        public long Version { get; set; }
        public DateTime ChangedDate { get; set; }
        public Guid WerteListeGuid { get; set; }
        public List<WerteListeItemDTO> Items { get; set; }
        public DateTime GueltigAb { get; set; }
    }
}
