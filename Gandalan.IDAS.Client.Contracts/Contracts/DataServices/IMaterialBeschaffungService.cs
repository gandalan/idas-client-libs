using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.Client.Contracts.DataServices
{
    public interface IMaterialBeschaffungService
    {
        void RegisterJob(MaterialBeschaffungsJobDTO beschaffungsJobs);
        IList<MaterialBeschaffungsJobDTO> GetJobs(Guid belegpositionsGuid);
        bool CanHandle(MaterialBeschaffungsJobDTO job);
    }
}
