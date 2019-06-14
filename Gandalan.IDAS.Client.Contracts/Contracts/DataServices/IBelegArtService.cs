using System;
using System.Threading.Tasks;

namespace Gandalan.Client.Common.Contracts.DataServices
{
    public interface IBelegArtService
    {
        Task BelegKopieren(Guid bguid, string neueBelegArt, bool saldenKopieren = false);   
    }
}

