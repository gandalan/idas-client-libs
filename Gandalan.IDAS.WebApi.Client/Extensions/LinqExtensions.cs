#if NETFRAMEWORK
using System.Collections;
#endif
using System.Collections.Generic;

namespace System.Linq;

public static class LinqExtensions
{
#if NETFRAMEWORK
    /// <summary>Faster Linq code from .NET 9. Determines whether a sequence contains any elements.</summary>
    /// <param name="source">The <see cref="T:System.Collections.Generic.IEnumerable`1" /> to check for emptiness.</param>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <returns>
    /// <see langword="true" /> if the source sequence contains any elements; otherwise, <see langword="false" />.</returns>
    /// <exception cref="T:System.ArgumentNullException">
    /// <paramref name="source" /> is <see langword="null" />.</exception>
    public static bool AnyOptimized<TSource>(this IEnumerable<TSource> source)
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

        using var e = source.GetEnumerator();
        return e.MoveNext();
    }
#endif

#if NET
#pragma warning disable CS0618 // Suppress the warning for obsolete code
    /// <inheritdoc cref="Enumerable.Any{TSource}(System.Collections.Generic.IEnumerable{TSource})"/>
    /// <remarks>
    /// This method is available for compatibility purposes and should be used only for <c>Gandalan.IDAS.Libs</c> solution. In .NET Core or later versions, the built-in
    /// <see cref="System.Linq.Enumerable.Any{TSource}(System.Collections.Generic.IEnumerable{TSource})"/>
    /// method is optimized and should be used instead.
    /// </remarks>
    [Obsolete("Use the built-in Enumerable.Any() method in .NET Core or later for better performance.")]
    public static bool AnyOptimized<TSource>(this IEnumerable<TSource> source)
    {
        return source.Any();
    }
#pragma warning restore CS0618 // Restore the warning for obsolete code
#endif
}
