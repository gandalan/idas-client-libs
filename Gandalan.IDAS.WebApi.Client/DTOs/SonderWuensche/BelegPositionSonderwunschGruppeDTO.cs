using Gandalan.IDAS.WebApi.Data.DTO;

namespace Gandalan.IDAS.WebApi.Data.DTOs.SonderWuensche;

public class BelegPositionSonderwunschGruppeDTO
{
    public string Name { get; set; }
    public BelegPositionSonderwunschDTO[] Items { get; set; }
}