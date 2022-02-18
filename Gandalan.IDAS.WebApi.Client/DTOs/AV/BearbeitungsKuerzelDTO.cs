using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.WebApi.Data
{
    public class BearbeitungsKuerzelDTO
    {        
        public string BearbeitungsKuerzel { get; set; }
        public string Beschreibung { get; set; }
        public string[] VerfuegbarFuer { get; set; }
        public string FarbCode { get; set; }
        public string RegularExpression { get; set; }
    }
}
