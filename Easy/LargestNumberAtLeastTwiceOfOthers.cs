using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class LargestNumberAtLeastTwiceOfOthers
    {
        public int DominantIndex(int[] nums)
        {
            int MaxNum = nums.Max(), MaxIndex = Array.IndexOf(nums, MaxNum);
            nums = nums.Where(x => x != MaxNum).ToArray();
            foreach (int num in nums)
            {
                if (2 * num > MaxNum)
                {
                    return -1;
                }
            }
            return MaxIndex;
        }
    }
}
