using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class AnpassungVorlagenWebRoutinen : TypedWebRoutinenBase<AnpassungVorlageDTO>
{
    public AnpassungVorlagenWebRoutinen(IWebApiConfig settings) : base("AnpassungVorlagen", dto => dto.AnpassungVorlageGuid, settings)
    {
    }
}