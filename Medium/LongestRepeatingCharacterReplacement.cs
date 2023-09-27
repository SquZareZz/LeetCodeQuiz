using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class LongestRepeatingCharacterReplacement
    {
        public int CharacterReplacementFail(string s, int k)
        {
            //Fail => ABBB
            int Result = 1, Len = s.Length;
            for (int i = 0; i < Len - 1; i++)
            {
                var Candidate = s[i];
                int TempK = 0, TempLen = 1;
                for (int j = i + 1; j < Len; j++)
                {
                    if (Candidate == s[j])
                    {
                        TempLen++;
                    }
                    else
                    {
                        if (TempK < k)
                        {
                            TempLen++;
                            TempK++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                Result = Math.Max(TempLen, Result);
                if (Result > Len - i - 1)
                {
                    break;
                }
            }
            return Result;
        }
        public int CharacterReplacementFail2(string s, int k)
        {
            //左右兩邊都有可能
            int Result = 1, Len = s.Length;
            Result = Judge(s, k, Result);
            Result = Judge(String.Join("",s.Reverse()), k, Result);
            return Result;
        }
        public int Judge(string s,int k,int Result)
        {
            int Len = s.Length;
            for (int i = 0; i < Len - 1; i++)
            {
                var Candidate = s[i];
                var DictS = new Dictionary<char, int> { };
                int TempLen = 1;
                for (int j = i + 1; j < Len; j++)
                {
                    if (Candidate == s[j])
                    {
                        TempLen++;
                    }
                    else
                    {
                        if (DictS.Count - 1 < k)
                        {
                            if (DictS.Values.Sum() == k)
                            {
                                break;
                            }
                            else
                            {
                                TempLen++;
                            }
                            if (!DictS.ContainsKey(s[j]))
                            {
                                DictS.Add(s[j], 1);
                            }
                            else
                            {
                                DictS[s[j]]++;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                Result = Math.Max(TempLen, Result);
                if (Result > Len - i - 1)
                {
                    break;
                }

            }
            return Result;
        }
        public int CharacterReplacement(string s, int k)
        {
            int res = 0, maxCnt = 0, start = 0;
            //計算26個字母出現次數
            //要統計出現的次數，總長-最大，之後刪掉無法再容許的
            var counts= new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                //目前字母放進來，++
                counts[s[i] - 'A']++;
                //字母最大出現數為何，如果是重複字母，新的會比舊的大
                //如果不重複，沿用舊的紀錄
                maxCnt = Math.Max(maxCnt, counts[s[i] - 'A']);
                //當前 - 起始 + 1 = 總長 - 最大重複 = 容許的字母
                while (i - start + 1 - maxCnt > k)
                {
                    //如果當前字串超過容許替代量，把字首移除掉，起始點位置++
                    counts[s[start] - 'A']--;
                    start++;
                }
                //總長度跟當前結果比較
                res = Math.Max(res, i - start + 1);
            }
            return res;
        }
    }
}
