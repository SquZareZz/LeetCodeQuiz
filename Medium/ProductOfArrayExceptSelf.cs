using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class ProductOfArrayExceptSelf
    {
        public int[] ProductExceptSelfFail(int[] nums)
        {
            //太慢
            var Result=new int[nums.Length];
            for(int i = 0; i < nums.Length; i++)
            {
                Result[i] = nums.Where((e, j) => j != i).Aggregate(1, (a, b) => a * b);
            }
            return Result;
        }
        public int[] ProductExceptSelf(int[] nums)
        {
            //先從左邊掃過，自己乘上除了最後一號以外的數字
            //ex: 1  2   3   4
            //   ↑↘↑↘↑↘
            //    1  1   2   6
            //    1  a   ab  abc(答案)  
            int Len = nums.Length;
            var LeftSide=new int[Len];
            LeftSide[0] = 1;
            for (int i = 1; i < Len; i++) 
            {
                LeftSide[i] = LeftSide[i - 1] * nums[i - 1];
            }
            //再從右邊用乘法掃過一次一樣的，答案剛好互補乘上去
            //ex: 1   2   3   4
            //    ↑↙↑↙↑↙
            //    1   1   2   6
            //   24  12   8   6 
            //   1  a   ab  abc <=> bcd cd d 1
            //=> bcd acd abd abc 
            var RightSide = new int[Len];
            RightSide[Len-1] = LeftSide[Len - 1];
            int Start = nums[Len - 1];
            for (int i = Len - 2; i > -1; i--)
            {
                RightSide[i]= LeftSide[i] * Start;
                Start *= nums[i];
            }
            return RightSide;
        }
    }
}
