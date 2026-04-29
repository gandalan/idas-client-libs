using System;

namespace Gandalan.IDAS.WebApi.DTO;

public class VorgangBlackListEntryDTO
{
    public Guid VorgangBlackListGuid { get; set; }
    public Guid VorgangGuid { get; set; }
    public Guid AppGuid { get; set; }
    public string AppName { get; set; }
    public Guid? BenutzerGuid { get; set; }
}
