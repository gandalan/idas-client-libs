using System;
using System.Collections.Generic;
using System.Text;
using Gandalan.IDAS.WebApi.Data;

namespace Gandalan.IDAS.Client.Contracts.Contracts.AV
{
    public interface IBearbeitungsKuerzel
    {
        IList<BearbeitungsKuerzelDTO> GetListe();
    }
}
