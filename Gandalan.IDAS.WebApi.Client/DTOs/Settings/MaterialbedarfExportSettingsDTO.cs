using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.DTO;

public class MaterialbedarfExportSettingsDTO
{
    public MaterialbedarfExportType StandardfarbeExportType { get; set; } = MaterialbedarfExportType.CSV;
    public MaterialbedarfExportType TrendfarbeExportType { get; set; } = MaterialbedarfExportType.CSV;
    public MaterialbedarfExportType SonderfarbeExportType { get; set; } = MaterialbedarfExportType.CSV;

    public CsvExportCombination CsvExportCombination1 { get; set; } = CsvExportCombination.Standardfarbe;
    public CsvExportCombination CsvExportCombination2 { get; set; } = CsvExportCombination.TrendUndSonderfarbe;
    public CsvExportCombination CsvExportCombination3 { get; set; } = CsvExportCombination.None;

    public bool WriteLieferzusageOnCsvExport { get; set; } = true;
}

public class CsvExportCombination
{
    public int Index { get; private set; }
    public string Name { get; set; }
    /// <summary>
    /// The type of colors which will be combined in this export.
    /// </summary>
    public List<CsvExportFarbArt> FarbArten { get; set; }

    public static CsvExportCombination None => new() { Index = 0, Name = "", FarbArten = [] };
    public static CsvExportCombination Standardfarbe => new() { Index = 1, Name = "Standardfarbe", FarbArten = [CsvExportFarbArt.Standardfarbe] };
    public static CsvExportCombination Trendfarbe => new() { Index = 2, Name = "Trendfarbe", FarbArten = [CsvExportFarbArt.Trendfarbe] };
    public static CsvExportCombination Sonderfarbe => new() { Index = 3, Name = "Sonderfarbe", FarbArten = [CsvExportFarbArt.Sonderfarbe] };
    public static CsvExportCombination StandardUndTrendfarbe => new() { Index = 4, Name = "Standard- und Trendfarbe", FarbArten = [CsvExportFarbArt.Standardfarbe, CsvExportFarbArt.Trendfarbe] };
    public static CsvExportCombination StandardUndSonderfarbe => new() { Index = 5, Name = "Standard- und Sonderfarbe", FarbArten = [CsvExportFarbArt.Standardfarbe, CsvExportFarbArt.Sonderfarbe] };
    public static CsvExportCombination TrendUndSonderfarbe => new() { Index = 6, Name = "Trend- und Sonderfarbe", FarbArten = [CsvExportFarbArt.Trendfarbe, CsvExportFarbArt.Sonderfarbe] };
    public static CsvExportCombination Alle => new() { Index = 7, Name = "Alle", FarbArten = [CsvExportFarbArt.Standardfarbe, CsvExportFarbArt.Trendfarbe, CsvExportFarbArt.Sonderfarbe] };

    public static List<CsvExportCombination> All() => [
            None,
            Standardfarbe,
            Trendfarbe,
            Sonderfarbe,
            StandardUndTrendfarbe,
            StandardUndSonderfarbe,
            TrendUndSonderfarbe,
            Alle,
        ];
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
public enum CsvExportFarbArt
{
    Standardfarbe,
    Trendfarbe,
    Sonderfarbe,
}
