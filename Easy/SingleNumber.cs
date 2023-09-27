using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class SingleNumber
    {
        public int SingleNumberBest(int[] nums)
        {
            if (nums.Length > 1)
            {
                var Numlist = new Dictionary<int, int>();
                foreach (var num in nums)
                {
                    if (Numlist.ContainsKey(num))
                    {
                        Numlist[num] += 1;
                    }
                    else
                    {
                        Numlist.Add(num, 1);
                    }
                }
                if (Numlist.ContainsValue(1))
                {
                    return Numlist.FirstOrDefault(x => x.Value == 1).Key;
                }
            }
            return nums[0];
        }
    }
}
