using System;
using Gandalan.Client.Contracts;
using Gandalan.IDAS.WebApi.Client.DTOs.Dates;

namespace Gandalan.IDAS.WebApi.Client.Contracts.Lookups;

public interface IZeitraumLookup : ILookupDialog<ZeitraumLookupResult, ZeitraumLookupParams>
{
}

public record ZeitraumLookupParams
{
    public string Titel { get; set; }
    public string Description { get; set; }
    public DateTime? DefaultVon { get; set; }
    public DateTime? DefaultBis { get; set; }
}

public record ZeitraumLookupResult
{
    public ZeitraumDTO Zeitraum { get; set; }
}
