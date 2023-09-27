using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class MaximumXORofTwoNumbersInAnArray
    {
        public int FindMaximumXOR(int[] nums)
        {
            //太慢
            var Result = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int x = nums[i];
                for (int j = i; j < nums.Length; j++)
                {
                    Result = Math.Max(x ^ nums[j], Result);
                }
            }
            return Result;
        }
    }
}
