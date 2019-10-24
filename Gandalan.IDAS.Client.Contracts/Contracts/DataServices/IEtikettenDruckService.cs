using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.Client.Contracts.DataServices
{
    public interface IEtikettenDruckService
    {
        void PrintEtiketten<T>(IList<T> elementListe);
        void PrintEinzeletikett<T>(T etikett);
    }
}
