using DataStructures.KDTree;
using DataStructures.Tests.TestClasses;
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

            CollectionAssert.AreEqual(new List<int>() { 54, 22, 100 }, t.ToLevelOrderTraversalList());
        }

        [TestMethod]
        public void AddRange_PrmitiveT_ShouldAddRangeByMedians()
        {
            var t = GetIntKDTree();

            var expected = new List<int>() { 50, 25, 75, 10, 30, 60, 80 };
            expected.Reverse();
            t.AddRange(expected.ToArray());

            expected.Reverse();
            CollectionAssert.AreEqual(expected, t.ToLevelOrderTraversalList());

            var ordered = expected.OrderBy(x => x);
            t = new KDTree<int>(ordered, Comparer<int>.Default);

            CollectionAssert.AreEqual(expected, t.ToLevelOrderTraversalList());
        }

        [TestMethod]
        public void Find_PrmitiveT_ReturnsExactElement()
        {
            var t = GetIntKDTreeFilled(); // 50, 25, 75, 10, 30, 60, 80

            t.Find(10);
            CollectionAssert.AreEquivalent(new[] { 10 }, t.Find(10).ToArray());

            t.Add(10); t.Add(10);
            CollectionAssert.AreEquivalent(new[] { 10, 10, 10 }, t.Find(10).ToArray());
        }

        [TestMethod]
        public void FindRange_PrmitiveT_ReturnsElementsInRange()
        {
            var t = GetIntKDTreeFilled(); // 50, 25, 75, 10, 30, 60, 80

            CollectionAssert.AreEquivalent(new[] { 10, 25, 50, 30 }, t.FindRange(10, 50).ToArray());
            CollectionAssert.AreEquivalent(new[] { 60 }, t.FindRange(60, 60).ToArray());

            t.Add(75); t.Add(60);
            CollectionAssert.AreEquivalent(new[] { 60, 60, 75, 75, 80 }, t.FindRange(60, 10000).ToArray());
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
        public void ContainsRange_PrmitiveT_ReturnsCountOfElementsInRange()
        {
            var t = GetIntKDTreeFilled(); // 50, 25, 75, 10, 30, 60, 80

            Assert.AreEqual(7, t.ContainsRange(0, 100));
            Assert.AreEqual(3, t.ContainsRange(25, 50));

            t.Add(75); t.Add(75);
            Assert.AreEqual(5, t.ContainsRange(60, 80));

            Assert.AreEqual(0, t.ContainsRange(100, 200));
        }

        [TestMethod]
        public void Remove_PrmitiveT_ReturnsCountOfRemovedElements()
        {
            var t = GetIntKDTreeFilled(); // 50, 25, 75, 10, 30, 60, 80

            Assert.AreEqual(0, t.Remove(0));
            Assert.AreEqual(1, t.Remove(25));
            CollectionAssert.AreEqual(new[] { 50, 10, 75, 30, 60, 80 }, t.ToLevelOrderTraversalList());

            t.Add(75); t.Add(75);
            Assert.AreEqual(3, t.Remove(75));
            CollectionAssert.AreEqual(new[] { 50, 10, 60, 30, 80 }, t.ToLevelOrderTraversalList());
        }

        [TestMethod]
        public void RemoveRange_PrmitiveT_ReturnsCountOfRemovedElements()
        {
            var t = GetIntKDTreeFilled(); // 50, 25, 75, 10, 30, 60, 80
            t.Add(26); t.Add(26);

            Assert.AreEqual(5, t.RemoveRange(10, 49));
            CollectionAssert.AreEqual(new[] { 50, 75, 60, 80 }, t.ToLevelOrderTraversalList());
        }

        [TestMethod]
        public void Clear_ShouldDeleteAll()
        {
            var t = GetIntKDTreeFilled(); // 50, 25, 75, 10, 30, 60, 80

            t.Clear();

            Assert.AreEqual(0, t.Count);
            CollectionAssert.AreEqual(new int[0], t.ToLevelOrderTraversalList());
        }

        [TestMethod]
        public void ToLevelOrderTraversalList_ShouldReturnOrderedList()
        {
            var t = GetIntKDTree();
            CollectionAssert.AreEqual(new int[0], t.ToLevelOrderTraversalList());

            t.Add(50); t.Add(25); t.Add(75); t.Add(10); t.Add(30); t.Add(60); t.Add(80);
            CollectionAssert.AreEqual(new[] { 50, 25, 75, 10, 30, 60, 80 }, t.ToLevelOrderTraversalList());
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

            t.Add(-12); t.Add(100);
            CollectionAssert.AreEqual(new int?[] { null, 45, -12, 100 }, t.ToLevelOrderTraversalList());
        }

        [TestMethod]
        public void AddRange_NullablePrimitiveT_ShouldAddRangeByMedians()
        {
            var t = GetNullableIntKDTree();
            var expected = new List<int?>() { 30, null, 75, null, 25, 60, 80, null, 10, 50 };
            expected.Reverse();

            t.AddRange(expected.ToArray());

            expected.Reverse();
            CollectionAssert.AreEqual(expected, t.ToLevelOrderTraversalList());

            var ordered = expected.OrderBy(x => x);
            t = GetNullableIntKDTree();
            t.AddRange(ordered.ToArray());

            CollectionAssert.AreEqual(expected, t.ToLevelOrderTraversalList());
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
        public void FindRange_NullablePrimitiveT_ShouldReturnDataBetween()
        {
            var t = GetNullableIntKDTreeFilled(); // 30, null, 75, null, 25, 60, 80, null, 10, 50
            CollectionAssert.AreEquivalent(new int?[] { null, null, null }, t.FindRange(null, null).ToArray());
            CollectionAssert.AreEquivalent(new int?[] { 30, 75, 25, 60, 80, 10, 50 }, t.FindRange(-1000, 1000).ToArray());
            CollectionAssert.AreEquivalent(new int?[] { 30, null, 75, null, 25, 60, 80, null, 10, 50 }, t.FindRange(null, 1000).ToArray());
            CollectionAssert.AreEquivalent(new int?[] { }, t.FindRange(-1000, null).ToArray());
            CollectionAssert.AreEquivalent(new int?[] { }, t.FindRange(1000, null).ToArray());
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
        public void ContainsRange_NullablePrimitiveT_ShouldReturnCountOfElementsInRange()
        {
            var t = GetNullableIntKDTreeFilled(); // 30, null, 75, null, 25, 60, 80, null, 10, 50
            Assert.AreEqual(3, t.ContainsRange(null, null));
            Assert.AreEqual(7, t.ContainsRange(-1000, 1000));
            Assert.AreEqual(10, t.ContainsRange(null, 1000));
            Assert.AreEqual(0, t.ContainsRange(-1000, null));
            Assert.AreEqual(0, t.ContainsRange(1000, null));
        }

        [TestMethod]
        public void Remove_NullablePrimitiveT_ShouldReturnCountOfRemovedExactData()
        {
            var t = GetNullableIntKDTreeFilled(); // 30, null, 75, null, 25, 60, 80, null, 10, 50
            Assert.AreEqual(3, t.Remove(null));
            CollectionAssert.AreEqual(new int?[] { 30, 25, 75, 10, 60, 80, 50 }, t.ToLevelOrderTraversalList());
        }

        [TestMethod]
        public void RemoveAt_NullablePrimitiveT_ShouldReturnCountOfRemovedData()
        {
            var t = GetNullableIntKDTreeFilled(); // 30, null, 75, null, 25, 60, 80, null, 10, 50
            Assert.AreEqual(3, t.RemoveAt(null));
            CollectionAssert.AreEqual(new int?[] { 30, 25, 75, 10, 60, 80, 50 }, t.ToLevelOrderTraversalList());
        }

        [TestMethod]
        public void RemoveRange_NullablePrimitiveT_ShouldReturnCountOfRemovedData()
        {
            var t = GetNullableIntKDTreeFilled(); // 30, null, 75, null, 25, 60, 80, null, 10, 50
            Assert.AreEqual(3, t.RemoveRange(null, null));
            CollectionAssert.AreEqual(new int?[] { 30, 25, 75, 10, 60, 80, 50 }, t.ToLevelOrderTraversalList());
            t = GetNullableIntKDTreeFilled();
            Assert.AreEqual(10, t.RemoveRange(null, 1000));
            Assert.AreEqual(0, t.Count);
            t = GetNullableIntKDTreeFilled();
            Assert.AreEqual(7, t.RemoveRange(-1000, 1000));
            CollectionAssert.AreEqual(new int?[] { null, null, null }, t.ToLevelOrderTraversalList());
            t = GetNullableIntKDTreeFilled();
            Assert.AreEqual(0, t.RemoveRange(-1000, null));
            Assert.AreEqual(0, t.RemoveRange(1000, null));
        }

        private KDTree<Town> GetTownKDTree()
        {
            return new KDTree<Town>(Town.GetComparers());
        }

        private KDTree<Town> GetTownKDTreeFilled()
        {
            var t = GetTownKDTree();

            t.Add(new Town("Nitra", 23, 35));

            t.Add(new Town("Sered", 20, 33));
            t.Add(new Town("Topolcianky", 25, 36));

            t.Add(new Town("Galanta", 16, 31));
            t.Add(new Town("Senica", 14, 39));
            t.Add(new Town("Tlmace", 28, 34));
            t.Add(new Town("Bosany", 24, 40));

            t.Add(new Town("Bratislava", 13, 32));
            t.Add(new Town("Hodonin", 12, 41));
            t.Add(new Town("Trnava", 17, 42));
            t.Add(new Town("Moravce", 26, 35));
            t.Add(new Town("Levice", 30, 33));
            t.Add(new Town("Bojnice", 29, 46));

            t.Add(new Town("Novaky", 27, 43));

            return t;
        }

        [TestMethod]
        public void Add_Object_ShouldAdd()
        {
            var t = GetTownKDTree();

            t.Add(new Town("MyTown", 45, 98));
            Assert.AreEqual(1, t.Count);
        }

        [TestMethod]
        public void AddRange_Object_ShouldAddRangeByMedians()
        {
            var t = GetTownKDTree();
            var towns = new[] {
                new Town("Nitra", 23, 35), new Town("Sered", 20, 33), new Town("Topolcianky", 25, 36),
                new Town("Galanta", 16, 31), new Town("Senica", 14, 39), new Town("Tlmace", 28, 34),
                new Town("Bosany", 24, 40), new Town("Bratislava", 13, 32),new Town("Hodonin", 12, 41),
                new Town("Trnava", 17, 42), new Town("Moravce", 26, 35),new Town("Levice", 30, 33),
                new Town("Bojnice", 29, 46),new Town("Novaky", 27, 43)
                };
            var expected = new[] {
                new Town("Bosany", 24, 40),
                new Town("Nitra", 23, 35),
                new Town("Topolcianky", 25, 36),
                new Town("Galanta", 16, 31),
                new Town("Senica", 14, 39),
                new Town("Tlmace", 28, 34),
                new Town("Bojnice", 29, 46),
                new Town("Bratislava", 13, 32),
                new Town("Sered", 20, 33),
                new Town("Hodonin", 12, 41),
                new Town("Trnava", 17, 42),
                new Town("Moravce", 26, 35),
                new Town("Levice", 30, 33),
                new Town("Novaky", 27, 43)
                };

            t.AddRange(towns);

            CollectionAssert.AreEqual(expected, t.ToLevelOrderTraversalList());
        }

        [TestMethod]
        public void Find_PresentExactObjectData_ShouldReturnExactData()
        {
            var t = GetTownKDTreeFilled();
            CollectionAssert.AreEquivalent(new[] { new Town("Novaky", 27, 43) }, t.Find(new Town("Novaky", 27, 43)).ToArray());

            t.Add(new Town("Sered", 20, 33));
            CollectionAssert.AreEquivalent(new[] { new Town("Sered", 20, 33), new Town("Sered", 20, 33) }, t.Find(new Town("Sered", 20, 33)).ToArray());
        }

        [TestMethod]
        public void Find_NotPresentExactObjectData_ShouldReturnEmptyCollection()
        {
            var t = GetTownKDTreeFilled();
            CollectionAssert.AreEquivalent(new Town[] { }, t.Find(new Town("TOWN", 27, 43)).ToArray());
        }

        [TestMethod]
        public void FindAt_PresentObjectDataPosition_ShouldReturnAllElementsOnThePosition()
        {
            var t = GetTownKDTreeFilled();
            t.Add(new Town("Praha", 27, 43)); t.Add(new Town("Brno", 27, 43));
            CollectionAssert.AreEquivalent(new[] { new Town("Novaky", 27, 43), new Town("Praha", 27, 43), new Town("Brno", 27, 43) },
                t.FindAt(new TownPosition(27, 43)).ToArray());
        }

        [TestMethod]
        public void FindAt_NotPresentObjectDataPosition_ShouldReturnEmptyCollection()
        {
            var t = GetTownKDTreeFilled();
            CollectionAssert.AreEquivalent(new Town[] { }, t.FindAt(new TownPosition(100, 43)).ToArray());
        }

        [TestMethod]
        public void FindRange_PresentObjectDataPosition_ShouldReturnAllElementsBetweenPositions()
        {
            var t = GetTownKDTreeFilled();
            var expected = new[] {
                new Town("Galanta", 16, 31),
                new Town("Sered", 20, 33),
                new Town("Nitra", 23, 35),
                new Town("Bosany", 24, 40),
                new Town("Topolcianky", 25, 36),
                new Town("Moravce", 26, 35),
                new Town("Tlmace", 28, 34)
            };
            Town[] actual = t.FindRange(new TownPosition(15, 0), new TownPosition(29, 40)).ToArray();
            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void FindRange_NotPresentObjectDataPosition_ShouldReturnEmptyCollection()
        {
            var t = GetTownKDTreeFilled();
            CollectionAssert.AreEquivalent(new Town[0], t.FindRange(new TownPosition(31, 0), new TownPosition(60, 30)).ToArray());
            CollectionAssert.AreEquivalent(new Town[0], t.FindRange(new TownPosition(30, 50), new TownPosition(0, 30)).ToArray());
        }

        [TestMethod]
        public void Contains_PresentExactObjectData_ShouldReturnCountOfElements()
        {
            var t = GetTownKDTreeFilled();
            t.Add(new Town("Bosany", 24, 40));
            Assert.AreEqual(2, t.Contains(new Town("Bosany", 24, 40)));
        }

        [TestMethod]
        public void Contains_NotPresentExactObjectData_ShouldReturn0()
        {
            var t = GetTownKDTreeFilled();
            Assert.AreEqual(0, t.Contains(new Town("TOWN", 24, 40)));
        }

        [TestMethod]
        public void ContainsAt_PresentObjectDataPosition_ShouldReturnCountOfElements()
        {
            var t = GetTownKDTreeFilled();
            t.Add(new Town("TOWN", 24, 40));
            Assert.AreEqual(2, t.ContainsAt(new TownPosition(24, 40)));
        }

        [TestMethod]
        public void ContainsAt_NotPresentObjectDataPosition_ShouldReturn0()
        {
            var t = GetTownKDTreeFilled();
            Assert.AreEqual(0, t.ContainsAt(new TownPosition(20, 35)));
        }

        [TestMethod]
        public void ContainsRange_PresentObjectDataPosition_ShouldReturnCountOfElements()
        {
            var t = GetTownKDTreeFilled();
            Assert.AreEqual(7, t.ContainsRange(new TownPosition(15, 0), new TownPosition(29, 40)));
        }

        [TestMethod]
        public void ContainsRange_NotPresentObjectDataPosition_ShouldReturn0()
        {
            var t = GetTownKDTreeFilled();
            Assert.AreEqual(7, t.ContainsRange(new TownPosition(15, 0), new TownPosition(29, 40)));
        }

        [TestMethod]
        public void Remove_PresentExactObjectData_ShouldReturnCountOfRemovedElements()
        {
            var t = GetTownKDTreeFilled();
            // ("Nitra", 23, 35), ("Sered", 20, 33), ("Topolcianky", 25, 36), ("Galanta", 16, 31), ("Senica", 14, 39), 
            // ("Tlmace", 28, 34), ("Bosany", 24, 40), ("Bratislava", 13, 32), ("Hodonin", 12, 41), ("Trnava", 17, 42), 
            // ("Moravce", 26, 35), ("Levice", 30, 33), ("Bojnice", 29, 46), ("Novaky", 27, 43)

            var expected = new[] {
                new Town("Sered", 20, 33),

                new Town("Bratislava", 13, 32),
                new Town("Topolcianky", 25, 36),

                new Town("Galanta", 16, 31),
                new Town("Senica", 14, 39),
                new Town("Tlmace", 28, 34),
                new Town("Bosany", 24, 40),

                new Town("Hodonin", 12, 41),
                new Town("Trnava", 17, 42),
                new Town("Moravce", 26, 35),
                new Town("Levice", 30, 33),
                new Town("Bojnice", 29, 46),

                new Town("Novaky", 27, 43)
            };

            t.Add(new Town("Nitra", 23, 35));
            Assert.AreEqual(2, t.Remove(new Town("Nitra", 23, 35)));
            Assert.AreEqual(13, t.Count);
            CollectionAssert.AreEqual(expected, t.ToLevelOrderTraversalList());
        }

        [TestMethod]
        public void Remove_NotPresentExactObjectData_ShouldReturn0()
        {
            var t = GetTownKDTreeFilled();
            Assert.AreEqual(0, t.Remove(new Town("TOWN", 24, 40)));
            Assert.AreEqual(14, t.Count);
        }

        [TestMethod]
        public void RemoveAt_PresentObjectDataPosition_ShouldReturnCountOfRemovedElements()
        {
            var t = GetTownKDTreeFilled();
            // ("Nitra", 23, 35), ("Sered", 20, 33), ("Topolcianky", 25, 36), ("Galanta", 16, 31), ("Senica", 14, 39), 
            // ("Tlmace", 28, 34), ("Bosany", 24, 40), ("Bratislava", 13, 32), ("Hodonin", 12, 41), ("Trnava", 17, 42), 
            // ("Moravce", 26, 35), ("Levice", 30, 33), ("Bojnice", 29, 46), ("Novaky", 27, 43)

            var expected = new[] {
                new Town("Nitra", 23, 35),

                new Town("Sered", 20, 33),
                new Town("Topolcianky", 25, 36),

                new Town("Galanta", 16, 31),
                new Town("Senica", 14, 39),
                new Town("Tlmace", 28, 34),
                new Town("Bojnice", 29, 46),

                new Town("Bratislava", 13, 32),
                new Town("Hodonin", 12, 41),
                new Town("Trnava", 17, 42),
                new Town("Moravce", 26, 35),
                new Town("Levice", 30, 33),
                new Town("Novaky", 27, 43)
            };

            t.Add(new Town("TOWN", 24, 40));
            Assert.AreEqual(2, t.RemoveAt(new TownPosition(24, 40))); // new Town("Bosany", 24, 40)
            CollectionAssert.AreEqual(expected, t.ToLevelOrderTraversalList());
        }

        [TestMethod]
        public void RemoveAt_NotPresentObjectDataPosition_ShouldReturn0()
        {
            var t = GetTownKDTreeFilled();
            Assert.AreEqual(0, t.ContainsAt(new TownPosition(99, 33)));
        }

        [TestMethod]
        public void RemoveRange_PresentObjectDataPosition_ShouldReturnCountOfRemovedElements()
        {
            var t = GetTownKDTreeFilled();
            // ("Nitra", 23, 35), ("Sered", 20, 33), ("Topolcianky", 25, 36), ("Galanta", 16, 31), ("Senica", 14, 39), 
            // ("Tlmace", 28, 34), ("Bosany", 24, 40), ("Bratislava", 13, 32), ("Hodonin", 12, 41), ("Trnava", 17, 42), 
            // ("Moravce", 26, 35), ("Levice", 30, 33), ("Bojnice", 29, 46), ("Novaky", 27, 43)

            var expected = new[] {
                new Town("Trnava", 17, 42),
                new Town("Bratislava", 13, 32),
                new Town("Levice", 30, 33),
                new Town("Senica", 14, 39),
                new Town("Bojnice", 29, 46),
                new Town("Hodonin", 12, 41),
                new Town("Novaky", 27, 43)
            };
            var actual = t.RemoveRange(new TownPosition(15, 0), new TownPosition(29, 40));
            Assert.AreEqual(7, actual);
            CollectionAssert.AreEquivalent(expected, t.ToLevelOrderTraversalList());
            CollectionAssert.AreEqual(expected, t.ToLevelOrderTraversalList());
        }

        [TestMethod]
        public void RemoveRange_NotPresentObjectDataPosition_ShouldReturn0()
        {
            var t = GetTownKDTreeFilled();
            Assert.AreEqual(0, t.RemoveRange(new TownPosition(-12, 30), new TownPosition(11, 40)));
        }

        [TestMethod]
        public void Remove_DataThatHasTheSameDimensionKeyInItsRightSubtree_ShouldMakeLeftSubtreeFromItsRightSubtreeAndRemoveTheNode()
        {
            var t = GetTownKDTree();
            t.Add(new Town("Senica", 22, 39));
            t.Add(new Town("Urad-Tlamac", 24, 36));
            t.Add(new Town("Tlamac", 24, 36));
            t.Add(new Town("Parkovisko-Tlamac", 24, 40));
            t.Add(new Town("Nemocnica-Tlamac", 24, 35));
            t.Add(new Town("Levice", 30, 33));
            t.Add(new Town("Bojnice", 29, 46));
            t.Add(new Town("Novaky", 27, 43));

            Assert.AreEqual(1, t.Remove(new Town("Senica", 22, 39)));
            Assert.AreEqual(7, t.Count);
            var expected = new[] { new Town("Levice", 30, 33), new Town("Urad-Tlamac", 24, 36), new Town("Tlamac", 24, 36),
                new Town("Parkovisko-Tlamac", 24, 40), new Town("Nemocnica-Tlamac", 24, 35), new Town("Bojnice", 29, 46), new Town("Novaky", 27, 43) };
            CollectionAssert.AreEquivalent(expected.ToList(), t.ToLevelOrderTraversalList());
            CollectionAssert.AreEqual(expected.ToList(), t.ToLevelOrderTraversalList());
        }

    }
}