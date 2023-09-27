using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class NumberOfLinesToWriteString
    {
        public int[] NumberOfLines(int[] widths, string s)
        {
            var result = new int[] { 1, 0 };
            foreach (var c in s)
            {
                result[1] += widths[c - 97];
                if (result[1] > 100)
                {
                    result[1] = widths[c - 97];
                    result[0]++;
                }
            }
            result[1] = result[1];
            return result;
        }
    }
}
