using System;

namespace Gandalan.IDAS.WebApi.DTO;

public interface ILagerLogikDTO
{
    Guid KatalogArtikelGuid { get; }
    Guid FarbKuerzelGuid { get; }
    [Obsolete("FarbKuerzelGuid verwenden")]
    Guid FarbGuid { get; }
    Guid LagerbestandGuid { get; }
}