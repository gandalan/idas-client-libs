using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.Client.Contracts.Lookups
{
    public interface IFeldEditor
    {
        bool CanHandle(string tag);
        void Execute(BelegPositionDTO belegPosition, out Dictionary<string, string> newValues);
    }
}
