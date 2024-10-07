using System;

namespace Gandalan.IDAS.WebApi.Client.AppServices;

public interface IPluginInfo
{
    Guid Id { get; set; }
    string Name { get; set; }
    string Version { get; set; }
    bool Enabled { get; set; }
    bool IsWebApp { get; }
}
