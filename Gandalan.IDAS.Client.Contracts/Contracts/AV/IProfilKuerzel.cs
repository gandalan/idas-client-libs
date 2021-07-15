using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.Data;

namespace Gandalan.IDAS.Client.Contracts.Contracts.AV
{
    public interface IProfilKuerzel
    {
        Task<IList<ProfilKuerzelDTO>> GetListe();
    }
}
