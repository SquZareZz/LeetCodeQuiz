using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class LongestUncommonSubsequenceII
    {
        public int FindLUSlengthFail(string[] strs)
        {
            //可以暴力硬解，逐個迴圈找出最大值
            int Res = -1;
            for (int i = 0; i < strs.Length; i++)
            {
                for (int j = 0; j < strs.Length; j++)
                {
                    if (i == j) continue;
                    Res = Math.Max(Res, CheckMaxLenFail(strs[i], strs[j]));
                }
            }
            return Res;
        }
        public int CheckMaxLenFail(string Pattern, string Target)
        {
            int i = 0;
            foreach (var c in Pattern)
            {
                if (c == Target[i]) i++;
                if (i == Target.Length) break;
            }
            var BeCompared = Math.Min(Target.Length, Pattern.Length);
            return BeCompared != i ? BeCompared : -1;
        }
        public int FindLUSlength(string[] strs)
        {
            int res = -1, j = 0, n = strs.Length;
            for (int i = 0; i < n; ++i)
            {
                for (j = 0; j < n; ++j)
                {
                    if (i == j) continue;
                    if (CheckSubs(strs[i], strs[j])) break;
                }
                //如果 j++ 到超過最後一號，代表中間沒經歷過子字串，代表要更新
                if (j == n) res = Math.Max(res, strs[i].Length);
            }
            return res;
        }

        public bool CheckSubs(string subs, string str)
        {
            int i = 0;
            foreach (char c in str)
            {
                if (c == subs[i]) ++i;
                if (i == subs.Length) break;
            }
            //i 跟比較字串一樣長，代表為子序列
            return i == subs.Length;
        }
    }
}
