using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class WordBreak
    {
        public bool WordBreak1(string s, IList<string> wordDict)
        {
            
            int Len = s.Length;
            //從第一個字母找，如果可以拼得出來，一定在字點裡會有一種是用首個字母拼的
            //可能性跟字母的長度一樣
            //字母全對的組合，會是找最後一號的布林值
            bool[] dp = new bool[Len + 1];
            //預設每個布林值是False，起始項是true
            dp[0] = true;

            for (int low = 0; low < Len; low++)
            {
                if (!dp[low])
                {
                    continue;
                }
                foreach (string word in wordDict)
                {
                    int high = low + word.Length;
                    //第一點是，這個字串長度加上接下來的字要小於等於最後的字串
                    //第二點是，接下來的這個字跟原先切割的字接起來，要完全等於目標字
                    //因為要符合順序，所以一定是從起始點切
                    //如果遇到相同長度的字串，第二點比對不會過
                    //持續重複的字串，會在第二點一直通過
                    if (high <= Len && s.Substring(low, high- low) ==word)
                    {
                        dp[high] = true;
                    }
                }
            }
            return dp[Len];
        }
        public bool WordBreak1Fail(string s, IList<string> wordDict)
        {
            var temp= String.Join("",wordDict.ToArray());
            return temp.Contains(s)||s.Contains(temp);
        }
    }
}
