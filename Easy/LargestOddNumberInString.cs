using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class LargestOddNumberInString
    {
        public string LargestOddNumber(string num)
        {
            for (int i = num.Length - 1; i > -1; i--)
            {
                if ((num[i] - '0') % 2 == 1)
                {
                    return num.Substring(0, i + 1);
                }
            }
            return "";
        }
    }
}
