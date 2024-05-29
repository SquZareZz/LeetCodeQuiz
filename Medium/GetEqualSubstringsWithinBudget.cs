using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class GetEqualSubstringsWithinBudget
    {
        public int EqualSubstringFail(string s, string t, int maxCost)
        {
            //因為子字串不一定從起點開始
            int result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int quota = Math.Abs(t[i] - s[i]);
                if (quota <= maxCost)
                {
                    result++;
                    maxCost -= quota;
                }
                else
                {
                    break;
                }
            }
            return result;
        }
        public int EqualSubstring(string s, string t, int maxCost)
        {
            //保留所有可能
            //可以做，但二重迴圈太慢了
            int Res = 0, Len = s.Length;
            for (int i = 0; i < Len; i++)
            {
                int ResTemp = 0;
                int maxCostTemp = maxCost;
                for (int j = i; j < Len; j++)
                {
                    int quota = Math.Abs(t[j] - s[j]);

                    if (quota <= maxCostTemp)
                    {
                        ResTemp++;
                        maxCostTemp -= quota;
                    }
                    else
                    {
                        break;
                    }
                }
                Res = Math.Max(Res, ResTemp);
            }
            return Res;
        }
        public int EqualSubstringFail2(string s, string t, int maxCost)
        {
            //因為滑窗不一定是扣最大的滑
            int MaxLen = 0;
            int[] gap = new int[s.Length];
            int Len = s.Length;
            int Head = 0;
            int Bot = s.Length - 1;
            for (int i = 0; i < s.Length; i++)
            {
                var temp = Math.Abs(t[i] - s[i]);
                MaxLen += temp;
                gap[i] = temp;
            }
            while (MaxLen > maxCost)
            {
                if (gap[Head] > gap[Bot])
                {
                    MaxLen -= gap[Head];
                    Head++;
                    Len--;
                }
                else
                {
                    MaxLen -= gap[Bot];
                    Bot--;
                    Len--;
                }
            }
            //'j'-'r'
            return Len;
        }
        public int EqualSubstring2(string s, string t, int maxCost)
        {
            //滑窗應該設計成：
            //左邊界 <= 右邊界
            //且窗口內總和小於最大限制
            //每次窗口過小 => 擴大右邊界
            //窗口過大 => 移動左邊界
            int Result = 0, ResTemp = 0, start = 0;
            for (int i = 0; i < s.Length; i++)
            {
                ResTemp += Math.Abs(s[i] - t[i]);
                while (start <= i && ResTemp > maxCost)
                {
                    ResTemp -= Math.Abs(s[start] - t[start]);
                    start++;
                }
                //長度要 +1，因為從 0 開始
                Result = Math.Max(Result, i - start + 1);
            }
            return Result;
        }

        public int EqualSubstring3(string s, string t, int maxCost)
        {
            //保留所有可能
            //可以做，但二重迴圈太慢了
            int Res = 0, Len = s.Length;
            for (int i = 0; i < Len; i++)
            {
                int ResTemp = 0, j = i;
                int maxCostTemp = maxCost;
                while (j < Len && maxCostTemp >= 0)
                {
                    if (Math.Abs(t[j] - s[j]) > maxCostTemp) break;
                    ResTemp++;
                    maxCostTemp -= Math.Abs(t[j] - s[j]);
                    j++;
                }
                Res = Math.Max(Res, ResTemp);
            }
            return Res;
        }
    }
}

