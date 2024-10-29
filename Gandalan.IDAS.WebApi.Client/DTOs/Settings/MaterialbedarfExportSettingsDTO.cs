using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Gandalan.Client.Contracts.DataServices;

namespace Gandalan.IDAS.WebApi.DTO;

[UserSettingsObject]
public class MaterialbedarfExportUserSettings
{
    public string CsvExportPath { get; set; } = "";
}

public class MaterialbedarfExportSettingsDTO
{
    public MaterialbedarfExportType NeherArtikelStandardFarbe { get; set; } = MaterialbedarfExportType.Schnittstelle;
    public MaterialbedarfExportType NeherArtikelTrendFarbe { get; set; } = MaterialbedarfExportType.Schnittstelle;
    public MaterialbedarfExportType NeherArtikelSonderFarbe { get; set; } = MaterialbedarfExportType.Schnittstelle;

    public MaterialbedarfExportType UeberschriebenerArtikelStandardFarbe { get; set; } = MaterialbedarfExportType.Schnittstelle;
    public MaterialbedarfExportType UeberschriebenerArtikelTrendFarbe { get; set; } = MaterialbedarfExportType.Schnittstelle;
    public MaterialbedarfExportType UeberschriebenerArtikelSonderFarbe { get; set; } = MaterialbedarfExportType.Schnittstelle;

    public MaterialbedarfExportType EigenArtikelStandardFarbe { get; set; } = MaterialbedarfExportType.Schnittstelle;
    public MaterialbedarfExportType EigenArtikelTrendFarbe { get; set; } = MaterialbedarfExportType.Schnittstelle;
    public MaterialbedarfExportType EigenArtikelSonderFarbe { get; set; } = MaterialbedarfExportType.Schnittstelle;

    public List<CsvExportCombinationDTO> CsvExportCombinations { get; set; } = [];

    public bool WriteLieferzusageOnCsvExport { get; set; } = true;
}

/// <summary>
/// Defines the combination of ArtikelArten + FarbArten which will be exported together in a CSV file.
/// </summary>
public class CsvExportCombinationDTO
{
    public List<ExportArtikelArt> ExportArtikelArten { get; set; } = [];
    public List<ExportFarbArt> ExportFarbArten { get; set; } = [];

    public override string ToString()
    {
        var artikelArten = ExportArtikelArten.Select(a => a.GetDescription());
        var farbArten = ExportFarbArten.Select(a => a.GetDescription());
        return $"{string.Join(" + ", artikelArten)} Artikel mit {string.Join(" + ", farbArten)}";
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
public enum ExportArtikelArt
{
    Neher,
    [Description("Überschriebene")]
    Ueberschriebene,
    Eigene,
}

/// <summary>
/// Used to determine CSV export combinations.
/// </summary>
public enum ExportFarbArt
{
    Standardfarbe,
    Trendfarbe,
    Sonderfarbe,
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
