using System;
using Gandalan.IDAS.WebApi.DTO;
using Newtonsoft.Json;

namespace Gandalan.IDAS.WebApi.Data.DTOs.Produktion;

public class BerechnungParameterDTO : ICloneable
{
    public Guid MandantGuid { get; set; } = Guid.Empty;

    /// <summary>
    /// Default: true
    /// </summary>
    public bool SaveResultData { get; set; } = true;

    public BelegPositionAVDTO BelegPositionAVDTO { get; set; }

    /// <summary>
    /// Default: -999
    /// </summary>
    public long VorgangsNummer { get; set; } = -999;

    /// <summary>
    /// Default: -999
    /// </summary>
    public long BelegNummer { get; set; } = -999;

    public bool IgnoreSonderwuensche { get; set; }
    public bool ReturnRawDataFile { get; set; }
    public string RawDataFileContent { get; set; }

    public object Clone()
    {
        var jsonString = JsonConvert.SerializeObject(this);
        return JsonConvert.DeserializeObject<BerechnungParameterDTO>(jsonString);
    }
}

public class BerechnungResultDTO
{
    public BelegPositionDTO OriginalBelegPosition { get; set; }
    public Guid BelegPositionGuid { get; set; }
    public string RawDataFileContent { get; set; }
    public ProduktionsDatenDTO ProduktionsDaten { get; set; }
}
