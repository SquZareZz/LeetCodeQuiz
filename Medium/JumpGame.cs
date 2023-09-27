using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class JumpGame
    {
        public bool CanJump(int[] nums)
        {
            int Before = 0, Now = 0, Possible;
            if (nums.Length < 2) return true;
            while (Now < nums.Length)
            {
                Possible = Now;
                for (; Before <= Possible; Before++)
                {
                    int temp = Before + nums[Before];
                    if (temp > nums.Length - 2)
                    {
                        return true;
                    }
                    Now = Math.Max(Now, temp);

                }
                if (Now == Possible)
                {
                    return false;
                }
            }
            return Now >= nums.Length - 1;
        }
    }
}
