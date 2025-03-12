using System;

namespace Gandalan.IDAS.WebApi.Client.DTOs.Dates;

/// <summary>
/// Represents a time range with a start and end date including time.
/// Both start and end date have an unspecified kind to avoid timezone issues.
/// </summary>
public class ZeitraumDTO
{
    public DateTime Von { get; set; }

    public DateTime Bis { get; set; }

    /// <exception cref="ArgumentException">If the start date is after the end date</exception>
    private ZeitraumDTO(DateTime von, DateTime bis)
    {
        if (von > bis)
        {
            throw new ArgumentException("Start date must be before end date.");
        }
        // Create Dates with kind set to Unspecified to avoid timezone issues
        Von = new DateTime(von.Year, von.Month, von.Day, 0, 0, 0);
        Bis = new DateTime(bis.Year, bis.Month, bis.Day, 23, 59, 59);
    }

    /// <summary>
    /// Creates a time range with the specified start and end date.
    /// Both start and end date have an unspecified kind to avoid timezone issues.
    /// </summary>
    /// <param name="von">Startdatum (wird auf 00:00:00 gesetzt)</param>
    /// <param name="bis">Enddatum (wird auf 23:59:59 gesetzt)</param>
    public static ZeitraumDTO CreateFullDayRange(DateTime von, DateTime bis)
        => new(von.Date, bis.Date);

    public override string ToString()
        => $"{Von:yyyy-MM-dd HH:mm:ss} - {Bis:yyyy-MM-dd HH:mm:ss}";
}
