using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class LongestSubstringWithAtLeastKRepeatingCharacters
    {
        public int LongestSubstringFail(string s, int k)
        {
            int Len = s.Length;
            var DP = new int[Len];
            if (k == 1)
            {
                foreach (var temp in DP)
                {
                    DP[temp] = 1;
                }
            }
            for (int j = 0; j < Len; j++)
            {
                var DictStr = new Dictionary<char, int>
                {
                    { s[j], 1 }
                };
                if (DP.Max() > Len - j || k > Len - j + 1)
                {
                    break;
                }
                for (int i = j + 1; i < Len; i++)
                {
                    if (!DictStr.ContainsKey(s[i]))
                    {
                        DictStr.Add(s[i], 1);
                    }
                    else
                    {
                        DictStr[s[i]]++;
                    }
                    var Check = DictStr.Where(x => x.Value >= k);
                    if (i > 0)
                    {
                        DP[i] = Check.Count() == DictStr.Count() ?
                        Math.Max(Check.Select(x => x.Value).Sum(), DP[i]) : Math.Max(DP[i - 1], DP[i]);
                    }
                }
            }
            return DP.Max();
        }
        public int LongestSubstringFail2(string s, int k)
        {
            int Len = s.Length;
            var Result = 0;
            for (int i = 0; i < Len; i++)
            {
                string temp = s.Substring(0, i);
                string temp2 = "";
                foreach (char c in temp)
                {
                    if (!temp2.Contains(c))
                    {
                        temp2 += c;
                    }
                    else
                    {
                        break;
                    }
                }
                int TempResult = s.Split(temp2).Length - 1;
                if (TempResult >= k)
                {
                    Result = Math.Max(TempResult, Result);
                }
            }
            return Result;
        }
        public int LongestSubstringFail3(string s, int k)
        {
            while (s.Length >= k)
            {
                int Len = s.Length;
                var DictStr = new Dictionary<char, int>();
                foreach (var SChar in s)
                {
                    if (!DictStr.ContainsKey(SChar))
                    {
                        DictStr.Add(SChar, 1);
                    }
                    else
                    {
                        DictStr[SChar]++;
                    }
                }
                var HashStr = new HashSet<char>(s);
                int sumLimit = 0;
                foreach (var num in HashStr)
                {
                    sumLimit += k * (num - 96);
                }
                int sumTarget = 0;
                foreach (var num in s)
                {
                    sumTarget += (num - 96);
                }
                if (sumTarget >= sumLimit && DictStr.Where(x => x.Value >= k).Count() == DictStr.Count)
                {
                    return Len;
                }
                else
                {
                    var temp = DictStr.Where(x => x.Key == s[0] || x.Key == s[Len - 1]).ToDictionary(x => x.Key, x => x.Value);
                    int Left = 0, Right = 0;
                    foreach (var Scan1 in s)
                    {
                        if (Scan1 == s[0]) Left++;
                        else break;
                    }
                    foreach (var Scan2 in s.Reverse())
                    {
                        if (Scan2 == s[Len - 1]) Right++;
                        else break;
                    }
                    char Smaller;
                    if (Left > Right)
                    {
                        Smaller = s[Len - 1];
                    }
                    else if (Left < Right)
                    {
                        Smaller = s[0];
                    }
                    else
                    {
                        Smaller = temp.Where(x => x.Value == temp.Values.Min()).FirstOrDefault().Key;
                    }
                    switch (temp.Count)
                    {
                        case 0:
                            return 0;
                        case 1:
                            s = s.Trim(Smaller);
                            break;
                        case 2:
                            if (s[0] == Smaller)
                            {
                                s = s.Substring(s.LastIndexOf(Smaller) + 1);
                            }
                            else if (s[Len - 1] == Smaller)
                            {
                                s = s.Substring(0, s.IndexOf(Smaller));
                            }
                            break;

                    }
                }
            }
            return 0;
        }
        public int LongestSubstring(string s, int k)
        {
            int Len = s.Length, Result = 0;
            //首先檢查1~27號字母
            for (int i = 1; i < 27; i++)
            {
                //配對到滿足需求的字元
                int FitChar = 0;
                //暫存多少字元種類
                int HasChar = 0;
                //暫存當前的26個字母涵蓋數量
                var ChNum = new int[26];
                for (int Left = 0, Right = 0; Right < Len; Right++)
                {
                    //最左晃到最右
                    //s[intdex]-'a' => 字元轉數字
                    if (ChNum[s[Right] - 'a']++ == 0)
                    {
                        HasChar += 1;
                    }
                    if (ChNum[s[Right] - 'a'] == k)
                    {
                        FitChar += 1;
                    }
                    //如果左邊要調整，在這個 While 下調整
                    while (Left < Right && HasChar > i)
                    {
                        //不能超過k個，故要--
                        if (ChNum[s[Left] - 'a']-- == k)
                        {
                            FitChar -= 1;
                        }
                        //同個字母推進左邊，把多的HasChar減回來
                        if (ChNum[s[Left++] - 'a'] == 0)
                        {
                            HasChar -= 1;
                        }
                    }
                    if (FitChar == i)
                    {
                        Result = Math.Max(Result, Right - Left + 1);
                    }
                }
            }
            return Result;
        }
    }
}
