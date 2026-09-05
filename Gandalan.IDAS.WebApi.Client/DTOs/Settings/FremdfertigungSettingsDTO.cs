using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.Client.DTOs.Settings;
public class FremdfertigungSettingsDTO
{
    public List<FremdfertigungsProduzentDTO> Produzenten { get; set; } = [];

    public string BetreffAngebot { get; set; }
    public string BetreffAuftrag { get; set; }
    public string AnschreibenAngebot { get; set; }
    public string AnschreibenAuftrag { get; set; }
    public string AbsendeEmailAngebot { get; set; }
    public string AbsendeEmailAuftrag { get; set; }
    public bool ListenpreiseVerwenden { get; set; }
    public bool NeuePositionenAlsFremdfertigung { get; set; }
}

public class FremdfertigungsProduzentDTO
{
    public string Name { get; set; }
    public Guid MandantGuid { get; set; }
    public string EMailAdresse { get; set; }
    public bool IsDefault { get; set; }
}
