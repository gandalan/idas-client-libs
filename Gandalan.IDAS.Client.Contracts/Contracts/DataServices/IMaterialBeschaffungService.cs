using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.Client.Contracts.DataServices
{
    public interface IMaterialBeschaffungService
    {
        Guid ServiceGuid { get; }
        string DisplayName { get; }
        int Order { get; set; }
        
    }
}
