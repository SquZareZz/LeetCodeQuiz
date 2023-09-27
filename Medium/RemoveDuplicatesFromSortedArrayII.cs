using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class RemoveDuplicatesFromSortedArrayII
    {
        public int RemoveDuplicates(int[] nums)
        {
            int temp = nums[0], pointer = 1,count=1;
            for(int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == temp)
                {
                    count++;
                }
                else
                {
                    temp = nums[i];
                    count = 1;
                }
                (nums[i],nums[pointer]) = (nums[pointer], nums[i]);
                if (count < 3)
                {
                    pointer++;
                }
            }
            return pointer;
        }
    }
}
