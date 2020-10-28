using DataStructure.Tests.RandomDataGenerator.TestClasses;
using DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DSConsoleApp
{
    class Program
    {
        static void Main()
        {
            var t = new KDTree<Town>(Town.GetComparers());

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

            t.PrintTree();

            var actual = t.RemoveRange(new TownPosition(15, 0), new TownPosition(29, 40));
            Console.WriteLine(actual);

            t.PrintTree();
        }
    }
}
