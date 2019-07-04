using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.Client.Contracts.DataServices
{
    public interface IMaterialBeschaffungService
    {
        
        bool CanHandle(string artikelNummer);
    }
}
