using System.Collections.Generic;

namespace GeodeticPDA.Model
{
    public static class HashSetExtensions
    {
        /// <summary>
        /// Adds all elements to this <paramref name="hashSet"/>.
        /// </summary>
        /// <typeparam name="T">Any type</typeparam>
        /// <param name="hashSet">This <c>HashSet</c></param>
        /// <param name="enumerable">Elements to add</param>
        public static void AddRange<T>(this HashSet<T> hashSet, IEnumerable<T> enumerable)
        {
            foreach (var item in enumerable)
                hashSet.Add(item);
        }

    }
}
