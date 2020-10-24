using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CustomCalculations.Tests
{
    [TestClass]
    public class MediansTests
    {
        [TestMethod]
        public void QuickSelectMedian_OddNumberOfParameters_ReturnsMedian()
        {
            int[] array = new int[] { 7, 1, 4, 3, 6, 8, 2, 9, 5 };
            int res = Medians.QuickSelectMedian<int>(array);
            Assert.AreEqual(5, res);
        }

        [TestMethod]
        public void QuickSelectMedian_EvenNumberOfParameters_ReturnsMedian()
        {
            int[] array = new int[] { 7, 1, 4, 3, 6, 8, 2, 9, 5, 10 };
            int res = Medians.QuickSelectMedian<int>(array);
            Assert.AreEqual(6, res);
        }

        [TestMethod]
        public void QuickSelect_FuzzyData_ReturnsMedians()
        {
            Random r = new Random();
            for (int i = 0; i < 100; i++)
            {
                int median = r.Next(-1000000, 1000000);
                int surroundingNumberOfData = r.Next(100000);
                int scale = r.Next(10, 1000);

                QuickSelect_Parameters_ReturnsMedians(median, surroundingNumberOfData, scale);
            }
        }

        private void QuickSelect_Parameters_ReturnsMedians(int median = 500, int surroundingNumberOfData = 100, int scale = 10)
        {
            // Prepare
            Random r = new Random();
            int dataCount = surroundingNumberOfData * 2 + 1; // 100 * 2 + 1 = 201
            int lowerBound = median - surroundingNumberOfData * scale; // 500 - 100 * 10 = -500
            int upperBound = median + surroundingNumberOfData * scale; // 500 + 100 * 10 = 1500

            var list = new int[dataCount];

            for (int i = 0; i < surroundingNumberOfData; i++) // 0..99
            {
                list[i] = r.Next(lowerBound, median); // Random between -500..499
            }
            for (int i = surroundingNumberOfData; i < dataCount; i++) // 100..201
            {
                list[i] = r.Next(median, upperBound); // Random between 501..1500
            }
            list[r.Next(surroundingNumberOfData, dataCount)] = median; // Insert the median 500

            // Act
            var actualRes = Medians.QuickSelect<int>(list, left: 0, right: (list.Length - 1), k: (list.Length / 2));

            // Test
            Assert.AreEqual(median, actualRes);
            Assert.AreEqual(median, list[surroundingNumberOfData]);

            for (int i = 0; i < surroundingNumberOfData; i++)
            {
                Assert.IsTrue(list[i] <= median);
            }
            for (int i = surroundingNumberOfData; i < dataCount; i++)
            {
                Assert.IsTrue(list[i] >= median);
            }
        }

    }
}
