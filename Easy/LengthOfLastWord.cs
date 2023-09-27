using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class LengthOfLastWord
    {
        public int LengthOfLastWord1(string s)
        {

            var SplitStr = s.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (SplitStr.Length > 0)
            {
                return SplitStr[SplitStr.Length - 1].Length;
            }
            return s.Length;
        }
    }
}
