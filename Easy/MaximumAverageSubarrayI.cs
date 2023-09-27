using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class MaximumAverageSubarrayI
    {
        public double FindMaxAverageSlowly(int[] nums, int k)
        {

            int Len = nums.Length;
            if (Len == 1)
            {
                return nums[0];
            }
            double Result = 0;
            for (int i = 0; i < Len - k + 1; i++)
            {
                int temp = 0;
                for (int j = i; j < k + i; j++)
                {
                    temp += nums[j];
                }
                if (i == 0)
                {
                    Result = temp;
                }
                else
                {
                    Result = temp > Result ? temp : Result;
                }
            }
            return Result / k;
        }
    }
}
