using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class MaxPairSumInAnArray
    {
        public int MaxSum(int[] nums)
        {
            int Result = -1;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                var temp = nums[i] + nums[i + 1];
                if (temp < Result || temp < 10) continue;
                var tempJudge = temp.ToString();
                var JudgeRes = tempJudge.Where(x => x != tempJudge[0]);
                Result = JudgeRes.Count() > 0 ? Result : temp;
            }
            return Result;
        }
    }
}
