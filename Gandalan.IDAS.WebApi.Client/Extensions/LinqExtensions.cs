#if NETFRAMEWORK //|| true // Uncomment || to see code formatting in Visual Studio

using System.Collections;
using System.Collections.Generic;

namespace System.Linq;

/// <summary>
/// Faster Linq code from .NET 9
/// </summary>
public static class LinqExtensions
{
    /// <summary>Determines whether a sequence contains any elements.</summary>
    /// <param name="source">The <see cref="T:System.Collections.Generic.IEnumerable`1" /> to check for emptiness.</param>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <returns>
    /// <see langword="true" /> if the source sequence contains any elements; otherwise, <see langword="false" />.</returns>
    /// <exception cref="T:System.ArgumentNullException">
    /// <paramref name="source" /> is <see langword="null" />.</exception>
    public static bool Any<TSource>(this IEnumerable<TSource> source)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (source is ICollection<TSource> gc)
        {
            return gc.Count != 0;
        }

        if (source is ICollection ngc)
        {
            return ngc.Count != 0;
        }

        using IEnumerator<TSource> e = source.GetEnumerator();
        return e.MoveNext();
    }
}

#endif
