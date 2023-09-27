using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class MinimumMovesToEqualArrayElements
    {
        public int MinMovesFail(int[] nums)
        {
            //失敗：暴力解太慢
            int Result = 0, Len = nums.Length;
            int Max = nums.Max();
            while (nums.Sum() < Len * Max)
            {
                bool Pass = true;
                for (int i = 0; i < Len; i++)
                {
                    if (nums[i] == Max && Pass)
                    {
                        Pass = false;
                        continue;
                    }
                    else
                    {
                        nums[i]++;
                    }
                }
                Result++;
                Max = nums.Max();
            }
            return Result;
        }
        public int MinMoves(int[] nums)
        {
            //最小的數字必定走最長的步數
            //最長的步數來自總長度-最小數字*總長度
            return nums.Sum() - nums.Min() * nums.Length;
        }
    }
}
