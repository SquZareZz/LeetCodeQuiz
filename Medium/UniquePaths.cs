using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class UniquePaths
    {
        public int UniquePathsFormula(int m, int n)
        {
            //先找出短邊(m or n)
            //之後套組合公式，從全長步數m+n-2中取出m-1種組合(m是長邊)
            //C (m+n-2)!/(m-1)!*(n-1)!
            double Molecular = 1, Denominator = 1;
            int TarEdge = m > n ? n : m;
            for(int i = 1; i < TarEdge; i++)
            {
                Molecular *= m + n - 1 - i;//(m+n-2)!
                Denominator *= i;//(n!)
            }
            return Convert.ToInt32(Molecular / Denominator);
        }
        public int UniquePathsDynamicPrograming(int m, int n)
        {
            //先固定一個邊，長或寬都行
            //每走一個的可能，是它自己加上前項，只往前走不繞路
            //所以套兩個For迴圈，兩個迴圈都從原點+1開始，最後就可以掃到右下角，再回傳右下角的數值
            // ex:
            // 0 | 1 | 1
            // 1 | 2 | 3
            // 1 | 3 | 6
            var DP= Enumerable.Repeat(1, n).ToArray();
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    DP[j] += DP[j - 1];
                }
            }
            return DP[n - 1];
        }
    }
}
