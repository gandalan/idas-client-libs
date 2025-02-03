using System;

namespace Gandalan.IDAS.WebApi.Client.Contracts.AV;

public interface IProduktionsfreigabeItem
{
    Guid ABBelegGuid { get; set; }
    Guid VorgangGuid { get; set; }
    long VorgangsNummer { get; set; }
}
