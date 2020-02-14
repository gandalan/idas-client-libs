using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Gandalan.IDAS.WebApi.DTO
{
    /// <summary>
    /// DTO für die IBOS3 Ablageverwaltung
    /// </summary>
    public class InfoScreenInitTypeDTO
    {
        public string Name { get; set; }
        public Type Type { get; set; }

        public object Data { get; set; }

    }

}