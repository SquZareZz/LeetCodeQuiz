using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class BestTimeToBuyAndSellStockWithTransactionFee
    {
        public int MaxProfit(int[] prices, int fee)
        {
            //金額可以是一段，最大減最小，也可以是多段加起來
            //第 i 天的價格變化只會跟 i-1 天的收益有關係，只要前一天有把最大收益算出，每天只需要在意買或賣
            //要規劃以下幾個數字：
            //1. 賣出最高價 = Math.Max(舊最高價格, 舊保留價格 + 新賣價 - 手續費)
            //2. 保留最高價 = Math.Max(舊保留價格, 舊最高賣出價格 - 當前價格)
            //舊最高賣出價格 - 當前價格 => 檢查是否該買進 => 如果股票跌了 = 可買 / 相反就是不適合買
            //如果剛賣股票的下一天，價格必等於或低於前一天，故不用擔心未買即賣的問題
            var Hold = new int[prices.Length];
            var Sold = new int[prices.Length];
            //買進
            Hold[0] = -prices[0];
            for (int i = 1; i < prices.Length; i++)
            {
                //賣出收益
                Sold[i] = Math.Max(Sold[i - 1], Hold[i - 1] + prices[i] - fee);
                //保留損益
                Hold[i] = Math.Max(Hold[i - 1], Sold[i - 1] - prices[i]);
            }
            return Sold.Last();
        }
        public int MaxProfit2(int[] prices, int fee)
        {
            //第 i 天的價格變化只會跟 i-1 天的收益有關係
            //可以只把前一天有把最大收益算出，而不用關注歷史走向
            
            //買進
            var Hold = -prices[0];
            var Sold = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                var Sold_His = Sold;
                //賣出收益
                //因為 Hold 會在 Sold 計算完後才計算，因此不用擔心被刷新
                Sold = Math.Max(Sold_His, Hold + prices[i] - fee);
                //保留損益
                Hold = Math.Max(Hold, Sold_His - prices[i]);
            }
            return Sold;
        }
    }
}
