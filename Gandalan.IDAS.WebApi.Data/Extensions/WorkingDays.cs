namespace System
{
    public static class WorkingDays
    {

        public static DateTime AddWorkingDays(this DateTime datum, int days)
        {
            var direction = days < 0 ? -1 : 1;
            var count = Math.Abs(days);

            for (int i = 0; i < count; i++)
            {
                datum = datum.AddDays(direction);
                if (datum.DayOfWeek == DayOfWeek.Saturday || datum.DayOfWeek == DayOfWeek.Sunday) count++;
            }

            return datum;
        }
    }
}
