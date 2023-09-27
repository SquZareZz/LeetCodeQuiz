using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class HouseRobber
    {
        public int Rob(int[] nums)
        {
            int Len = nums.Length;
            int[] DP_Result = new int[Len];
            for (int i = Len - 1; i > -1; i--)
            {
                int ToAdd = 0;
                if (i + 3 < Len)
                {
                    ToAdd = Math.Max(DP_Result[i + 2], DP_Result[i + 3]);
                }
                else if (i + 2 < Len)
                {
                    ToAdd = DP_Result[i + 2];
                }
                DP_Result[i] = nums[i] + ToAdd;
            }
            return DP_Result.Max();
        }
    }
}
