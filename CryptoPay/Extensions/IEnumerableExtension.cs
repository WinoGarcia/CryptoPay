using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CryptoPay.Extensions;

/// <summary>
/// Enumerable extension class.
/// </summary>
public static class EnumerableExtensions
{
    /// <summary>
    /// Join item from enumerable if it is not null or empty.
    /// </summary>
    /// <param name="self"><see cref="IEnumerable{T}"/>.</param>
    /// <param name="delimiter">Separator.</param>
    /// <returns></returns>
    public static string Join<T>(this IEnumerable<T> self, string delimiter)
    {
        if (self is not null && self.Any())
        {
            var sb = new StringBuilder();
            sb.AppendJoin(delimiter, self);
            return sb.ToString();
        }

        return default;
    }
}