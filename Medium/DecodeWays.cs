using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class DecodeWays
    {
        public int NumDecodings(string s)
        {
            //英文沒有對應 0 號的字母，所以見 0 直接結束
            if (string.IsNullOrEmpty(s) || s[0] == '0') return 0;
            //用動態規劃解，新增一個數字會跟未新增前的結果有關
            int[] dp = new int[s.Length + 1];
            dp[0] = 1;

            for (int i = 1; i < dp.Length; i++)
            {
                //如果見到 0 的話，只有 10 或 20 的可能，所以先把這一號定義為 0
                //符合時代表本數非 10 或 20 代表不存在任何可能 => return 0
                dp[i] = s[i - 1] == '0' ? 0 : dp[i - 1];
                //如果不是第一項
                //且前兩項介於 10~26 之間 => 完成費波那契數列條件：
                //s[i] = s[i-1] + s[i-2]
                if (i > 1 && (s[i - 2] == '1' || (s[i - 2] == '2' && s[i - 1] <= '6')))
                {
                    dp[i] += dp[i - 2];
                }
            }

            return dp.Last();
        }
    }
}
