using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class ContainsDuplicate
    {
        public bool ContainsDuplicate1(int[] nums)
        {
            var DicNums = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                if (DicNums.ContainsKey(num))
                {
                    return true;
                }
                else
                {
                    DicNums.Add(num, 1);
                }
            }
            return false;
        }
        public bool ContainsDuplicateSlowest(int[] nums)
        {
            var temp = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (temp.Contains(nums[i]))
                {
                    return true;
                }
                else
                {
                    temp.Add(nums[i]);
                }
            }
            return false;
        }
        public bool ContainsDuplicate2(int[] nums)
        {
            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] == nums[i + 1])
                {
                    return true;
                }
            }
            return false;
        }
        public bool ContainsDuplicateTimeLimitOut(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (Array.IndexOf(nums, nums[i]) != Array.LastIndexOf(nums, nums[i]))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
