using System.Collections.Generic;
using System.Linq;

namespace ProofOfConcept.Common.Extensions
{
    public static class IEnumerableExtension
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return !enumerable?.Any() ?? true;
        }
    }
}