using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.Client.Contracts.Contracts.GlobalInformation
{
    public interface IGlobalInformation
    {
        BenutzerDTO Benutzer { get; set; }
    }
}
