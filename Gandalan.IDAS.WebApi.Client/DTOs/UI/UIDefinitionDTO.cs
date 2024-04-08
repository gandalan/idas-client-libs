using System;
using System.Collections.Generic;
using Gandalan.IDAS.WebApi.Client.DTOs.UI;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class UIDefinitionDTO
    {
        public Guid UIDefinitionGuid { get; set; }
        public string Kategorie { get; set; }
        public string BezeichnungKurz { get; set; }
        public string BezeichnungLang { get; set; }
        public string BildHorizontal { get; set; }
        public string BildVertikal { get; set; }
        public string Bild3D { get; set; }
        public virtual IList<UIEingabeFeldDTO> EingabeFelder { get; set; }
        public virtual IList<UIKonfiguratorFeldDTO> KonfiguratorFelder { get; set; }
        public long Version { get; set; }
        public DateTime ChangedDate { get; set; }

        public UIDefinitionDTO()
        {
            EingabeFelder = [];
            KonfiguratorFelder = [];
        }
    }
}
