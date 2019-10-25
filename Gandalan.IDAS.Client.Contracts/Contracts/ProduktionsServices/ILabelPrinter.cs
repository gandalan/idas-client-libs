

using System.Collections.Generic;

namespace Gandalan.Client.Contracts.ProduktionsServices
{
    /// <summary>
    /// Stellt eine Schnittstelle zu einem (physikalischen) Label-Drucker dar
    /// </summary>
    public interface ILabelPrinter
    {
        /// <summary>
        /// Druckt die angegebenen Daten auf dem Gerät aus
        /// </summary>
        /// <param name="data"></param>
        void Print(object data);
    }
}
