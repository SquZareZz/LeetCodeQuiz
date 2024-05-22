using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class LongestStrictlyIncreasingOrStrictlyDecreasingSubarray
    {
        public int LongestMonotonicSubarray(int[] nums)
        {
            int res = 1;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                bool AddOrReduce;
                if (nums[i] == nums[i + 1])
                {
                    continue;
                }
                else if (nums[i] > nums[i + 1])
                {
                    AddOrReduce = false;
                }
                else
                {
                    AddOrReduce = true;
                }
                var ResTemp = 1;
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (AddOrReduce)
                    {
                        if (nums[j-1] < nums[j])
                        {
                            ResTemp++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        if (nums[j-1] > nums[j])
                        {
                            ResTemp++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                res = Math.Max(res, ResTemp);
            }
            return res;
        }
    }
}
