using System;

namespace Gandalan.IDAS.WebApi.DTO;

public class BelegNummerSettingDTO
{
    public string BelegArt { get; set; }
    public long Startwert { get; set; }
    public long Version { get; set; }
    public DateTime ChangedDate { get; set; }
}