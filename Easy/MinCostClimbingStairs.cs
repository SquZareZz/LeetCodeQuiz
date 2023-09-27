using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class MinCostClimbingStairs
    {
        public int MinCostClimbingStairs1(int[] cost)
        {
            //直接從第二格開始比：
            //比比看前一格跳過來的花費比較少還是前兩格的
            //也就是說總長度要是cost長度+1(前兩格都是消費0)，跳出去才算結束
            int Len = cost.Length;
            var CostList = new int[Len + 1];
            for (int i = 2; i < Len + 1; ++i)
            {
                CostList[i] = Math.Min(CostList[i - 2] + cost[i - 2], CostList[i - 1] + cost[i - 1]);
            }
            return CostList[Len];
        }
    }
}
