using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Collections.Generic
{
    public static class IListExtensions
    {
        public static void ForEach<T>(this IList<T> list, System.Action<T> action) 
        {
            foreach (T item in list)
                action(item);
        }

        public static void ForEach<T>(this IList<T> list, System.Func<T, bool> action)
        {
            foreach (T item in list)
                action(item);
        }

        public static void ForEach<T>(this IList list, System.Action<T> action)
        {
            foreach (T item in list)
                action(item);
        }

        public static void ForEach<T>(this IList list, System.Func<T, bool> action)
        {
            foreach (T item in list)
                action(item);
        }

    }
}
