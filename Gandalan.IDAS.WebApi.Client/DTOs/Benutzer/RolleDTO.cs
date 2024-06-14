using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.DTO;

public class RolleDTO
{
    public IList<BerechtigungDTO> Berechtigungen { get; set; }
    public string Name { get; set; }
    public string Beschreibung { get; set; }
    public Guid RolleGuid { get; set; }

    public RolleDTO()
    {
            Berechtigungen = [];
        }
}