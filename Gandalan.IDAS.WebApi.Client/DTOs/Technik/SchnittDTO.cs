using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.DTO;

public partial class SchnittDTO
{
    public Guid SchnittGuid { get; set; }
    public string Name { get; set; }
    public virtual ICollection<OperationsPunktDTO> OperationsPunkte { get; set; }
    public virtual ICollection<SchnittKonturDTO> SchnittKonturZuordnungen { get; set; }
    public long Version { get; set; }
    public DateTime ChangedDate { get; set; }


}