namespace System
{
    public static class WorkingDays
    {
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
}
