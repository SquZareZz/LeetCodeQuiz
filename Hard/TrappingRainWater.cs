using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Hard
{
    public class TrappingRainWater
    {
        public int TrapFail(int[] height)
        {
            //Fail:4,2,3
            var area = 0;
            var startIndex = 0;
            var judge = false;
            for (int i = 0; i < height.Length; i++)
            {
                //如果是平的，不往下做
                if (height[i] == 0)
                {
                    continue;
                }
                //如果還沒進判定，而且高度不為 0，開始準備判定
                if (!judge)
                {
                    startIndex = i;
                    judge = true;
                    continue;
                }
                else
                {
                    //如果右邊比左邊矮，繼續
                    if (height[i] < height[startIndex])
                    {
                        //如果往右看沒有比自己高或等高的，改掉起始點
                        startIndex = height.Skip(i).Max() < height[startIndex] ? i : startIndex;
                    }
                    //如果右邊比左邊高或等高，開始統計面積
                    else
                    {
                        for (int j = 1; j <= Math.Min(height[startIndex], height[i]); j++)
                        {
                            for (int k = startIndex + 1; k < i; k++)
                            {
                                if (height[k] < j)
                                {
                                    area++;
                                }
                            }
                        }
                        startIndex = i;
                    }
                }
            }
            return area;
        }
        public int TrapFail2(int[] height)
        {
            //Fail:4,2,3
            var area = 0;
            var startIndex = 0;
            var judge = false;
            var Candidate = new List<int>();
            for (int i = 0; i < height.Length; i++)
            {
                var tempHeight = height.Skip(i + 1);
                if (!judge)
                {
                    if (i == height.Length - 1) continue;
                    //
                    if (height[i] <= tempHeight.Max() && height[i] > tempHeight.Min())
                    {
                        startIndex = i;
                        judge = true;
                        Candidate = new List<int>();
                    }
                    else
                    {
                        startIndex = i;
                    }
                }
                else
                {

                    if (i - startIndex > 1 && height[i] > Candidate.Max() &&
                        (tempHeight.Count() == 0 || height[i] >= tempHeight.Max()))
                    {
                        for (int j = 1; j <= Math.Min(height[startIndex], height[i]); j++)
                        {
                            for (int k = startIndex + 1; k < i; k++)
                            {
                                if (height[k] < j)
                                {
                                    area++;
                                }
                            }
                        }
                        startIndex = i;
                        judge = false;
                        i--;
                    }
                    else
                    {
                        Candidate.Add(height[i]);
                    }
                }

            }
            return area;
        }

        public int Trap(int[] height)
        {
            int res = 0, TempMax = 0, n = height.Length;
            int[] dp = new int[n];
            // 先掃出每個點對到左邊最大值
            // 起始在最左邊，左邊不會有值，所以 TempMax == 0
            for (int i = 0; i < n; i++)
            {
                dp[i] = TempMax;
                TempMax = Math.Max(TempMax, height[i]);
            }
            // 接著掃出每個點對到右邊的最大值
            // 起始在最右邊，右邊不會有值，所以 TempMax == 0
            TempMax = 0;            
            // 這個點的位置必為左邊和右邊的中間，所以如果此點比左右都小，就可以積水
            // 故得證，最左和最右都必為 0
            for (int i = n - 1; i >= 0; i--)
            {
                //左跟右取最小跟該點比較即可
                dp[i] = Math.Min(dp[i], TempMax);
                TempMax = Math.Max(TempMax, height[i]);
                if (dp[i] > height[i])
                {
                    res += dp[i] - height[i];
                }
            }
            return res;
        }
    }
}