using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;
using Gandalan.IDAS.WebApi.DTO.API;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class AnpassungVorlagenWebRoutinen : TypedWebRoutinenBase<AnpassungVorlageDTO>
    {
        public AnpassungVorlagenWebRoutinen(IWebApiConfig settings) : base("AnpassungVorlagen", (dto) => dto.AnpassungVorlageGuid, settings)
        {
        }
    }
}
