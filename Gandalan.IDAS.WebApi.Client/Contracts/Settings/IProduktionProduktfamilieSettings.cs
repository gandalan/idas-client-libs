using System.Collections.Generic;
using System.ComponentModel;

namespace Gandalan.IDAS.WebApi.Client.Contracts.Settings;

public interface IProduktionProduktfamilieSettings
{
    /// <summary>
    /// Eindeutige Bezeichnung der Gruppe! (Altdaten müssen konvertiert werden, da diese Bezeichnung noch nicht vorhanden)
    /// </summary>
    string GroupName { get; set; }

    string ProduktfamilienName { get; set; }
    bool SprossenFrei { get; set; }
    bool Vorbiegen { get; set; }
    string Buerste { get; set; }
    List<string> BuersteList { get; set; }
    List<string> MoeglicheVariantenVorbiegen { get; set; }
    string MoeglicheVariantenString { get; }
    bool FederkraftErhoeht { get; set; }
    bool IndividuelleSeitenarretierung { get; set; }
    int? HoeheFuerSeitenarretierung { get; set; }
    event PropertyChangedEventHandler PropertyChanged;
}
