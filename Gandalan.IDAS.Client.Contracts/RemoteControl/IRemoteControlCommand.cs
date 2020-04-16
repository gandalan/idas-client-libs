using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.RemoteControl
{
    public interface IRemoteControlCommand
    {
        string Uri { get; }
        object Execute(object parameters);
    }
}