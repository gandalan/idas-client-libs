using Gandalan.IDAS.WebApi.DTO;
using Gandalan.IDAS.WebApi.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Gandalan.IDAS.WebApi.DTO
{
    /// <summary>
    /// DTO zur Ablage der Einstellungen einzelner InfoScreen Module innerhalb eines InfoScreens.
    /// Modulspezifische Einstellungen werden in den ApplicationSpecificProperties abgelegt.
    /// </summary>
    public class InfoScreenModulSettingsDTO : IDTOWithApplicationSpecificProperties
    {
        public Dictionary<string, PropertyValueCollection> ApplicationSpecificProperties { get; set; }

        public Guid ModuleGuid { get; set; }

        public InfoScreenInitTypeDTO InitType { get; set; }

        public List<InfoScreenInitTypeDTO> AllowedTypes { get; set; }

        public bool NeedsInit { get; set; }

        public bool IsValid { get; set; }
    }
}
