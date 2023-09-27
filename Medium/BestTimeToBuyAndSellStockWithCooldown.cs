using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class BestTimeToBuyAndSellStockWithCooldown
    {
        public int MaxProfit(int[] prices)
        {
            if (prices.Length == 1)
            {
                return 0;//沒得賣
            }
            //除了買價以外初值都為0
            //買價初值為第一天價錢
            var sell = new List<int>() { 0 };
            var buy = new List<int>() { -1 * prices[0] };
            var cooldown = new List<int>() { 0 };
            for (int i = 1; i < prices.Length; ++i)
            {
                //每一天的最高賣價為前一天的最高賣價與(前一天的買價造成的收益+當日的價格)取最大值
                sell.Add(Math.Max(sell[i - 1], buy[i-1] + prices[i]));
                //每一天的最理想買價為前一天的最低買價與(前一天的消失收益 - 當日的價格=>本日買價)
                //因為都是負，所以最大值會是花最少錢
                //消失收益 - 本日的價格要最大的 =>
                //(如果前日賣出會少掉本日收益，所以cooldown-price)才是理想值
                buy.Add(Math.Max(buy[i - 1], cooldown[i - 1] - prices[i]));
                //每一天的消失收益為前一天的最高消失收益與前一天的賣價取最大值
                //意思是如果本日消失的收益比較大，要改選前一天當休息的點
                cooldown.Add(Math.Max(cooldown[i - 1], sell[i - 1]));
            }
            return sell.Last();
        }
    }
}
