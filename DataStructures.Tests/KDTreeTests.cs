using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.Tests
{
    [TestClass]
    public class KDTreeTests
    {
        [TestMethod]
        public void KDTree_PrimitiveT()
        {
            var t = new KDTree<int>(Comparer<int>.Default);

            t.Add(54);
            Assert.AreEqual(1, t.Count);

            Assert.AreEqual(54, t.Find(54).First());
            Assert.AreEqual(0, t.Find(100).Count());

            Assert.AreEqual(1, t.Remove(54));
            Assert.AreEqual(0, t.Count);
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
