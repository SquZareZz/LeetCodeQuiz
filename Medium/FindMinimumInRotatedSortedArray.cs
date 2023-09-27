using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class FindMinimumInRotatedSortedArray
    {
        public int FindMin(int[] nums)
        {
            int temp = nums[0];
            foreach (int i in nums.Skip(1)) 
            {
                if(i< temp) 
                {
                    return i;
                }
                else
                {
                    temp = i;
                }
            }
            return nums[0];
        }
        public int FindMinFunWay(int[] nums) 
        {
            //無視問題
            return nums.Min();
        }
    }
}
