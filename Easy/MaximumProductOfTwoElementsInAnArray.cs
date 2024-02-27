using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class MaximumProductOfTwoElementsInAnArray
    {
        public int MaxProduct(int[] nums)
        {
            Array.Sort(nums);
            return (nums[nums.Length - 1] - 1) * (nums[nums.Length - 2] - 1);
        }
    }
}
