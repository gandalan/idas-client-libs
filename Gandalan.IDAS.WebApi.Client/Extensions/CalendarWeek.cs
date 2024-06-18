namespace System;

public static class CalendarWeek
{
    public static int GetCalendarWeek(this DateTime datum)
    {
        if (datum.DayOfWeek >= DayOfWeek.Monday)
        {
            datum = datum.AddDays(7 - (int)datum.DayOfWeek);
        }

        var kw = Globalization.CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(datum, Globalization.CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

        return kw;
    }
}
