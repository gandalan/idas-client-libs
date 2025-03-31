namespace System;

public static class DateTimeExtensions
{
    /// <summary>
    /// Datenbankwerte werden beim Speichern gerundet auf Vielfache von 3,33 ms und können daher nicht mit == verglichen werden.
    /// https://learn.microsoft.com/en-us/sql/t-sql/data-types/datetime-transact-sql?view=sql-server-ver15
    /// </summary>
    public static bool IsEqualRounded(this DateTime dateTime1, DateTime dateTime2, int deltaInMs = 10)
    {
        return Math.Abs((dateTime1.Subtract(dateTime2)).TotalMilliseconds) <= deltaInMs;
    }
}
