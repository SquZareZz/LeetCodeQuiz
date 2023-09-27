using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{

    public class TwoSum
    {
        public class SolutionTwoSumBestWay
        {
            public int[] TwoSum(int[] nums, int target)
            {
                var numSort = new Dictionary<int, int>() { };
                for (int i = 0; i < nums.Length; i++)
                {
                    if (numSort.ContainsKey(target - nums[i]))
                    {
                        return new int[] { numSort[target - nums[i]], i };
                    }
                    if (!numSort.ContainsKey(nums[i]))
                    {
                        numSort.Add(nums[i], i);
                    }
                }
                return null;
            }
        }
        public class SolutionTwoSum2
        {
            public int[] TwoSum(int[] nums, int target)
            {
                var numSort = new Dictionary<int, int>() { };
                for (int i = 0; i < nums.Length; i++)
                {
                    int left = target - nums[i];
                    if (numSort.ContainsKey(left))
                    {
                        return new int[] { numSort[left], i };
                    }
                    if (!numSort.ContainsKey(nums[i]))
                    {
                        numSort.Add(nums[i], i);
                    }
                }
                return null;
            }
        }
        public class SolutionTwoSum3
        {
            public int[] TwoSum(int[] nums, int target)
            {
                int[] Solution = new int[2];
                for (int i = 0; i < nums.Length; i++)
                {
                    int tempPartialSolution = target - nums[i];
                    for (int j = 0; j < nums.Length; j++)
                    {
                        if (j == i)
                        {
                            continue;
                        }
                        else
                        {
                            if (tempPartialSolution == nums[j])
                            {
                                Solution[0] = i; Solution[1] = j;
                                return Solution;
                            }
                        }
                    }
                }
                return null;
            }
        }

    }
}
