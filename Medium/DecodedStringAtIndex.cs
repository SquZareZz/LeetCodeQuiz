using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class DecodedStringAtIndex
    {
        public string DecodeAtIndexFail(string s, int k)
        {
            //不能硬做，會有天文數字
            var Result = new StringBuilder();
            foreach (char C in s)
            {
                if (C > 96)
                {
                    Result.Append(C);
                }
                else
                {
                    var temp = Result.ToString();
                    for (int i = 1; i < C - 48; i++)
                    {
                        foreach (var C2 in temp)
                        {
                            if (Result.Length >= k)
                            {
                                return "" + Result[k - 1];
                            }
                            Result.Append(C2);
                        }
                    }
                }
                if (Result.Length > k) break;
            }
            return "" + Result[k - 1];
        }
        public string DecodeAtIndex(string s, int k)
        {
            //英文字母的所在位置可以被目標位置整除
            //所以先計算總長度，在由最後面逐步回推，回推到k的倍數就是答案

            //PossibleLen 可能很大，所以用另一個數字取代k
            long K_Long = k;
            long PossibleLen = 0;
            foreach (char C in s)
            {
                //'a' = 97 = 最小可能數
                PossibleLen = C > 96 ? PossibleLen + 1 : PossibleLen * (C - 48);
            }
            for (int i = s.Length - 1; i > -1; i--)
            {
                //每一次取餘刷新
                K_Long %= PossibleLen;
                if (K_Long == 0 && s[i] > 96)
                {
                    return "" + s[i];
                }
                //'a' = 97 = 最小可能數
                if (s[i] > 96)
                {
                    PossibleLen--;
                }
                else
                {
                    //'1'=47
                    PossibleLen /= (s[i] - 48);
                }
            }
            return "";
        }
        public string DecodeAtIndex2(string S, int K)
        {
            int size = 0;
            int n = S.Length;

            // 計算解碼後字串的長度（size）
            for (int i = 0; i < n; i++)
            {
                char c = S[i];
                if (char.IsDigit(c))
                {
                    size *= c - '0';
                }
                else
                {
                    size++;
                }
            }

            for (int i = n - 1; i >= 0; i--)
            {
                char c = S[i];
                K %= size;
                if (K == 0 && char.IsLetter(c))
                {
                    return c.ToString();
                }
                if (char.IsDigit(c))
                {
                    size /= c - '0';
                }
                else
                {
                    size--;
                }
            }
            return "";
        }
    }
}
