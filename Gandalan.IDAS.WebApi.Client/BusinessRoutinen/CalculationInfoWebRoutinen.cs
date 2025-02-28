using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class CalculationInfoWebRoutinen(IWebApiConfig settings) : WebRoutinenBase(settings)
{
    private const string CalculationInfoApiRoute = "CalculationInfo";

    public async Task<CalculationInfoDTO> PutCalculationInfoAsync(CalculationInfoDTO calculationInfoDTO)
        => await PutAsync<CalculationInfoDTO>($"{CalculationInfoApiRoute}", calculationInfoDTO);

    public async Task<CalculationInfoDTO> GetCalculationInfoAsync(long mandantId, Guid belegPosGuid)
        => await GetAsync<CalculationInfoDTO>($"{CalculationInfoApiRoute}?mandantId={mandantId}&belegPosGuid={belegPosGuid}");

    public async Task<List<CalculationInfoDTO>> GetIncompleteCalculationInfosAsync()
        => await GetAsync<List<CalculationInfoDTO>>($"{CalculationInfoApiRoute}/Incomplete");
}
