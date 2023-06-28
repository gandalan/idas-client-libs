using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.UIServices
{
    public interface ILoginService
    {
        bool SaveDefaultEnvironment { get; }
        bool Login();
        Task<bool> VerifySavedAuthTokenAsync();
    }
}
