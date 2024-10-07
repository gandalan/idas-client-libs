namespace Gandalan.IDAS.WebApi.DTO;

public enum ProduktionsStatiWerteDTO
{
    /// <summary>
    /// Undefinierter Zustand
    /// </summary>
    Unbekannt = 0,

    /// <summary>
    /// Bereitstellung der Position für AV erfolgte
    /// </summary>
    FuerAVBereitgestellt = 1,

    /// <summary>
    /// Materialberechnung erfolgt
    /// </summary>
    AVBerechnet = 2,

    /// <summary>
    /// Korrekturen am Material durchgeführt
    /// </summary>
    AVAbgeschlossen = 4,

    /// <summary>
    /// In einer Serie eingeordnet
    /// </summary>
    SerieZugeordnet = 8,

    /// <summary>
    /// Wird gerade produziert
    /// </summary>
    InProduktion = 16,

    /// <summary>
    /// Produktion ist fertig
    /// </summary>
    ProduktionAbgeschlossen = 32,

    /// <summary>
    /// Versand wird vorbereitet
    /// </summary>
    VersandVorbereitung = 64,

    /// <summary>
    /// Versand durchgeführt
    /// </summary>
    VersandAbgeschlossen = 128,

    /// <summary>
    /// Unterbrechung
    /// </summary>
    ProduktionUnterbrochen = 256,

    /// <summary>
    /// Fehler
    /// </summary>
    Fehler = 1024,
}
