using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class BestTimeToBuyAndSellStock
    {
        public int MaxProfitFail(int[] prices)
        {
            int MinP = 0; int MaxP = 0;
            int indexMin = 0; int indexMax = 0;
            int ScanRange = prices.Length;
            for (int i = 0; i < ScanRange - 1; i++)
            {
                //2,4,1,1
                if (i == 0 || prices[i] < MinP)
                {
                    MinP = prices[i];
                    indexMin = i;
                }
                else if (i == ScanRange - 1)
                {
                    if (prices[i] >= prices[i + 1])
                    {
                        ScanRange = ScanRange - 1;
                        i = 0;
                    }
                }
            }
            for (int i = ScanRange - 1; i >= indexMin; i--)
            {
                if (prices[i] > MaxP)
                {
                    MaxP = prices[i];
                    indexMax = i;
                }
            }
            if (indexMin >= indexMax)
            {
                return 0;
            }
            else
            {
                return MaxP - MinP;
            }

        }
        public int MaxProfitFail2(int[] prices)
        {
            int MinP = prices[0]; int MaxP = 0;
            int OldPrice = 0; int BestPrice = 0;
            int PriceIndex = 1;
            bool FindingBestValue = true;
            while (FindingBestValue)
            {

                MaxP = prices[PriceIndex];
                if (MaxP > MinP)
                {
                    OldPrice = MaxP - MinP;
                    MinP = prices[PriceIndex + 1];
                    PriceIndex += 2;
                    MaxP = 0;
                }
                else
                {
                    PriceIndex++;
                }
                if (OldPrice > BestPrice)
                {
                    BestPrice = OldPrice;
                }
                FindingBestValue = false;
            }
            return BestPrice;

        }
        public int MaxProfitFail3(int[] prices)
        {
            int pLen = prices.Length;
            int MinP = prices.Min();
            int MaxP = prices.Max();
            int minIndex = Array.IndexOf(prices, prices.Min());
            int maxIndex = Array.IndexOf(prices, prices.Max());
            bool FindingBestValue = true;
            while (FindingBestValue || prices.Length > 0)
            {
                minIndex = Array.IndexOf(prices, prices.Min());
                maxIndex = Array.IndexOf(prices, prices.Max());
                if (minIndex == prices.Length - 1)
                {
                    prices = prices.Where((source, index) => index != minIndex).ToArray();
                    if (prices.Length > 0)
                    {
                        MinP = prices.Min();
                    }
                    else
                    {
                        break;
                    }
                }
                else if (maxIndex == 0 || maxIndex < minIndex)
                {
                    prices = prices.Where((source, index) => index != maxIndex).ToArray();
                    if (prices.Length > 0)
                    {
                        MaxP = prices.Max();
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    FindingBestValue = false;
                    return MaxP - MinP;
                }
            }
            return 0;
        }
        public int MaxProfitFail4(int[] prices)
        {
            //數量過大會炸MEMORY
            int MinP = 0; bool Start = true;
            int MaxP = 0;
            var lastP = prices;
            for (int i = 0; i < prices.Length - 1; i++)
            {
                MinP = prices[i];
                var temp = lastP.Where((a, b) => b != Array.IndexOf(lastP, MinP)).ToArray();
                if (temp.Max() > MinP)
                {
                    if (Start == true || temp.Max() - MinP > MaxP)
                    {
                        MaxP = temp.Max() - MinP;
                        Start = false;
                    }
                }
                lastP = temp;
            }
            return MaxP;

        }
        public int MaxProfitFail5(int[] prices)
        {
            //數量過大會炸MEMORY
            int MinP = 0;
            int MaxP = 0;
            int BestPrice = 0;
            var PricesTemp = prices.ToList();
            for (int i = 0; i < prices.Length - 1; i++)
            {
                var PricesTemp2 = PricesTemp.ToList();
                MinP = PricesTemp.Min();
                MaxP = PricesTemp.Max();
                while (PricesTemp.IndexOf(MinP) > PricesTemp.LastIndexOf(MaxP) && PricesTemp2.Count > 0)
                {
                    PricesTemp2.RemoveAt(PricesTemp2.IndexOf(MinP));
                    MinP = PricesTemp2.Min();
                }
                if (MaxP - MinP > BestPrice)
                {
                    BestPrice = MaxP - MinP;
                }
                PricesTemp.RemoveAt(0);
            }
            return BestPrice;

        }
        public int MaxProfitBestChoice(int[] prices)
        {
            //只需要關心賣出去會不會虧，還有買進價是否為最低價
            int MinP = 0;
            int MaxP = 0;
            int BestPrice = 0;
            if (prices.Length <= 1)
            {
                return 0;
            }
            else
            {
                MinP = prices[0];
                for (int i = 1; i < prices.Length; i++)
                {
                    MaxP = prices[i];
                    if (MaxP > MinP && MaxP - MinP > BestPrice)
                    {
                        BestPrice = MaxP - MinP;
                    }
                    else if (MaxP < MinP)
                    {
                        MinP = MaxP;
                    }
                }
                return BestPrice;
            }
        }
    }
}
