using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class CoinChange
    {
        public int CoinChange1(int[] coins, int amount)
        {
            int[] DP = new int[amount+1];
            for(int i = 1; i < amount + 1; i++)
            {
                bool CanChange = false;
                int Target=0;
                foreach(var coin in coins)
                {
                    if (coins.Contains(i - coin))
                    {
                        CanChange = true;
                        Target = i - coin;
                        break;
                    }
                }
                int Direct = amount + 1;
                if (coins.Contains(i))
                {
                    Direct = 1;
                    CanChange = true;
                }
                if (CanChange)
                {
                    DP[i] = Math.Min(Direct, DP[Target] + 1);
                }
                else
                {
                    bool CanChange2=false; 
                    foreach (var coin in coins)
                    {
                        if(i - coin > -1)
                        {
                            if (DP[i - coin] != -1 && DP[i] != 0)
                            {
                                DP[i] = Math.Min(DP[i - coin] + 1, DP[i]);
                                CanChange2 = true;
                            }
                            else if (DP[i - coin] != -1)
                            {
                                DP[i] = DP[i - coin] + 1;
                                CanChange2 = true;
                            }
                        }
                    }
                    if (!CanChange2)
                    {
                        DP[i] = -1;
                    }
                }
            }
            return DP.Last();
        }
        public int CoinChange2(int[] coins, int amount)
        {
            int[] DP = new int[amount + 1];
            for (int i = 1; i < amount + 1; i++)
            {
                //如果可以直接換
                if (coins.Contains(i))
                {
                    DP[i] = 1;
                    continue;
                }
                bool CanChange = false;
                foreach (var coin in coins)
                {
                    if (i - coin > -1)
                    {
                        if (DP[i - coin] != -1 && DP[i] != 0)
                        {
                            DP[i] = Math.Min(DP[i - coin] + 1, DP[i]);
                            CanChange = true;
                        }
                        else if (DP[i - coin] != -1)
                        {
                            DP[i] = DP[i - coin] + 1;
                            CanChange = true;
                        }
                    }
                }
                if (!CanChange)
                {
                    DP[i] = -1;
                }
            }
            return DP[amount];
        }
    }
}
