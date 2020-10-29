using DataStructures.KDTree;
using DataStructures.Tests.DataGeneration;
using DataStructures.Tests.TestClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.Tests
{
    [TestClass]
    public class KDTreeFuzzyTests
    {
        [TestMethod]
        [Timeout(10000)]
        public void KDTree_Town_FuzzyAdd()
        {
            int count = 1000000;
            var tree = new KDTree<Town>(Town.GetComparers());
            var checkList = new List<Town>(count);

            for (int i = 0; i < count; i++)
            {
                Town t = RandomDataGenerator.GenerateTown();
                tree.Add(t);
                checkList.Add(t);
            }
            CollectionAssert.AreEquivalent(checkList, tree.ToList());
        }

        [TestMethod]
        [Timeout(20000)]
        public void KDTree_Town_FuzzyAddRange()
        {
            var tree = new KDTree<Town>(Town.GetComparers());
            var towns = RandomDataGenerator.GenerateTowns(1000000).ToArray();
            tree.AddRange(towns);
            CollectionAssert.AreEquivalent(towns.ToList(), tree.ToList());
        }

        [TestMethod]
        [Timeout(20000)]
        public void KDTree_Town_FuzzyFind()
        {
            var r = new Random(1);
            int count = 1000000;
            var tree = new KDTree<Town>(Town.GetComparers());
            var towns = RandomDataGenerator.GenerateTowns(count).ToArray();
            tree.AddRange(towns);
            for (int i = 0; i < 100000; i++)
            {
                var expected = towns[r.Next(count)];
                Assert.AreSame(expected, tree.Find(expected).First());
            }
        }

        [TestMethod]
        [Timeout(20000)]
        public void KDTree_Town_FuzzyFindRemove()
        {
            Random r = new Random(9876);
            int count = 20000;
            Town[] towns = RandomDataGenerator.GenerateTowns(count).ToArray();
            var tree = new KDTree<Town>(towns, Town.GetComparers());
            var checkList = towns.ToList();

            int i;
            for (i = 0; i < 1000 && checkList.Count > 0; i++)
            {
                var town = checkList[r.Next(checkList.Count)];
                int townCount = checkList.Count(x => x.Equals(town));
                var foundTowns = tree.Find(town);
                Assert.AreEqual(town, foundTowns.First());
                Assert.AreEqual(townCount, foundTowns.Count);
                var countRemoved = tree.Remove(town);
                Assert.AreEqual(townCount, countRemoved);
                checkList.RemoveAll(x => x.Equals(town));
                CollectionAssert.AreEquivalent(checkList, tree.ToList());

                var pos = r.NextDouble() < 0.1 ? RandomDataGenerator.GenerateTownPosition() : towns[r.Next(count)];
                var found = tree.FindAt(pos);
                tree.RemoveAt(pos);
                checkList.RemoveAll(x => found.Contains(x));
                CollectionAssert.AreEquivalent(checkList, tree.ToList());

                var pos1 = RandomDataGenerator.GenerateTownPosition();
                var pos2 = RandomDataGenerator.GenerateTownPosition();
                found = tree.FindRange(pos1, pos2);
                tree.RemoveRange(pos1, pos2);
                checkList.RemoveAll(x => found.Contains(x));
                CollectionAssert.AreEquivalent(checkList, tree.ToList());
            }
        }

        [TestMethod]
        [Timeout(30000)]
        public void KDTree_Town_Fuzzing()
        {
            Random r = new Random(23);
            var tree = new KDTree<Town>(Town.GetComparers());
            int initCount = 10000;
            var towns = RandomDataGenerator.GenerateTowns(initCount).ToArray();
            tree.AddRange(towns);
            var checkList = new List<Town>(Convert.ToInt32(initCount * 1.5));
            checkList.AddRange(towns);

            int i;
            for (i = 0; i < 40000; i++)
            {
                switch (r.Next(3))
                {
                    case 0:
                        if (r.Next(2) == 0)
                        {
                            Town t = RandomDataGenerator.GenerateTown();
                            tree.Add(t);
                            checkList.Add(t);
                        }
                        else
                        {
                            var generTowns = RandomDataGenerator.GenerateTowns(r.Next(5, 15)).ToArray();
                            tree.AddRange(generTowns);
                            checkList.AddRange(generTowns);
                        }
                        CollectionAssert.AreEquivalent(checkList, tree.ToList());
                        break;
                    case 1:
                        var town = checkList[r.Next(checkList.Count)];
                        int townCount = checkList.Count(x => x.Equals(town));
                        var foundTowns = tree.Find(town);
                        Assert.AreEqual(town, foundTowns.First());
                        Assert.AreEqual(townCount, foundTowns.Count);
                        break;
                    case 2:
                        ICollection<Town> found;
                        if (r.Next(2) == 0)
                        {
                            var pos = r.NextDouble() < 0.1 ? RandomDataGenerator.GenerateTownPosition() : checkList[r.Next(checkList.Count)];
                            found = tree.FindAt(pos);
                            tree.RemoveAt(pos);
                        }
                        else
                        {
                            TownPosition pos1 = RandomDataGenerator.GenerateTownPosition();
                            TownPosition pos2 = RandomDataGenerator.GenerateTownPosition();
                            found = tree.FindRange(pos1, pos2);
                            tree.RemoveRange(pos1, pos2);
                        }
                        checkList.RemoveAll(x => found.Contains(x));
                        CollectionAssert.AreEquivalent(checkList, tree.ToList());
                        break;
                    default:
                        break;
                }
            }
        }

    }
}