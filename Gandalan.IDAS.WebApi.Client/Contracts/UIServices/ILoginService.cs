using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.UIServices
{
    public interface ILoginService
    {
        bool SaveDefaultEnvironment { get; }
        Task<bool> Login();
        Task<bool> VerifySavedAuthTokenAsync();
    }
}
