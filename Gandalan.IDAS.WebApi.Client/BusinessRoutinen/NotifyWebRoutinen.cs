using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.DTOs.Nachrichten;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class NotifyWebRoutinen : WebRoutinenBase
    {
        private readonly bool _validConfig;

        public NotifyWebRoutinen(IWebApiConfig settings) : base(settings)
        {
            if (string.IsNullOrEmpty(settings.NotifyUrl))
            {
                return;
            }

            var uri = new UriBuilder(settings.NotifyUrl);
            uri.Path = "/api/";
            Settings.Url = uri.Uri.ToString(); // use Uri member!! to be identical to createWebClient later on - otherwise includes port etc
            _validConfig = true;
        }

        public async Task<IList<NachrichtenDTO>> GetAllNotificationsAsync()
        {
            if (!_validConfig)
            {
                return new List<NachrichtenDTO>();
            }

            var mandant = Settings.AuthToken.Mandant.MandantGuid;
            var produzent = Settings.AuthToken.Mandant.ProduzentMandantGuid;
            return await GetAsync<List<NachrichtenDTO>>($"Nachrichten?mandantGuid={mandant}&produzentGuid={produzent}");
        }
    }
}
