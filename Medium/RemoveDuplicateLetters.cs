using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class RemoveDuplicateLetters
    {
        public string RemoveDuplicateLettersFail(string s)
        {
            var DictS = new Dictionary<char, int>();
            string Result = "";
            bool Start = true;
            while (Start || DictS.Where(x => x.Value > 1).Count() > 0)
            {
                DictS = new Dictionary<char, int>();
                string temp = "";
                foreach (char c in s)
                {
                    if (!DictS.ContainsKey(c))
                    {
                        DictS.Add(c, 1);
                        temp += c;
                    }
                    else
                    {
                        DictS[c]++;
                    }
                }
                if (Result == "" || Result[0] > temp[0])
                {
                    Result = temp;
                }
                foreach (var Tar in DictS.Where(x => x.Value > 1))
                {
                    if (s.Contains(Tar.Key))
                    {
                        s = s.Remove(s.IndexOf(Tar.Key), 1);
                    }
                }
                Start = false;
            }

            return Result;
        }
        public string RemoveDuplicateLetters1(string s)
        {
            //直觀解
            //a~z => 97~122
            int[] Counter = new int[123];
            bool[] visited = new bool[123];
            StringBuilder res = new StringBuilder("0"); // 創建一個結果字串，初始為"0"

            foreach (char a in s)
            {
                Counter[a]++; // 計算字串中每個字母的出現次數
            }

            foreach (char a in s)
            {
                Counter[a]--; // 用掉這個字母
                if (visited[a]) continue; // 如果字母已訪問過，則繼續下一個字母

                // 循環條件：當字母a小於結果字串中的最後一個字母，
                // 且最後一個字母在後續還會出現(Counter[字母]>0)
                while (a < res[^1] && Counter[res[^1]] > 0)
                {
                    visited[res[^1]] = false; // 將最後一個字母標記為未訪問
                    res.Remove(res.Length - 1, 1); // 移除最後一個字母
                }

                res.Append(a); // 將字母a添加到結果字串
                visited[a] = true; // 標記字母a為已訪問
            }

            return res.ToString().Substring(1); // 返回結果字串，排除掉起始的"0"
        }
        public string RemoveDuplicateLetters2(string s)
        {
            //逐個字母放入，因此每次要檢查下一個字母
            //如果下一個字母比前一個字母小，且後續還有提到上一個字母，則修正答案

            //不直觀解
            //字母只有26個，因此a~z => 97~122 都減掉97
            int[] m = new int[26];
            bool[] visited = new bool[26];
            StringBuilder res = new StringBuilder("a"); // 創建一個結果字串，初始為"a"

            foreach (char C in s)
            {
                m[C - 97]++; // 計算字串中每個字母的出現次數
            }

            foreach (char C in s)
            {
                m[C - 97]--; // 減少字母a的計數
                if (visited[C - 97]) continue; // 如果字母a已訪問過，則繼續下一個字母

                // 循環條件：當字母a小於結果字串中的最後一個字母，且最後一個字母在後續還會出現
                while (C < res[^1] && m[res[^1] - 97] > 0)
                {
                    visited[res[^1] - 97] = false; // 將最後一個字母標記為未訪問
                    res.Remove(res.Length - 1, 1); // 移除最後一個字母
                }

                res.Append(C); // 將字母a添加到結果字串
                visited[C - 97] = true; // 標記字母a為已訪問
            }

            return res.ToString().Substring(1); // 返回結果字串，排除掉起始的"0"

        }
    }
}
