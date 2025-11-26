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
}