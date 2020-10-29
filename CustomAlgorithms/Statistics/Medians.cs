using CustomAlgorithms.Extensions;
using System;

namespace CustomAlgorithms.Statistics
{
    public class Medians
    {
        /// <summary>
        /// Uses Quick Select algorithm to find median. Median is determined 
        /// as <c>(array.Length / 2)</c> smallest element of the <paramref name="array"/>.
        /// </summary>
        /// <param name="array">Array to choose median from</param>
        /// <returns>Median of the <paramref name="array"/></returns>
        public static T QuickSelectMedian<T>(T[] array) where T : IComparable<T>
        {
            return QuickSelect(array, 0, array.Length - 1, array.Length / 2);
        }

        /// <summary>
        /// Quick Select algorithm to find <paramref name="k"/>-th smallest element in the <paramref name="array"/>.
        /// Adopted from <see cref="https://en.wikipedia.org/wiki/Quickselect"/>.
        /// </summary>
        /// <param name="array">Array of elements</param>
        /// <param name="left">Left bound of the <paramref name="array"/></param>
        /// <param name="right">Right bound of the <paramref name="array"/></param>
        /// <param name="k">K-th smallest element to be returned</param>
        /// <returns><paramref name="k"/>-th smallest element of the array within <paramref name="left"/> 
        /// and <paramref name="right"/> inclusive</returns>
        public static T QuickSelect<T>(T[] array, int left, int right, int k) where T : IComparable<T>
        {
            return QuickSelect(array, left, right, k, (x, y) => x.CompareTo(y)); // Comparer<T>.Default.Compare
        }

        /// <summary>
        /// Quick Select algorithm to find <paramref name="k"/>-th smallest element in the <paramref name="array"/>.
        /// Adopted from <see cref="https://en.wikipedia.org/wiki/Quickselect"/>.
        /// </summary>
        /// <param name="array">Array of elements</param>
        /// <param name="left">Left bound of the <paramref name="array"/></param>
        /// <param name="right">Right bound of the <paramref name="array"/></param>
        /// <param name="k">K-th smallest element to be returned</param>
        /// <param name="comparison">Comparison method to compare two elements from the <paramref name="array"/></param>
        /// <returns><paramref name="k"/>-th smallest element of the array within <paramref name="left"/> 
        /// and <paramref name="right"/> inclusive</returns>
        public static T QuickSelect<T>(T[] array, int left, int right, int k, Comparison<T> comparison)
        {
            Random rnd = new Random();
            while (true)
            {
                if (left == right)
                {
                    return array[left];
                }
                int pivotIndex = rnd.Next(left, right);
                pivotIndex = Partition(array, left, right, pivotIndex, comparison);

                if (k == pivotIndex)
                    return array[k];
                else if (k < pivotIndex)
                    right = pivotIndex - 1;
                else
                    left = pivotIndex + 1;
            }
        }

        private static int Partition<T>(T[] array, int left, int right, int pivotIndex, Comparison<T> comparison)
        {
            var pivotValue = array[pivotIndex];
            array.Swap(pivotIndex, right);

            int storeIndex = left;
            for (int i = left; i < right; i++)
            {
                if (comparison(array[i], pivotValue) < 0)
                {
                    array.Swap(storeIndex, i);
                    storeIndex++;
                }
            }
            array.Swap(right, storeIndex);
            return storeIndex;
        }

    }
}