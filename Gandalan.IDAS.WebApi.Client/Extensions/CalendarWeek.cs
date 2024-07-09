using System.Globalization;

namespace System;

public static class CalendarWeek
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
}
