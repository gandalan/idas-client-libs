using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Gandalan.IDAS.WebApi.DTO;

public class MaterialbedarfExportSettingsDTO
{
    public MaterialbedarfExportType StandardfarbArtikelExportType { get; set; } = MaterialbedarfExportType.Schnittstelle;
    public MaterialbedarfExportType TrendfarbArtikelExportType { get; set; } = MaterialbedarfExportType.Schnittstelle;
    public MaterialbedarfExportType SonderfarbArtikelExportType { get; set; } = MaterialbedarfExportType.Schnittstelle;
    public MaterialbedarfExportType UeberschriebeneArtikelExportType { get; set; } = MaterialbedarfExportType.Schnittstelle;
    public MaterialbedarfExportType EigeneArtikelExportType { get; set; } = MaterialbedarfExportType.Schnittstelle;

    public List<CsvExportCombinationDTO> CsvExportCombinations { get; set; } = [];

    public bool WriteLieferzusageOnCsvExport { get; set; } = true;
}

/// <summary>
/// Defines the combination of ArtikelArten which will be exported together in a CSV file.
/// </summary>
public class CsvExportCombinationDTO
{
    /// <summary>
    /// The type of Artikel which will be combined in this export.
    /// </summary>
    public List<CsvExportArtikelArt> ArtikelArtenKombinationen { get; set; } = [];

    public override string ToString()
    {
        if (ArtikelArtenKombinationen.Count == 1)
        {
            return ArtikelArtenKombinationen[0].GetDescription() + " Artikel";
        }
        else
        {
            var descriptions = ArtikelArtenKombinationen.Select(a => a.GetDescription());
            return string.Join(", ", descriptions.Take(descriptions.Count() - 1)) + " und " + descriptions.Last() + " Artikel";
        }
    }
}

/// <summary>
/// Determines how Materialbedarfs of a specific FarbArt will be exported.
/// </summary>
public enum MaterialbedarfExportType
{
    CSV = 0,
    Schnittstelle = 1,
}

/// <summary>
/// Used to determine CSV export combinations.
/// </summary>
public enum CsvExportArtikelArt
{
    Standardfarb,
    Trendfarb,
    Sonderfarb,
    [Description("Überschriebene")]
    Ueberschriebene,
    Eigene,
}

public static class CsvExportArtikelArtExtension
{
    public static string GetDescription(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        var attribute = field.GetCustomAttribute<DescriptionAttribute>();
        return attribute == null ? value.ToString() : attribute.Description;
    }
}
