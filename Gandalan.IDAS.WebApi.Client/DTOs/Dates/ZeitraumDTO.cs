using System;

namespace Gandalan.IDAS.WebApi.Client.DTOs.Dates;

/// <summary>
/// Repräsentiert einen Zeitraum mit einem Start- und Enddatum inklusive Uhrzeit.
/// Das Startdatum wird auf 00:00 Uhr gesetzt und das Enddatum auf 23:59:59 des angegebenen Enddatums.
/// </summary>
public class ZeitraumDTO
{
    /// <summary>
    /// Startdatum und -uhrzeit des Zeitraums.
    /// </summary>
    public DateTime Von { get; set; }

    /// <summary>
    /// Enddatum und -uhrzeit des Zeitraums.
    /// </summary>
    public DateTime Bis { get; set; }

    /// <summary>
    /// Erstellt einen Zeitraum mit dem angegebenen Start- und Enddatum.
    /// </summary>
    /// <param name="von">Startdatum und -uhrzeit</param>
    /// <param name="bis">Enddatum und -uhrzeit</param>
    /// <exception cref="ArgumentException">Falls das Startdatum nach dem Enddatum liegt</exception>
    private ZeitraumDTO(DateTime von, DateTime bis)
    {
        if (von > bis) throw new ArgumentException("Start date must be before end date.");
        Von = von;
        Bis = bis;
    }

    /// <summary>
    /// Erstellt einen Zeitraum, bei dem das Startdatum auf 00:00 Uhr gesetzt wird und das Enddatum auf 23:59:59 des angegebenen Enddatums.
    /// </summary>
    /// <param name="von">Startdatum (wird auf 00:00:00 gesetzt)</param>
    /// <param name="bis">Enddatum (wird auf 23:59:59 gesetzt)</param>
    public static ZeitraumDTO CreateFullDayRange(DateTime von, DateTime bis)
        => new(von.Date, bis.Date.AddDays(1).AddSeconds(-1));

    public override string ToString()
        => $"{Von:yyyy-MM-dd HH:mm:ss} - {Bis:yyyy-MM-dd HH:mm:ss}";
}
