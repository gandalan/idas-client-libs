using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.DTOs.Nachrichten;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class NotifyWebRoutinen : WebRoutinenBase
    {
        public NotifyWebRoutinen(IWebApiConfig settings) : base(settings)
        {
            var uri = new UriBuilder(settings.NotifyUrl);
            uri.Path = "/api/";
            Settings.Url = uri.ToString();
        }

        public async Task<IList<NachrichtenDTO>> GetAllNotificationsAsync()
        {
            var mandant = Settings.AuthToken.Mandant.MandantGuid;
            var produzent = Settings.AuthToken.Mandant.ProduzentMandantGuid;
            return await GetAsync<List<NachrichtenDTO>>($"Nachrichten?mandantGuid={mandant}&produzentGuid={produzent}");
        }
    }
}
