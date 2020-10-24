using CustomExtensions;
using System;

namespace CustomCalculations
{
    public class Medians
    {
        /// <summary>
        /// Quick Select algorithm to find <paramref name="k"/>-th smallest element in the <paramref name="array"/>.
        /// Adopted from <see cref="https://en.wikipedia.org/wiki/Quickselect"/>.
        /// </summary>
        /// <param name="array">Array of elements</param>
        /// <param name="left">Left bound of the <paramref name="array"/></param>
        /// <param name="right">Right bound of the <paramref name="array"/></param>
        /// <param name="k">K-th smallest element to be returned</param>
        /// <returns>Returns <paramref name="k"/>-th smallest element of the array within <paramref name="left"/> and <paramref name="right"/> inclusive.</returns>
        public static int QuickSelect(int[] array, int left, int right, int k)
        {
            Random rnd = new Random();
            while (true)
            {
                if (left == right)
                {
                    return array[left];
                }
                int pivotIndex = rnd.Next(left, right);
                pivotIndex = Partition(array, left, right, pivotIndex);

                if (k == pivotIndex)
                    return array[k];
                else if (k < pivotIndex)
                    right = pivotIndex - 1;
                else
                    left = pivotIndex + 1;
            }
        }

        private static int Partition(int[] array, int left, int right, int pivotIndex)
        {
            var pivotValue = array[pivotIndex];
            array.Swap(pivotIndex, right);

            int storeIndex = left;
            for (int i = left; i < right; i++)
            {
                if (array[i] < pivotValue)
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
