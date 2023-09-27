using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class LongestUncommonSubsequenceI
    {
        public int FindLUSlength(string a, string b)
        {
            int LenA = a.Length, LenB = b.Length;
            if (LenA > LenB)
            {
                return LenA;
            }
            else if (a == b)
            {
                return -1;
            }
            else
            {
                return LenB;
            }

        }
        public int FindLUSlengthOneRow(string a, string b)
        {
            return a == b ? -1 : a.Length > b.Length ? a.Length : b.Length;
        }
    }
}
