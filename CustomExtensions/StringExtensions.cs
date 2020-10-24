using System.Text;

namespace CustomExtensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Repeats string n times.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="n">Number of times to repeat this string</param>
        public static string Repeat(this string s, int n)
        {
            return new StringBuilder(s.Length * n).Insert(0, s, n).ToString();
        }
    }
}
