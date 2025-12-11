using System.Globalization;

namespace System;

public static class DateTimeExtensions
{
    public static int GetCalendarWeek(this DateTime datum)
    {
        if (datum.DayOfWeek >= DayOfWeek.Monday)
        {
            datum = datum.AddDays(7 - (int)datum.DayOfWeek);
        }

        var kw = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(datum, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

        return kw;
    }

    public static DateTime AddWorkingDays(this DateTime datum, int days)
    {
        var direction = days < 0 ? -1 : 1;
        var count = Math.Abs(days);

        for (var i = 0; i < count; i++)
        {
            datum = datum.AddDays(direction);
            if (datum.DayOfWeek == DayOfWeek.Saturday || datum.DayOfWeek == DayOfWeek.Sunday)
            {
                count++;
            }
        }

        return datum;
    }

    public static DateTime AddWorkingHours(this DateTime datum, int hours)
    {
        datum = datum.AddHours(hours);

        while (datum.DayOfWeek == DayOfWeek.Saturday || datum.DayOfWeek == DayOfWeek.Sunday)
        {
            datum = datum.AddWorkingDays(1);
        }

        return datum;
    }

    /// <summary>
    /// From <see href="https://github.com/dotnet/corert/blob/master/src/System.Private.CoreLib/shared/System/Globalization/ISOWeek.cs"/>
    /// </summary>
    public static DateTime ToDateTime(int year, int week, DayOfWeek dayOfWeek)
    {
        var jan4 = new DateTime(year, month: 1, day: 4);
        var correction = GetWeekday(jan4.DayOfWeek) + 3;
        var ordinal = (week * 7) + GetWeekday(dayOfWeek) - correction;
        return new DateTime(year, month: 1, day: 1).AddDays(ordinal - 1);
    }

    private static int GetWeekday(DayOfWeek dayOfWeek)
    {
        return dayOfWeek == DayOfWeek.Sunday ? 7 : (int)dayOfWeek;
    }

    /// <summary>
    /// Datenbankwerte werden beim Speichern gerundet auf Vielfache von 3,33 ms und können daher nicht mit == verglichen werden.
    /// https://learn.microsoft.com/en-us/sql/t-sql/data-types/datetime-transact-sql?view=sql-server-ver15
    /// </summary>
    public static bool IsEqualRounded(this DateTime? dateTime1, DateTime? dateTime2, int deltaInMs = 10)
    {
        if (dateTime1 == null || dateTime2 == null)
            return dateTime1 == dateTime2;

        return dateTime1.Value.IsEqualRounded(dateTime2.Value, deltaInMs);
    }

    /// <summary>
    /// Datenbankwerte werden beim Speichern gerundet auf Vielfache von 3,33 ms und können daher nicht mit == verglichen werden.
    /// https://learn.microsoft.com/en-us/sql/t-sql/data-types/datetime-transact-sql?view=sql-server-ver15
    /// </summary>
    public static bool IsEqualRounded(this DateTime dateTime1, DateTime dateTime2, int deltaInMs = 10)
    {
        return Math.Abs((dateTime1.Subtract(dateTime2)).TotalMilliseconds) <= deltaInMs;
    }
}
