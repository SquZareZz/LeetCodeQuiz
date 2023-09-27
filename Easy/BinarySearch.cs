using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class BinarySearch
    {
        public int SearchJustUseFuntion(int[] nums, int target)
        {
            return Array.IndexOf(nums, target);
        }
        public int Search(int[] nums, int target)
        {
            int Count = 0;
            foreach (int num in nums)
            {
                if (num == target)
                {
                    return Count;
                }
                Count++;
            }
            return -1;
        }
        public int ByBinarySearch(int[] nums, int target)
        {
            int head = 0, Len = nums.Length - 1;
            while (head <= Len)
            {
                int mid = (head + Len) / 2; 	// 中點索引值
                if (nums[mid] == target)
                {
                    return mid;
                }
                if (nums[mid] < target)// 元素大於中間值，往右半
                {
                    head = mid + 1;             // 調整頭的索引值
                }
                else
                {                        // 元素小於中間值 ， 往左半
                    Len = mid - 1;		    // 調整尾部索引值
                }
            }
            return -1;
        }
    }
}
