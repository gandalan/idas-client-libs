using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.Client.Common.Contracts.UIServices
{
    public interface IBenutzerEditor
    {
        void EditBenutzer(Guid benutzerGuid, bool istProduzent);
        void DeleteBenutzer(Guid benutzerGuid);
        void CreateBenutzer(bool istProduzent);
    }
}
