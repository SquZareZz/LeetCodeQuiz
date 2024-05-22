using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class FindTheSumOfEncryptedIntegers
    {
        public int SumOfEncryptedInt(int[] nums)
        {
            int Result = 0;
            foreach (int num in nums)
            {
                var StrNum = num.ToString();
                int MaxInDigit = 0;
                if (StrNum.Length > 1)
                {
                    foreach (var CharNum in StrNum)
                    {
                        MaxInDigit = Math.Max(MaxInDigit, CharNum);
                    }
                    StrNum = string.Concat(Enumerable.Repeat((char)MaxInDigit, StrNum.Length));
                    Result += Int32.Parse(StrNum);
                }
                else
                {
                    Result += num;
                }
            }
            return Result;
        }
    }
}
