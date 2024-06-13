using System;

namespace Gandalan.IDAS.WebApi.DTO;

public class ProduzentAktivierenDTO
{
    public Guid FreischaltCode { get; set; }
    public string AdminEmail { get; set; }
    public int DongleNummer { get; set; }

}