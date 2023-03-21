using System;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class KonfigSatzInfoDTO
    {        
        public Guid KonfigSatzGuid { get; set; }        
        public Guid VarianteGuid { get; set; }        
        public string LM_Hoehe { get; set; }
        public string LM_Breite { get; set; }
        public string LM_Breite2 { get; set; }
    }
}