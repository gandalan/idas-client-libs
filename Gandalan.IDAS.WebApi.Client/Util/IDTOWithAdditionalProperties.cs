using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.Util;

public interface IDTOWithAdditionalProperties
{
    Dictionary<string, PropertyValueCollection> AdditionalProperties { get; set; }
}
