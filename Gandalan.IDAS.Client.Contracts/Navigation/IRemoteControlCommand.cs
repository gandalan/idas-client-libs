using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace Gandalan.Plugins.Common.Contracts
{
    public interface IRemoteControlCommand
    {
        string Uri { get; }
        object Execute(NameValueCollection request);

        [JsonIgnore]
        IRemoteControlServer Server { get; set; }
    }
}