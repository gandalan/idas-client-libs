using System;
using System.Collections.Generic;
using System.Linq;

namespace Gandalan.IDAS.WebApi.DTO;

/// <summary>
/// Produktionsdaten für ein Fertigelement
/// </summary>
public class ProduktionsDatenDTO
{
    /// <summary>
    /// Eindeutige ID
    /// </summary>
    public Guid ProduktionsDatenGuid { get; set; }

    /// <summary>
    /// Gesamtliste des benötigten Materials (immer für Stückzahl 1)
    /// </summary>
    public List<MaterialbedarfDTO> Material { get; set; } = [];

    /// <summary>
    /// Produktionsetiketten
    /// </summary>
    public List<EtikettDTO> Etiketten { get; set; } = [];

    /// <summary>
    /// CNC-Bearbeitungen
    /// </summary>
    public List<BearbeitungDTO> Bearbeitungen { get; set; } = [];

    /// <summary>
    /// Daten der Original-Belegposition
    /// </summary>
    public PositionsDatenDTO PositionsDaten { get; set; }

    public List<SonderwuenscheDTO> Sonderwuensche { get; set; } = [];
    public string[] Log { get; set; }

    /// <summary>
    /// Gibt Artikel aus dem Materialbedarf zurück, die KEINE Zuschnitte sind
    /// </summary>
    /// <returns>Materialliste</returns>
    public List<MaterialbedarfDTO> GetMaterialbedarf()
    {
        return Material == null ? [] : Material.Where(m => m.IstZuschnitt == false || m.ZuschnittLaenge == 0).ToList();
    }

    /// <summary>
    /// Gibt NUR Artikel aus dem Materialbedarf zurück, die Zuschnitte sind
    /// </summary>
    public List<MaterialbedarfDTO> GetSaegeliste()
    {
        return Material == null ? [] : Material.Where(m => m.IstZuschnitt && m.ZuschnittLaenge > 0).ToList();
    }
}