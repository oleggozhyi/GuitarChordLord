using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarChords.Core.Helpers
{
    public static class ExtensionHelper
    {
        private static Dictionary<int, string> RomanToArabicMapping = new Dictionary<int, string>
        {
            {1, "I"},
            {2, "II"},
            {3, "III"},
            {4, "IV"},
            {5, "V"},
            {6, "VI"},
            {7, "VII"},
            {8, "VIII"},
            {9, "IX"},
            {10, "X"},
            {11, "XI"},
            {12, "XII"},
            {13, "XIII"},
            {14, "XIV"},
            {15, "XV"},
            {16, "XVI"},
            {17, "XVII"},
            {18, "XVIII"},
            {19, "XIX"},
            {20, "XX"},
            {21, "XXI"},
        };

        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var x in collection)
            {
                action(x);
            }
        }

        public static string ToRomanNumber(this int num)
        {
            return RomanToArabicMapping[num];
        }

        public static int ToArabicNumber(this string roman)
        {
            return RomanToArabicMapping.First(p => p.Value == roman).Key;
        }
    }
}
