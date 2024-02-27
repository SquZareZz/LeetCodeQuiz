using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class NumberOfGoodPairs
    {
        public int NumIdenticalPairs(int[] nums)
        {
            int Res = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                Res += nums.Skip(i + 1).Where(x => x == nums[i]).Count();
            }
            return Res;
        }
    }
}
