using System;

namespace Gandalan.IDAS.WebApi.Client.Contracts;
public interface IWithGueltigkeitsZeitraum
{
    public DateTime? GueltigAb { get; }
    public DateTime? GueltigBis { get; }
}
