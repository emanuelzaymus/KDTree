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
            var xComparer = Comparer<Town>.Create((t1, t2) => t1.X.CompareTo(t2.X));
            var yComparer = Comparer<Town>.Create((t1, t2) => t1.Y.CompareTo(t2.Y));
            var tree = new KDTree<Town>(xComparer, yComparer);

            tree.Add(new Town("Nitra", 23, 35));

            tree.Add(new Town("Sered", 20, 33));
            tree.Add(new Town("Topolcianky", 25, 36));

            tree.Add(new Town("Galanta", 16, 31));
            tree.Add(new Town("Senica", 14, 39));
            tree.Add(new Town("Tlmace", 28, 34));
            tree.Add(new Town("Bosany", 24, 40));

            tree.Add(new Town("Bratislava", 13, 32));
            tree.Add(new Town("Hodonin", 12, 41));
            tree.Add(new Town("Trnava", 17, 42));
            tree.Add(new Town("Moravce", 26, 35));
            tree.Add(new Town("Levice", 30, 33));
            tree.Add(new Town("Bojnice", 29, 46));

            tree.Add(new Town("Novaky", 27, 43));

            tree.PrintTree();

            // x <12,27>
            // y <40,44> hodonin trnava novaky bosany
            var lists = tree.FindInRange(new TownPosition(12, 40), new TownPosition(27, 44));


            var b = tree.RemoveAt(new TownPosition(24, 40));
            Console.WriteLine(b);

            tree.PrintTree();

            List<string> l = new List<string>();

            //l.
        }
    }
}
