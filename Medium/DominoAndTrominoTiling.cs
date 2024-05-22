using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class DominoAndTrominoTiling
    {
        public int NumTilings(int n)
        {
            //前三種數量是常數，從第四項開始可以套用公式解
            //f(n) = 2 * f(n-1) + f(n-3)
            //
            //避免溢位，上限是 10^9+7，約為 2^31，因此在取餘前會溢位
            //用 64 位元裝數字
            var DP = new long[n + 1];
            if (n == 1)
            {
                return 1;
            }
            else if (n == 2)
            {
                return 2;
            }
            else if(n == 3)
            {
                return 5;
            }
            else
            {                
                long MaxValue = (long)Math.Pow(10, 9) + 7;
                DP[1] = 1;
                DP[2] = 2;
                DP[3] = DP[1] + DP[2] + 2;
                for (int i = 4; i <= n; i++)
                {
                    DP[i] = (2 * DP[i - 1] + DP[i - 3]) % MaxValue;
                }
            }            
            return (int)DP[n];
        }
    }
}
