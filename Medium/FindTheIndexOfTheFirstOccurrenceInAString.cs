using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class FindTheIndexOfTheFirstOccurrenceInAString
    {
        public int StrStrFunWay(string haystack, string needle)
        {
            return haystack.IndexOf(needle);
        }
        public int StrStr(string haystack, string needle)
        {
            int Len = needle.Length;
            for (int i = 0; i <= haystack.Length - Len; i++)
            {
                if (haystack.Substring(i, Len) == needle)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
