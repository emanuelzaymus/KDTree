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
            var tree = new KDTree<int, string>(2);

            tree.Add("Nitra", 23, 35);

            tree.Add("Sered", 20, 33);
            tree.Add("Topolcianky", 25, 36);

            tree.Add("Galanta", 16, 31);
            tree.Add("Senica", 14, 39);
            tree.Add("Tlmace", 28, 34);
            tree.Add("Bosany", 24, 40);

            tree.Add("Bratislava", 13, 32);
            tree.Add("Hodonin", 12, 41);
            tree.Add("Trnava", 17, 42);
            tree.Add("Moravce", 26, 35);
            tree.Add("Levice", 30, 33);
            tree.Add("Bojnice", 29, 46);

            tree.Add("Novaky", 27, 43);

            tree.PrintTree();

            var f = tree[12, 41];
            Console.WriteLine(f);
            //f = tree[null];
            //Console.WriteLine(f);
            //f = tree[null];
            //Console.WriteLine(f);

            var asd = tree[new int[] { 12, 35 }, new int[] { 26, 48 }];

            var nn = tree[new int[] { 122, 355 }, new int[] { 26, 48 }];

            //var tt = new KDTree<int, string>(new Dictionary<int[], string> {
            //    { new int[] { 45, 85 }, "sdsd" },
            //    { new int[] { 1, 454545 }, "sdsd" },
            //});

            var b = tree.Remove(17, 42);

            //tree.PrintTree();


             

        }
    }
}
