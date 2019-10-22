using Gandalan.IDAS.WebApi.DTO;
using System;
using Gandalan.Client.Contracts.Lookups;

namespace Gandalan.Client.Contracts
{
    public interface IBestellmassRechner : IFeldEditor<IBestellmassRechnerResult, IBestellmassRechnerParams>
    {
    }

    public interface IBestellmassRechnerParams
    {
        int LichtesBreitenMass { get; }
        int LichtesHoehenMass { get; }
    }

    public interface IBestellmassRechnerResult
    {
        int BerechnetesHoehenMass { get; }
        int BerechnetesBreitenMass { get; }
    }

    public class BestellmassRechnerParams : IBestellmassRechnerParams
    {
        public int LichtesBreitenMass { get; set; }
        public int LichtesHoehenMass { get; set; }
    }

    public class BestellmassRechnerResult : IBestellmassRechnerResult
    {        
        public int BerechnetesHoehenMass { get; set; }
        public int BerechnetesBreitenMass { get; set; }

        public BestellmassRechnerResult(int berechnetesLichtesHoehenMass, int berechnetesLichtesBreitenMass)
        {
            BerechnetesHoehenMass = berechnetesLichtesHoehenMass;
            BerechnetesBreitenMass = berechnetesLichtesBreitenMass;
        }
    }
}
