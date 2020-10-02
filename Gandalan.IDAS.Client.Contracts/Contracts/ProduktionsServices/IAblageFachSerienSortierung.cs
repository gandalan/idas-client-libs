using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.Client.Contracts.ProduktionsServices
{
    public interface IAblageFachSerienSortierung
    {
        IList<MaterialbedarfDTO> SortElemente(SerieDTO serie);
    }
}
