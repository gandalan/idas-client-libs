using Gandalan.IDAS.WebApi.DTO;
using System;
using Gandalan.Client.Contracts.Lookups;
using System.Collections.Generic;

namespace Gandalan.Client.Contracts
{
    public interface IBestellmassRechner : IFeldEditor<IBestellmassRechnerResult, BelegPositionDTO>
    {
    }

    public interface IBestellmassRechnerResult
    {
        List<BestellmassRechnerResultItem> Results { get; }
    }

    public class BestellmassRechnerResult : IBestellmassRechnerResult
    {
        public List<BestellmassRechnerResultItem> Results { get; set; }

        public BestellmassRechnerResult(List<BestellmassRechnerResultItem> items)
        {
            Results = new List<BestellmassRechnerResultItem>();
            foreach (var item in items)
            {
                Results.Add(item);
            }
        }
    }

    public class BestellmassRechnerResultItem
    {
        public string KonfigName { get; set; }
        public int BerechnetesMass { get; set; }
    }
}
