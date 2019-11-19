

using System.Collections.Generic;

namespace Gandalan.Client.Contracts.ProduktionsServices
{
    /// <summary>
    /// Stellt eine Schnittstelle zu einem (physikalischen) Label-Drucker dar
    /// </summary>
    public interface ILabelPrinter
    {
        /// <summary>
        /// Druckt die angegebenen Daten auf dem Gerät aus.
        /// Es wird das in den Settings konfigurierte Template File genutzt.
        /// </summary>
        /// <param name="data"></param>
        void Print(object data);

        /// <summary>
        /// Druckt die angegebenen Daten auf dem Gerät aus.
        /// Es wird der übergebene Template Text genutzt.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="template">Inhalt des genutzten Templates</param>
        void PrintCustom(object data, string template);
    }
}
