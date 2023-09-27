using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class ReverseString
    {
        public void ReverseString1(char[] s)
        {
            Array.Reverse(s);
        }
        public void ReverseString2(char[] s)
        {
            int j = 0;
            var temp = s.ToArray();
            for (int i = s.Length - 1; i > -1; i--)
            {
                s[j] = temp[i];
                j++;
            }
        }
    }
}
