using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class MaximumProductOfThreeNumbers
    {
        public int MaximumProduct(int[] nums)
        {
            Array.Sort(nums);
            int TarLen = nums.Length;
            int Count = 0;
            for (int i = 0; i < TarLen; i++)
            {
                if (nums[i] > 0)
                {
                    break;
                }
                else if (i > 1)
                {
                    Count++;
                    break;
                }
                else
                {
                    Count++;
                }
            }
            if (Count > 1)
            {
                int num1 = nums[0] * nums[1] * nums[TarLen - 1];
                int num2 = nums[TarLen - 1] * nums[TarLen - 2] * nums[TarLen - 3];
                return num1 > num2 ? num1 : num2;
            }
            else
            {
                return nums[TarLen - 1] * nums[TarLen - 2] * nums[TarLen - 3];
            }
        }
    }
}
