using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class MinimumMovesToEqualArrayElementsII
    {
        public int MinMoves2Fail(int[] nums)
        {
            //不是直接找兩個數中間點
            int Target = (nums.Max() - nums.Min()) / 2;
            int Result = 0;
            foreach (int num in nums)
            {
                Result += Math.Abs(Target - num);
            }
            return Result;
        }
        public int MinMoves2(int[] nums)
        {
            //是找數列中間的數字
            if (nums.Length < 2)
            {
                return 0;
            }
            Array.Sort(nums);
            int Mid = nums[nums.Length / 2];
            int Result = 0;
            foreach (int num in nums)
            {
                Result += Mid > num ? Mid - num : num - Mid;
            }
            return Result;
        }
    }
}
