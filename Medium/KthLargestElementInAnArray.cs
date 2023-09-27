using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class KthLargestElementInAnArray
    {
        public int FindKthLargest(int[] nums, int k)
        {
            var temp = nums.ToList();
            temp.Sort((x, y) => -x.CompareTo(y));//改降序
            return temp[k - 1];
        }
        public int FindKthLargest2(int[] nums, int k)
        {
            nums = nums.OrderByDescending(x => x).ToArray();
            return nums[k - 1];
        }
        public int FindKthLargest3(int[] nums, int k)
        {
            //太慢
            int MaxIndex = 0;
            while (k > 1)
            {
                MaxIndex = Array.IndexOf(nums,nums.Max());
                nums = nums.Where((x,y)=>y!=MaxIndex).ToArray();
                k--;
            }
            return nums.Max();
        }
    }
}
