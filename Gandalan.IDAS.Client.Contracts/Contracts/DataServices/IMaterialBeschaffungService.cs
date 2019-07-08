using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.Client.Contracts.DataServices
{
    public interface IMaterialBeschaffungService
    {
        void RegisterJob(Guid belegpositionsGuid, MaterialBeschaffungsJobDTO beschaffungsJobs);
        IList<MaterialBeschaffungsJobDTO> GetJobs(Guid belegpositionsGuid);
        bool CanHandle(string artikelNummer, string farbe);
    }
}
