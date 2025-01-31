using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.Contracts.AV;

public interface IBelegProduktionsfreigabeCommand
{
    public bool CanExecute(IList<IProduktionsfreigabeItem> parameter);
    public Task ExecuteAsync(IList<IProduktionsfreigabeItem> parameter);
}
