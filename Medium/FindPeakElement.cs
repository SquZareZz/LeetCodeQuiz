using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class FindPeakElement
    {
        public int FindPeakElement1(int[] nums)
        {
            int Start = nums[0];
            for(int i= 1; i < nums.Length; i++)
            {
                if (nums[i] < Start) 
                {
                    return i - 1;
                }
                else
                {
                    Start = nums[i];
                }
            }
            return nums.Length == 1 ? 0 : nums.Length-1;
        }
    }
}
