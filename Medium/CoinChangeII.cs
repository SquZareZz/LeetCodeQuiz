using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class CoinChangeII
    {
        public int Change(int amount, int[] coins)
        {
            var DP = new int[amount + 1];
            DP[0] = 1;
            //先從每種硬幣開始掃
            foreach(int coin in coins) 
            {
                //如果幣值大過總價 => i > amount
                for(int i = coin; i <= amount; i++)
                {
                    //現在的組合 => 算這個硬幣前的組合
                    //ex: {5,10} 11
                    //到 DP[6] 的時候，因為 DP[1] 不存在，所以 DP[6] 不會有值
                    //同理所有拼不出的組合，它的 DP[n] 或 DP[n-coin] 也不會有值
                    //所以不會有不存在的組合
                    DP[i] += DP[i - coin];
                }
            }
            //回傳算到最後的可能
            return DP[amount];
        }
    }
}
