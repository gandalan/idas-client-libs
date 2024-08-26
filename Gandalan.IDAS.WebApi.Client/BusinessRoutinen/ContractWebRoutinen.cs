using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class ContractWebRoutinen : WebRoutinenBase
{
    public ContractWebRoutinen(IWebApiConfig settings) : base(settings)
    {
    }

    public async Task<ContractDTO[]> GetAllAsync()
        => await GetAsync<ContractDTO[]>("Contracts");

    public async Task<ContractDTO> SaveContractAsync(ContractDTO dto)
        => await PutAsync<ContractDTO>("Contracts", dto);

    public async Task DeleteContractAsync(ContractDTO dto)
        => await DeleteAsync($"Contracts/{dto.ContractGuid}");
}