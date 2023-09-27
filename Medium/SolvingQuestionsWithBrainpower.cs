using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class SolvingQuestionsWithBrainpower
    {
        //當N題被跳過以後，選出分數最高的那題
        public long MostPoints(int[][] questions)
        {
            int Len = questions.Length;
            long[] Result = new long[Len];
            int Point = 0;
            int ReI = 0;
            for(int i = 0; i < Len; i++) 
            {
                Point += questions[i][0];
                if(i + questions[i][1] > Len - 2)
                {
                    Result[ReI] = Point;
                    Point = 0;
                    i = ReI;
                    ReI++;
                }
                else
                {
                    i += questions[i][1];
                }
            }
            return Result.Max();
        }
        public long MostPoints2(int[][] questions)
        {
            //驗證下一號是否已經到底：i + questions[i][1] + 1 (因為是找下一號)
            //跟 n 比較最小的步伐，最後找出對應的 DP (動態規劃)項
            //用當前的 DP 結果跟下一號的 DP 結果比較(迴圈上一個計算的數值)，取較大的
            //這樣相當於把全部都遍歷過了，因為倒數的前幾號只會有 1、2 種可能

            int Len = questions.Length;
            long[] DP = new long[questions.Length + 1];
            for (int i = questions.Length - 1; i >= 0; i--)
            {
                DP[i] = Math.Max(questions[i][0] + DP[Math.Min(i + questions[i][1] + 1, Len)], DP[i + 1]);
            }
            return DP[0];
        }
    }
}
