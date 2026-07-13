using System;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.DTOs.Benutzer;

public class AppBenutzerRequestDTO
{
    public Guid KundeGuid { get; set; }
    public bool PasswortSenden { get; set; }
    public string Passwort { get; set; } = "";
    public BenutzerDTO BenutzerData { get; set; }
}
