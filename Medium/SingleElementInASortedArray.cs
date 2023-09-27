using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class SingleElementInASortedArray
    {
        public int SingleNonDuplicate(int[] nums)
        {
            int CountTemp = 0;
            int Now = nums[0];
            foreach (int num in nums)
            {
                if (num == Now)
                {
                    CountTemp++;
                }
                else
                {
                    if (CountTemp == 1)
                    {
                        return Now;
                    }
                    Now = num;
                    CountTemp = 1;
                }
            }
            return Now;
        }
    }
}
