using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class _3SumClosest
    {
        public int ThreeSumClosest(int[] nums, int target)
        {
            Array.Sort(nums);
            int Result = nums[0] + nums[1] + nums[2], Len = nums.Length;
            for (int i = 0; i < Len - 2; i++)
            {
                int j = i + 1, k = Len - 1;
                while (j != k)
                {
                    int temp = nums[i] + nums[j] + nums[k];
                    if (temp == target)
                    {
                        return target;
                    }
                    else if (Math.Abs(temp - target) < Math.Abs(Result - target))
                    {
                        Result = temp;
                    }
                    else
                    {
                        if (temp < target)
                        {
                            j++;
                        }
                        else
                        {
                            k--;
                        }
                    }
                }
            }
            return Result;
        }
    }
}
