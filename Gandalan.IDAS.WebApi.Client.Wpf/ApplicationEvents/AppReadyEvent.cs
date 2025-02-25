using Gandalan.Client.Contracts;
using Gandalan.Client.Contracts.AppServices;

namespace Gandalan.IDAS.WebApi.Client.Wpf.ApplicationEvents;

public class AppReadyEvent : IApplicationEvent
{
    public string BasePath { get; set; }
    public IApplicationConfig AppConfig { get; set; }
}
