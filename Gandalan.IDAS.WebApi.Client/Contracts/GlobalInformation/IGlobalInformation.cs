using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.Client.Contracts.Contracts.GlobalInformation;

public interface IGlobalInformation
{
    BenutzerDTO Benutzer { get; set; }
}