using System;

namespace Gandalan.IDAS.WebApi.DTO;

public class LoginDTO
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Mandant { get; set; }
    public Guid AppToken { get; set; }
}