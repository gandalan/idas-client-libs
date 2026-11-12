using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.DTO;

/// <summary>
/// Antwort der Route PositionInBelegeUebernehmenPruefen: wie die Übernahme die Ziele einer neu erfassten Position bewertet.
/// Sonderposition meint hier eine Variante mit $-Kürzel, nicht den Sonder-Katalogartikel.
/// </summary>
public class PositionUebernahmeBewertungDTO
{
    /// <summary>
    /// Je Ziel in derselben Reihenfolge der Grund, warum die Übernahme es für sich allein ablehnte, sonst <c>null</c>.
    /// </summary>
    public List<string> Ablehnungsgruende { get; set; } = new();

    /// <summary>
    /// Warum die Position nur in einen Produktionsbeleg kommt; <c>null</c>, wenn die Übernahme mehrere annimmt (Sonderposition).
    /// </summary>
    public string NurEinProduktionsbelegGrund { get; set; }

    /// <summary>
    /// Name der geplanten Serie (ohne Namen ihr Kürzel), die eine Kopie in einen bestehenden Produktionsbeleg wie bei der Freigabe
    /// übernehmen kann; <c>null</c> ohne Serie oder ohne AV-Positionen (Sonderposition).
    /// </summary>
    public string UebernehmbareSerie { get; set; }

    /// <summary>
    /// Name der Belegart, in die die Produktionsfreigabe die Position gäbe: ProduktionsAuftrag, ZuschnittAuftrag, VersandAuftrag
    /// oder FremdfertigungsAuftrag. <c>null</c> bei einer Sonderposition, für die allein sie keinen Beleg anlegt. Text wie
    /// <c>BelegDTO.BelegArt</c>.
    /// </summary>
    public string FreigabeBelegArt { get; set; }
}
