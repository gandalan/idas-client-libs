using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.Client.Contracts.UIServices;

public interface IBelegAdresseEditor
{
    Task<BeleganschriftDTO> EditAdresse(BeleganschriftDTO dto, KontaktDTO kontaktDto);
}