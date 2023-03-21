using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.Navigation
{
    public interface IQuickCommand
    {
        string Group { get; }
        string Caption { get; }
        object Icon { get; }
        int Order { get; }

        Task ExecuteAsync(object parameter); 

    }
}