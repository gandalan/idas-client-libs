using System;

namespace Gandalan.IDAS.WebApi.DTO;

public class BerechtigungDTO
{
    public string Code { get; set; }
    public string ErklaerungsText { get; set; }
    [Obsolete("This Property is obsolete. Set fixed for backwards compatibility")]
    public string Level => "LesenUndSchreiben";
}
