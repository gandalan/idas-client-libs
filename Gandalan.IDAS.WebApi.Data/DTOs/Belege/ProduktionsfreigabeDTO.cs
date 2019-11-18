using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class ProduktionsfreigabeDTO
    {
        public Guid BelegGuid { get; set; }
        public IList<Guid> BelegPositionGuids { get; set; }
    }
}
