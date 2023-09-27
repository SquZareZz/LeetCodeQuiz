using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class ContainsDuplicateII
    {
        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            var DicNums = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (DicNums.ContainsKey(nums[i]))
                {
                    if (i - DicNums[nums[i]] <= k)
                    {
                        return true;
                    }
                    else
                    {
                        DicNums[nums[i]] = i;
                    }
                }
                else
                {
                    DicNums.Add(nums[i], i);
                }
            }
            return false;
        }
    }
}
