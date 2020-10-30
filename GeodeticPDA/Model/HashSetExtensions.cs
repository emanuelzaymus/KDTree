using System.Collections.Generic;

namespace GeodeticPDA.Model
{
    public static class HashSetExtensions
    {
        public static void AddRange<T>(this HashSet<T> hashSet, IEnumerable<T> enumerable)
        {
            foreach (var item in enumerable)
                hashSet.Add(item);
        }

    }
}
