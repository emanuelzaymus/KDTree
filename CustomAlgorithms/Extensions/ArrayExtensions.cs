namespace CustomAlgorithms.Extensions
{
    public static class ArrayExtensions
    {
        /// <summary>
        /// Swaps two elements A and B in the array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="posA">Position of the element A</param>
        /// <param name="posB">Position of the element B</param>
        /// <returns></returns>
        /// <exception cref="System.IndexOutOfRangeException"></exception>
        public static T[] Swap<T>(this T[] array, int posA, int posB)
        {
            var temp = array[posA];
            array[posA] = array[posB];
            array[posB] = temp;
            return array;
        }
    }
}
