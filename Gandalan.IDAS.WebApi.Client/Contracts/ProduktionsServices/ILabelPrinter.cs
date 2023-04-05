using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;

namespace Gandalan.Client.Contracts.ProduktionsServices
{
    /// <summary>
    /// Stellt eine Schnittstelle zu einem (physikalischen) Label-Drucker dar
    /// </summary>
    public interface ILabelPrinter
    {
        /// <summary>
        /// Bezeichnung der Druckerimplementation
        /// </summary>
        string Bezeichnung { get; }

        /// <summary>
        /// GUID der Druckerimplementation. Anhand der Guid wird die Implementierung identifiziert.
        /// </summary>
        Guid Guid { get; }

        /// <summary>
        /// Gibt an, wie der Drucker angesteuert werden soll.
        /// true: Jedes Etikett wird einzeln geschickt
        /// false: Alle zu druckenden Etiketten werden in einer Liste übermittelt
        /// </summary>
        bool Einzeldruck { get; }

        /// <summary>
        /// Druckt die angegebenen Daten auf dem Gerät aus.
        /// Es wird das in den Settings konfigurierte Template File genutzt.
        /// Wird aufgerufen, wenn Einzeldruck = true
        /// </summary>
        /// <param name="data">Datenobjekt für einzelnes Etikett</param>
        void Print(EtikettDTO data);

        /// <summary>
        /// Druckt die angegebenen Daten auf dem Gerät aus.
        /// Es wird das in den Settings konfigurierte Template File genutzt.
        /// Wird aufgerufen, wenn Einzeldruck = false
        /// </summary>
        /// <param name="titel">Titel für den Etikettenbogen</param>
        /// <param name="data">Liste mit Datenobjekten für zu druckende Etiketten</param>
        void Print(string titel, IEnumerable<EtikettDTO> data);

        /// <summary>
        /// Druckt die angegebenen Daten auf dem Gerät aus.
        /// Es wird das übergebene Template genutzt.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="template">Druck Template (muss zum ausgewählten Drucker passen)</param>
        void PrintCustom(EtikettDTO data, object template);

        /// <summary>
        /// Liefert das SettingsControl für den Drucker zurück.
        /// Wird vom LabelPrinterSettingsViewModel genutzt.
        /// </summary>
        /// <returns>Settings Control</returns>
        object GetSettingsControl();
    }
}
