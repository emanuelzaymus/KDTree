using DataStructure.Tests.RandomDataGenerator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.Tests
{
    [TestClass]
    public class KDTreeTests
    {
        [TestMethod]
        public void KDTree_NullArgument_SholudThrowArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new KDTree<int>((Comparer<int>[])null));
            Assert.ThrowsException<ArgumentNullException>(() => new KDTree<int>(new int[] { 4, 6, 8 }, (Comparer<int>[])null));
        }

        [TestMethod]
        public void KDTree_NoArgument_SholudThrowArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => new KDTree<int>());
            Assert.ThrowsException<ArgumentException>(() => new KDTree<int>(new int[] { 4, 6, 8 }));
        }

        private KDTree<int> GetIntKDTree()
        {
            return new KDTree<int>(Comparer<int>.Default);
        }

        private KDTree<int> GetIntKDTreeFilled()
        {
            return new KDTree<int>(new int[] { 50, 25, 75, 10, 30, 60, 80 }, Comparer<int>.Default);
        }

        [TestMethod]
        public void Add_PrmitiveT_ShouldAdd()
        {
            var t = GetIntKDTree();

            t.Add(54);
            Assert.AreEqual(1, t.Count);

            t.Add(22);
            Assert.AreEqual(2, t.Count);

            t.Add(100);
            Assert.AreEqual(3, t.Count);

            CollectionAssert.AreEqual(new List<int>() { 54, 22, 100 }, t.ToLevelOrderTraversalList().ToList());
        }

        [TestMethod]
        public void AddRange_PrmitiveT_ShouldAddRangeByMedians()
        {
            var t = GetIntKDTree();

            var expected = new List<int>() { 50, 25, 75, 10, 30, 60, 80 };
            expected.Reverse();
            t.AddRange(expected.ToArray());

            expected.Reverse();
            CollectionAssert.AreEqual(expected, t.ToLevelOrderTraversalList().ToList());

            var ordered = expected.OrderBy(x => x);
            t = new KDTree<int>(ordered, Comparer<int>.Default);

            CollectionAssert.AreEqual(expected, t.ToLevelOrderTraversalList().ToList());
        }

        [TestMethod]
        public void Find_PrmitiveT_ReturnsExactElement()
        {
            var t = GetIntKDTreeFilled(); // 50, 25, 75, 10, 30, 60, 80

            t.Find(10);
            CollectionAssert.AreEquivalent(new int[] { 10 }, t.Find(10).ToArray());

            t.Add(10); t.Add(10);
            CollectionAssert.AreEquivalent(new int[] { 10, 10, 10 }, t.Find(10).ToArray());
        }

        [TestMethod]
        public void FindRange_PrmitiveT_ReturnsElementsInRange()
        {
            var t = GetIntKDTreeFilled(); // 50, 25, 75, 10, 30, 60, 80

            CollectionAssert.AreEquivalent(new int[] { 10, 25, 50, 30 }, t.FindInRange(10, 50).ToArray());
            CollectionAssert.AreEquivalent(new int[] { 60 }, t.FindInRange(60, 60).ToArray());

            t.Add(75); t.Add(60);
            CollectionAssert.AreEquivalent(new int[] { 60, 60, 75, 75, 80 }, t.FindInRange(60, 10000).ToArray());
        }

        [TestMethod]
        public void Contains_PrmitiveT_ReturnsCountOfExactElements()
        {
            var t = GetIntKDTreeFilled(); // 50, 25, 75, 10, 30, 60, 80

            Assert.AreEqual(1, t.Contains(10));

            t.Add(75); t.Add(75);
            Assert.AreEqual(3, t.Contains(75));

            Assert.AreEqual(0, t.Contains(-55));
        }

        [TestMethod]
        public void ContainsInRange_PrmitiveT_ReturnsCountOfElementsInRange()
        {
            var t = GetIntKDTreeFilled(); // 50, 25, 75, 10, 30, 60, 80

            Assert.AreEqual(7, t.ContainsInRange(0, 100));
            Assert.AreEqual(3, t.ContainsInRange(25, 50));

            t.Add(75); t.Add(75);
            Assert.AreEqual(5, t.ContainsInRange(60, 80));

            Assert.AreEqual(0, t.ContainsInRange(100, 200));
        }

        [TestMethod]
        public void Remove_PrmitiveT_ReturnsCountOfRemovedElements()
        {
            var t = GetIntKDTreeFilled(); // 50, 25, 75, 10, 30, 60, 80

            Assert.AreEqual(0, t.Remove(0));
            Assert.AreEqual(1, t.Remove(25));

            t.Add(75); t.Add(75);
            Assert.AreEqual(3, t.Remove(75));
        }

        [TestMethod]
        public void RemoveRange_PrmitiveT_ReturnsCountOfRemovedElements()
        {
            var t = GetIntKDTreeFilled(); // 50, 25, 75, 10, 30, 60, 80
            t.Add(26); t.Add(26);

            Assert.AreEqual(5, t.RemoveRange(10, 49));
        }

        [TestMethod]
        public void Clear_ShouldDeleteAll()
        {
            var t = GetIntKDTreeFilled(); // 50, 25, 75, 10, 30, 60, 80

            t.Clear();

            Assert.AreEqual(0, t.Count);
            CollectionAssert.AreEqual(new int[0], t.ToLevelOrderTraversalList().ToArray());
        }

        [TestMethod]
        public void ToLevelOrderTraversalList_ShouldReturnOrderedList()
        {
            var t = GetIntKDTree();
            CollectionAssert.AreEqual(new int[0], t.ToLevelOrderTraversalList().ToArray());

            t.Add(50); t.Add(25); t.Add(75); t.Add(10); t.Add(30); t.Add(60); t.Add(80);
            CollectionAssert.AreEqual(new int[] { 50, 25, 75, 10, 30, 60, 80 }, t.ToLevelOrderTraversalList().ToArray());
        }

        private KDTree<int?> GetNullableIntKDTree()
        {
            return new KDTree<int?>(Comparer<int?>.Default);
        }

        private KDTree<int?> GetNullableIntKDTreeFilled()
        {
            return new KDTree<int?>(new int?[] { 30, null, 75, null, 25, 60, 80, null, 10, 50 }, Comparer<int?>.Default);
        }

        [TestMethod]
        public void Add_NullablePrimitiveT_ShouldAdd()
        {
            var t = GetNullableIntKDTree();

            t.Add(null);
            Assert.AreEqual(1, t.Count);

            t.Add(45);
            Assert.AreEqual(2, t.Count);
        }

        [TestMethod]
        public void AddRange_NullablePrimitiveT_ShouldAddRangeByMedians()
        {
            var t = GetNullableIntKDTree();
            var expected = new List<int?>() { 30, null, 75, null, 25, 60, 80, null, 10, 50 };
            expected.Reverse();

            t.AddRange(expected.ToArray());

            expected.Reverse();
            CollectionAssert.AreEqual(expected, t.ToLevelOrderTraversalList().ToList());

            var ordered = expected.OrderBy(x => x);
            t = GetNullableIntKDTree();
            t.AddRange(ordered.ToArray());

            CollectionAssert.AreEqual(expected, t.ToLevelOrderTraversalList().ToList());
        }

        [TestMethod]
        public void Find_NullablePrimitiveT_ShouldReturnExactData()
        {
            var t = GetNullableIntKDTreeFilled(); // 30, null, 75, null, 25, 60, 80, null, 10, 50
            CollectionAssert.AreEquivalent(new int?[] { null, null, null }, t.Find(null).ToArray());
        }

        [TestMethod]
        public void FindAt_NullablePrimitiveT_ShouldReturnDataOnPosition()
        {
            var t = GetNullableIntKDTreeFilled(); // 30, null, 75, null, 25, 60, 80, null, 10, 50
            CollectionAssert.AreEquivalent(new int?[] { null, null, null }, t.FindAt(null).ToArray());
        }

        [TestMethod]
        public void FindInRange_NullablePrimitiveT_ShouldReturnDataBetween()
        {
            var t = GetNullableIntKDTreeFilled(); // 30, null, 75, null, 25, 60, 80, null, 10, 50
            CollectionAssert.AreEquivalent(new int?[] { null, null, null }, t.FindInRange(null, null).ToArray());
            CollectionAssert.AreEquivalent(new int?[] { 30, 75, 25, 60, 80, 10, 50 }, t.FindInRange(-1000, 1000).ToArray());
            CollectionAssert.AreEquivalent(new int?[] { 30, null, 75, null, 25, 60, 80, null, 10, 50 }, t.FindInRange(null, 1000).ToArray());
            CollectionAssert.AreEquivalent(new int?[] { }, t.FindInRange(-1000, null).ToArray());
            CollectionAssert.AreEquivalent(new int?[] { }, t.FindInRange(1000, null).ToArray());
        }

        [TestMethod]
        public void Contains_NullablePrimitiveT_ShouldReturnCountOfExactElements()
        {
            var t = GetNullableIntKDTreeFilled(); // 30, null, 75, null, 25, 60, 80, null, 10, 50
            Assert.AreEqual(3, t.Contains(null));
        }

        [TestMethod]
        public void ContainsAt_NullablePrimitiveT_ShouldReturnCountOfElements()
        {
            var t = GetNullableIntKDTreeFilled(); // 30, null, 75, null, 25, 60, 80, null, 10, 50
            Assert.AreEqual(3, t.Contains(null));
        }

        [TestMethod]
        public void ContainsInRange_NullablePrimitiveT_ShouldReturnCountOfElementsInRange()
        {
            var t = GetNullableIntKDTreeFilled(); // 30, null, 75, null, 25, 60, 80, null, 10, 50
            Assert.AreEqual(3, t.ContainsInRange(null, null));
            Assert.AreEqual(7, t.ContainsInRange(-1000, 1000));
            Assert.AreEqual(10, t.ContainsInRange(null, 1000));
            Assert.AreEqual(0, t.ContainsInRange(-1000, null));
            Assert.AreEqual(0, t.ContainsInRange(1000, null));
        }

        [TestMethod]
        public void Remove_NullablePrimitiveT_ShouldReturnCountOfRemovedExactData()
        {
            var t = GetNullableIntKDTreeFilled(); // 30, null, 75, null, 25, 60, 80, null, 10, 50
            Assert.AreEqual(3, t.Remove(null));
        }

        [TestMethod]
        public void RemoveAt_NullablePrimitiveT_ShouldReturnCountOfRemovedData()
        {
            var t = GetNullableIntKDTreeFilled(); // 30, null, 75, null, 25, 60, 80, null, 10, 50
            Assert.AreEqual(3, t.RemoveAt(null));
        }

        [TestMethod]
        public void RemoveRange_NullablePrimitiveT_ShouldReturnCountOfRemovedData()
        {
            var t = GetNullableIntKDTreeFilled(); // 30, null, 75, null, 25, 60, 80, null, 10, 50
            Assert.AreEqual(3, t.RemoveRange(null, null));
            t = GetNullableIntKDTreeFilled();
            Assert.AreEqual(10, t.RemoveRange(null, 1000));
            t = GetNullableIntKDTreeFilled();
            Assert.AreEqual(7, t.RemoveRange(-1000, 1000));
            t = GetNullableIntKDTreeFilled();
            Assert.AreEqual(0, t.RemoveRange(-1000, null));
            Assert.AreEqual(0, t.RemoveRange(1000, null));
        }

        private KDTree<int?> GetObjectKDTree()
        {
            return new KDTree<int?>(Comparer<int?>.Default);
        }

        private KDTree<int?> GetObjectKDTreeFilled()
        {
            return new KDTree<int?>(new int?[] { 30, null, 75, null, 25, 60, 80, null, 10, 50 }, Comparer<int?>.Default);
        }


        [TestMethod]
        public void KDTree_PrimitiveNullableT()
        {
            var t = new KDTree<int?>(Comparer<int?>.Default);

            t.Add(55);
            t.Add(12);
            t.Add(99);
            t.Add(null);
            Assert.AreEqual(4, t.Count);

            Assert.AreEqual(55, t.Find(55).First());
            Assert.AreEqual(0, t.Find(100).Count());

            Assert.IsTrue(new HashSet<int?>() { 55, 12 }.SetEquals(t.FindInRange(0, 60)));

            Assert.AreEqual(1, t.Remove(55));
            Assert.AreEqual(3, t.Count);
        }

        [TestMethod]
        public void KDTree_ObjectT()
        {
        }

        [TestMethod]
        public void Add_AddsElement()
        {
            var xComparer = Comparer<Town>.Create((t1, t2) => t1.X.CompareTo(t2.X));
            var yComparer = Comparer<Town>.Create((t1, t2) => t1.Y.CompareTo(t2.Y));
            var tree = new KDTree<Town>(xComparer, yComparer);

            tree.Add(new Town("Town", 4, 5));

            var t = new Town("sdfs", 4, 6);
        }

        [TestMethod]
        public void AddRange_ShouldAddByMedians()
        {
        }

        //[TestMethod]
        //public void AddRange_ValidObjectData_ShouldAddByMedians()
        //{
        //}

        //[TestMethod]
        //public void AddRange_ValidPrimitiveData_ShouldAddByMedians()
        //{
        //}

        [TestMethod]
        public void Find_PresentExactData_ShouldReturnExactData()
        {
        }

        [TestMethod]
        public void Find_NotPresentExactData_ShouldReturnEmptyCollection()
        {
        }

        [TestMethod]
        public void FindAt_PresentDataPosition_ShouldReturnAllElementsOnThePosition()
        {
        }

        [TestMethod]
        public void FindAt_NotPresentDataPosition_ShouldReturnEmptyCollection()
        {
        }

        [TestMethod]
        public void FindInRange_PresentDataPosition_ShouldReturnAllElementsBetweenPositions()
        {
        }

        [TestMethod]
        public void FindInRange_NotPresentDataPosition_ShouldReturnEmptyCollection()
        {
        }

        [TestMethod]
        public void Contains_PresentExactData_ShouldReturnCountOfElements()
        {
        }

        [TestMethod]
        public void Contains_NotPresentExactData_ShouldReturn0()
        {
        }

        [TestMethod]
        public void ContainsAt_PresentDataPosition_ShouldReturnCountOfElements()
        {
        }

        [TestMethod]
        public void ContainsAt_NotPresentDataPosition_ShouldReturn0()
        {
        }

        [TestMethod]
        public void ContainsInRange_PresentDataPosition_ShouldReturnCountOfElements()
        {
        }

        [TestMethod]
        public void ContainsInRange_NotPresentDataPosition_ShouldReturn0()
        {
        }

        [TestMethod]
        public void Remove_PresentExactData_ShouldReturnCountOfRemovedElements()
        {
        }

        [TestMethod]
        public void Remove_NotPresentExactData_ShouldReturn0()
        {
        }

        [TestMethod]
        public void RemoveAt_PresentDataPosition_ShouldReturnCountOfRemovedElements()
        {
        }

        [TestMethod]
        public void RemoveAt_NotPresentDataPosition_ShouldReturn0()
        {
        }

        [TestMethod]
        public void RemoveRange_PresentDataPosition_ShouldReturnCountOfRemovedElements()
        {
        }

        [TestMethod]
        public void RemoveRange_NotPresentDataPosition_ShouldReturn0()
        {
        }

        [TestMethod]
        public void Clear_DeletesAll()
        {
        }

        [TestMethod]
        public void ToLevelOrderTraversalList_ShouldReturnAllDataInLevelOrderTraversalOrder()
        {
        }

    }
}
