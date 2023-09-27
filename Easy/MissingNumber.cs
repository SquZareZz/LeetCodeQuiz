using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class MissingNumber
    {
        public int MissingNumber1(int[] nums)
        {
            int TarLen = nums.Length;
            if (nums[0] == 1 && TarLen == 1)
            {
                return nums[0] - 1;
            }
            else if (nums[0] == 0 && TarLen == 1)
            {
                return nums[0] + 1;
            }
            else
            {
                Array.Sort(nums);
                for (int i = 0; i < TarLen - 1; i++)
                {
                    if (nums[i] + 1 != nums[i + 1])
                    {
                        return nums[i + 1] - 1;
                    }
                }
                if (nums[TarLen - 1] == TarLen)
                {
                    return nums[0] - 1;
                }
                else
                {
                    return nums[TarLen - 1] + 1;
                }

            }

        }
    }
}
