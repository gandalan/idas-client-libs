using Gandalan.Client.Contracts;
using Gandalan.IDAS.WebApi.Data.DTOs.Produktion;

namespace Gandalan.IDAS.WebApi.Client.Wpf.ApplicationEvents
{
    public class ProduktionBerechnetEvent : IApplicationEvent
    {
        public BerechnungParameterDTO Daten { get; set; }
    }
}
