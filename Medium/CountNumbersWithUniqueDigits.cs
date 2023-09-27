using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class CountNumbersWithUniqueDigits
    {
        public int CountNumbersWithUniqueDigitsFail(int n)
        {
            //暴力解=超時
            int target = (int)(Math.Pow(10, n)), Result = 0;
            for(int i=0; i< target; i++)
            {
                var temp = new HashSet<char>(i.ToString());
                if (temp.Count == i.ToString().Length)
                {
                    Result++;
                }
            }
            return Result;
        }
        public int CountNumbersWithUniqueDigits1(int n)
        {
            int target = 1, Result = 1;
            for(int i=1; i < n + 1; i++)
            {
                switch (i)
                {
                    case 1:
                        target *= 9;
                        break;
                    default:
                        target *= (11-i);
                        break;
                }
                Result += target;
            }
            return Result;
        }
    }
}
