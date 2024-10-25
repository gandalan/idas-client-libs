using System;

namespace Gandalan.IDAS.WebApi.Client.DTOs.UI;

public class TagVorlageDTO
{
    public Guid TagVorlageGuid { get; set; }

    public string Text { get; set; }
    public string ToolTip { get; set; }
    public string BackgroundColorCode { get; set; }
    public string TextColorCode { get; set; }

    public long Version { get; set; }
    public DateTime ChangedDate { get; set; }
}
