namespace System;
public static class ExceptionExtensions
{
    public static T FindInnerExceptionOfType<T>(this Exception ex) where T : Exception
    {
        if (ex == null)
        {
            return null;
        }

        if (ex is T foundEx)
        {
            return foundEx;
        }

        if (ex is AggregateException aggregateException)
        {
            foreach (var innerEx in aggregateException.InnerExceptions)
            {
                foundEx = innerEx.FindInnerExceptionOfType<T>();
                if (foundEx != null)
                {
                    return foundEx;
                }
            }
        }

        if (ex.InnerException is T innerException)
        {
            return innerException;
        }

        return ex.InnerException?.FindInnerExceptionOfType<T>();
    }
}
