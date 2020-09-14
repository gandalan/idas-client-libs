using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class ContractWebRoutinen : WebRoutinenBase
    {
        public ContractWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public ContractDTO[] GetAll()
        {
            if (Login())
            {
                return Get<ContractDTO[]>("Contracts");
            }
            return null;
        }

        public ContractDTO SaveContract(ContractDTO dto)
        {
            if (Login())
            {
                return Put<ContractDTO>("Contracts", dto);
            }
            return null;
        }

        public string DeleteContract(ContractDTO dto)
        {
            if (Login())
            {
                return Delete<string>("Contracts/" + dto.ContractGuid);
            }
            return null;
        }


        public async Task<ContractDTO[]> GetAllAsync()
        {
            return await Task.Run(() => GetAll());
        }

        public async Task SaveContractAsync(ContractDTO dto)
        {
            await Task.Run(() => SaveContract(dto));
        }

        public async Task DeleteContractAsync(ContractDTO dto)
        {
            await Task.Run(() => DeleteContract(dto));
        }
    }
}
