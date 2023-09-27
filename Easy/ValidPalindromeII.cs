using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class ValidPalindromeII
    {
        public bool ValidPalindromeFail(string s)
        {
            int Len = s.Length;
            if (Len <= 1 && Len > -1)
            {
                return true;
            }
            int Count = 0, CountDic = 0;
            var DictS = new Dictionary<char, int>();
            //s = new string(s.ToLower().Where(c => !char.IsPunctuation(c) && !c.Equals('`')).ToArray()).Replace(" ", "");
            foreach (char c in s)
            {
                if (DictS.ContainsKey(c))
                {
                    DictS[c]++;
                }
                else
                {
                    DictS.Add(c, 1);
                }
            }
            for (int i = 0; i < Len / 2; i++)
            {
                if (s[i] != s[s.Length - 1 - i])
                {
                    Count++;
                    if (Count > 1)
                    {
                        return false;
                    }
                }

            }
            if (Count == 1)
            {
                foreach (var DictElement in DictS)
                {
                    if (DictElement.Value % 2 == 1)
                    {
                        CountDic++;

                    }
                }
            }
            else
            {
                return true;
            }
            if ((CountDic - 1) % 2 != 1)
            {
                return false;
            }
            return true;

        }
        public bool ValidPalindromeFail2(string s)
        {
            if (s.Length <= 1 && s.Length > -1)
            {
                return true;
            }
            var DictS = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (DictS.ContainsKey(c))
                {
                    DictS[c]++;
                }
                else
                {
                    DictS.Add(c, 1);
                }
            }
            foreach (var DictElement in DictS)
            {
                if (DictElement.Value % 2 == 0)
                {
                    s = new string(s.Where(x => x != DictElement.Key).ToArray());
                    DictS.Remove(DictElement.Key);
                }
            }
            if (s.Length < 2 || DictS.Count == 1)
            {
                return true;
            }
            foreach (var DictElement in DictS)
            {
                string sTemp = new string(s.Where(x => x != DictElement.Key).ToArray());
                int Len = sTemp.Length;
                if (Len == 1 && s[0] == s[1])
                {
                    return true;
                }
                for (int i = 0; i < Len / 2; i++)
                {
                    if (sTemp[i] != sTemp[Len - 1 - i])
                    {
                        break;
                    }
                    else if (sTemp[i] == sTemp[Len - 1 - i] && i == Len / 2 - 1)
                    {
                        return true;
                    }
                    else if (i == Len / 2 - 1 && Len % 2 == 1)
                    {
                        return true;
                    }
                }
            }
            return false;

        }
        public bool ValidPalindromeFail3(string s)
        {
            int Len = s.Length;
            if (Len <= 1 && Len > -1)
            {
                return true;
            }
            else if (Len % 2 == 1)
            {
                s = s + "0";
                Len = s.Length;
            }
            for (int i = 0; i < Len; i++)
            {
                if (s[i] != s[Len - 1 - i])
                {
                    s = s.Trim('0'); Len = s.Length;
                    string sTemp = s.Substring(0, i) + s.Substring(i + 1, Len - i - 1);
                    if (sTemp.Length == 1)
                    {
                        return true;
                    }
                    for (int j = 0; j < sTemp.Length / 2; j++)
                    {
                        if (sTemp[j] != sTemp[sTemp.Length - 1 - j])
                        {
                            break;
                        }
                        else if (sTemp[j] == sTemp[sTemp.Length - 1 - j] && j == sTemp.Length / 2 - 1)
                        {
                            return true;
                        }

                    }
                }
                else if (i == s.Length - 1)
                {
                    return false;
                }
            }
            return false;
        }
        public bool ValidPalindrome(string s)
        {
            //只需要注意到頭尾
            //如果頭尾是對的，往中間推進
            //如果對不上的話，那左邊的得對應到右往左一號，或者是右邊的得對應到左往右一號
            //如果還是對不上，有誤；如果對得上，那下一號會遇到相同的狀況，且後續都是對的
            //所以後續也不用檢查，因為預設只有一個字母是錯的，如果錯超過一個字母，會對不上
            int Left = 0; int Right = s.Length - 1;
            while (Left < Right)
            {
                if (s[Left] != s[Right])
                {
                    return JudgePalindrome(s, Left, Right - 1) || JudgePalindrome(s, Left + 1, Right);
                }
                Left++;
                Right--;
            }
            return true;
        }
        public bool JudgePalindrome(string s, int Left, int Right)
        {

            while (Left < Right)
            {
                if (s[Left] != s[Right]) return false;
                Left++;
                Right--;
            }
            return true;
        }
    }
}
