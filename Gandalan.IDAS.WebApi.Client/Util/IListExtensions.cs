namespace System.Collections.Generic
{
    public static class IListExtensions
    {
        public static void ForEach<T>(this IList<T> list, Action<T> action)
        {
            foreach (var item in list)
            {
                action(item);
            }
        }

        public static void ForEach<T>(this IList<T> list, Func<T, bool> action)
        {
            foreach (var item in list)
            {
                action(item);
            }
        }

        public static void ForEach<T>(this IList list, Action<T> action)
        {
            foreach (T item in list)
            {
                action(item);
            }
        }

        public static void ForEach<T>(this IList list, Func<T, bool> action)
        {
            foreach (T item in list)
            {
                action(item);
            }
        }
    }
}
