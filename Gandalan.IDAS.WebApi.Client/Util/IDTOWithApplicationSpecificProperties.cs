using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.Util;

public interface IDTOWithApplicationSpecificProperties
{
    Dictionary<string, PropertyValueCollection> ApplicationSpecificProperties { get; set; }
}

public interface IEntityWithApplicationSpecificProperties
{
}

