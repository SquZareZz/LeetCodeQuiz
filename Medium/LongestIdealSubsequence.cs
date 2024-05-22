using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class LongestIdealSubsequence
    {
        public int LongestIdealStringFail(string s, int k)
        {
            //c - 'a'，最小為 0，最大 25
            //Fail："eduktdb"
            //原因：掃不到所有的字串
            int Len = s.Length;
            var DP = new int[Len];
            for (int i = 0; i < Len; i++)
            {
                DP[i] = Len - i;
                var StartPoint = s[i] - 'a';
                for (int j = i + 1; j < Len; j++)
                {
                    if (Math.Abs(s[j] - 'a' - StartPoint) > k)
                    {
                        DP[i]--;
                    }
                    else
                    {
                        StartPoint = s[j] - 'a';
                    }
                }
            }
            return DP.Max();
        }
        public int LongestIdealString(string s, int k)
        {
            //c - 'a'，最小為 0，最大 25
            int Len = s.Length;
            //a to z 所有字母為頭，正負 k 個值能串的最大字串
            //計算當前文字可以接的文字分別有幾種，一路壘加到最後得到最優解
            //ex:abcdxyz => k=2 => a == b、c 的答案的累加，最小為一 => abc == 3
            //以此類推，b == a、c、d => bcd == 3
            //如果未來這個字母要捨棄，下一次被引用到的是上個 DP 的字母，所以不會有重複被覆蓋的問題
            var DP = new int[26];
            for (int i = 0; i < Len; i++)
            {
                var NowChar = s[i] - 'a';
                //最小 = 0 到 s[i] 或 s[i] - k 到 s[i]
                var StartPointMin = Math.Max(0, NowChar - k);
                //最大 = s[i] 到 25 或  s[i] 到 s[i] + k
                var StartPointMax = Math.Min(25, NowChar + k);
                int Result = 0;
                for(int j = StartPointMin; j <= StartPointMax; j++)
                {
                    //至少會比上一個狀態長度多 1
                    Result = Math.Max(Result, DP[j] + 1);
                }
                DP[NowChar] = Result;
            }
            return DP.Max();
        }
    }
}
