using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.Client.Contracts.Flux
{
    public interface IFluxAction
    {
        object Payload { get; }
        string Verb { get; }

        void Deconstruct(out string verb, out object payload);
    }
}
