using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class MinimumOperationsToExceedThresholdValueI
    {
        public int MinOperations(int[] nums, int k)
        {
            if (nums.Max() < k) return 0;
            var NumsTemp = nums.ToList();
            int result = 0;
            while (NumsTemp.Min() < k)
            {
                result++;
                NumsTemp.Remove(NumsTemp.Min());
            }
            return result;
        }
        public int MinOperations2(int[] nums, int k)
        {
            if (nums.Max() < k) return 0;
            Array.Sort(nums);
            int result;
            for (result = 0; result < nums.Length; result++)
            {
                if (nums[result] >= k) break;
            }
            return result - 1;
        }
    }
}
