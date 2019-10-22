using Gandalan.IDAS.WebApi.DTO;
using System;
using Gandalan.Client.Contracts.Lookups;

namespace Gandalan.Client.Contracts
{
    public interface IBestellmassRechner : IFeldEditor<IBestellmassRechnerResult, BelegPositionDTO>
    {
    }

    public interface IBestellmassRechnerResult
    {
        int BerechnetesHoehenMass { get; }
        int BerechnetesBreitenMass { get; }
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
