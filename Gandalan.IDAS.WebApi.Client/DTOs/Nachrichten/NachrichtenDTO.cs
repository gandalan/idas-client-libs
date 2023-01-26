using System;

namespace Gandalan.IDAS.WebApi.Client.DTOs.Nachrichten
{
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

        public bool IsValid()
        {
            var now = DateTime.Now;
            return now >= (GueltigAb ?? now) && now <= (GueltigBis ?? now).AddDays(1) && IstAktiv;
        }
    }
}
