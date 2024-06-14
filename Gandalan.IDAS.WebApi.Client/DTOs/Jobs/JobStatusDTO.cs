using System;

namespace Gandalan.IDAS.WebApi.DTO;

public class JobStatusDTO
{
    public Guid JobStatusId { get; set; }
    public Guid JobId { get; set; }
    public DateTime Zeitstempel { get; set; }
    public string StatusCode { get; set; }
    public string StatusText { get; set; }
    public int StatusCodeAsInt
    {
        get
        {
                switch (StatusCode)
                {
                    case "N": return 10;
                    case "A": return 20;
                    case "R": return 30;
                    case "F": return 40;
                    case "X": return 50;
                    case "E": return 60;
                    default:
                        return 100;
                }
            }
    }
}