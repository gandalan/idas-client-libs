using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Client.DTOs.UI;
using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public IList<NachrichtenDTO> GetAllNotifications()
        {
            var mandant = Settings.AuthToken.Mandant.MandantGuid;
            var produzent = Settings.AuthToken.Mandant.ProduzentMandantGuid;
            return Get<List<NachrichtenDTO>>($"Nachrichten?mandantGuid={mandant}&produzentGuid={produzent}");
        }

        public async Task<IList<NachrichtenDTO>> GetAllNotificationsAsync()
        {
            return await Task.Run(() => GetAllNotifications());
        }

    }

    public class NachrichtenDTO
    {
        public Guid NachrichtGuid { get; set; }
        public Guid MandantGuid { get; set; }
        public Guid BesitzerMandantGuid { get; set; }
        public string Context { get; set; }
        public string Nachricht { get; set; }
        public bool IstAktiv { get; set; }
        public DateTime? GueltigAb { get; set; }
        public DateTime? GueltigBis { get; set; }
    }
}
