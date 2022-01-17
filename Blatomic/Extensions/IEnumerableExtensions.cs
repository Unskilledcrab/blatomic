using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blatomic.Extensions
{
    public static class IEnumerableExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T>? data)
        {
            return data == null || !data.Any();
        }
        public static bool HasAny<T>(this IEnumerable<T>? data)
        {
            return data != null && data.Any();
        }
    }
}
