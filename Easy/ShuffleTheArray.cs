using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class ShuffleTheArray
    {
        public int[] Shuffle(int[] nums, int n)
        {
            int[] result = new int[2 * n];
            for (int i = 0; i <= 2 * n - 1; i++)
            {
                result[i] = i % 2 == 0 ? nums[i / 2] : nums[n + i / 2];
            }
            return result;
        }
        public int[] Shuffle2(int[] nums, int n)
        {
            var first = nums.Where(x => x % 2 == 0);
            return nums;
        }
    }
}
