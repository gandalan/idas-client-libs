using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Gandalan.IDAS.WebApi.DTO
{

    /// <summary>
    /// DTO für die Zeilen in der InfoScreen Konfiguration
    /// </summary>
    public class InfoScreenRowDTO
    {
        public InfoScreenModulSettingsDTO[] InfoScreenModule { get; set; } = new InfoScreenModulSettingsDTO[2];

        [JsonIgnore]
        public Guid GuidModulCol1
        {
            get
            {
                return InfoScreenModule[0] != null ? InfoScreenModule[0].ModuleGuid : Guid.Empty;
            }
            set
            {
                if (value != Guid.Empty)
                    InfoScreenModule[0] = new InfoScreenModulSettingsDTO() { ModuleGuid = value };
                else
                    InfoScreenModule[0] = null;
            }
        }

        [JsonIgnore]
        public Guid GuidModulCol2
        {
            get
            {
                return InfoScreenModule[1] != null ? InfoScreenModule[1].ModuleGuid : Guid.Empty;
            }
            set
            {
                if (value != Guid.Empty)
                    InfoScreenModule[1] = new InfoScreenModulSettingsDTO() { ModuleGuid = value };
                else
                    InfoScreenModule[1] = null;
            }
        }
        public int RowNum { get; set; }
    }
}