using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.Client.Contracts.DataServices
{
    public interface IMaterialBeschaffungService
    {
        string DisplayName { get; }
        int Order { get; set; }

        void RegisterJob(MaterialBeschaffungsJobDTO beschaffungsJobs);
        IList<MaterialBeschaffungsJobDTO> GetJobs(Guid belegpositionsGuid);
        IList<MaterialBeschaffungsJobDTO> GetJobs(string pCode);
        bool CanHandle(MaterialBeschaffungsJobDTO job);
    }
}
