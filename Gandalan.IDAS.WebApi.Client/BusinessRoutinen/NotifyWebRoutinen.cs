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
        private readonly IWebApiConfig _settings;

        public NotifyWebRoutinen(IWebApiConfig settings) : base(settings)
        {
            Settings.Url = settings.NotifyUrl.Replace("/api/", "");
        }

        public IList<NachrichtenDTO> GetAllNotifications()
        {
            return Get<List<NachrichtenDTO>>("/Nachrichten");
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
