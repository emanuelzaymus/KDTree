using System.Collections.Generic;

namespace GeodeticPDA.Model
{
    public class Element
    {
        public string Key1 { get; set; }
        public string Key2 { get; set; }
        public int Value { get; set; }

        public Element(string key1, string key2, int value)
        {
            Key1 = key1;
            Key2 = key2;
            Value = value;
        }

        public static Comparer<Element>[] GetComparers()
        {
            var key1Comparer = Comparer<Element>.Create((x, y) => x.Key1.CompareTo(y.Key1));
            var key2Comparer = Comparer<Element>.Create((x, y) => x.Key2.CompareTo(y.Key2));
            return new[] { key1Comparer, key2Comparer };
        }

        public override string ToString()
        {
            return $"Key1:{Key1}, Key2:{Key2}, Value:{Value}";
        }

        public override bool Equals(object obj)
        {
            return obj is Element element &&
                   Key1 == element.Key1 &&
                   Key2 == element.Key2 &&
                   Value == element.Value;
        }

    }
}
