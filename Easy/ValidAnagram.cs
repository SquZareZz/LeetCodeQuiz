using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class ValidAnagram
    {
        public bool IsAnagramFail(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }
            int TarTotal = 0;
            int TarTotal2 = 0;
            for (int i = 0; i < s.Length; i++)
            {
                TarTotal += s[i];
                TarTotal2 += t[i];
            }
            return TarTotal == TarTotal2;

        }
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }
            else
            {
                var LenDic = new Dictionary<string, int>();
                int TarTotal1 = 0;
                int TarTotal2 = 0;
                int temp = 1;
                for (int i = 0; i < s.Length; i++)
                {
                    if (!LenDic.ContainsKey(s[i].ToString()))
                    {
                        LenDic.Add(s[i].ToString(), temp);
                        TarTotal1 += temp;
                        temp++;
                    }
                    else
                    {
                        TarTotal1 += LenDic[s[i].ToString()];
                    }
                }
                for (int i = 0; i < t.Length; i++)
                {
                    if (LenDic.ContainsKey(t[i].ToString()))
                    {
                        TarTotal2 += LenDic[t[i].ToString()];
                    }
                    else
                    {
                        return false;
                    }
                }
                return TarTotal1 == TarTotal2;
            }
        }
        public bool IsAnagramFail2(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }
            else
            {
                var LenDic = new Dictionary<string, int>();
                int TarTotal1 = 0;
                int TarTotal2 = 0;
                int temp = 1;
                for (int i = 0; i < s.Length; i++)
                {
                    if (!LenDic.ContainsKey(s[i].ToString()))
                    {
                        LenDic.Add(s[i].ToString(), temp);
                        temp++;
                    }
                    TarTotal1 += s[i];
                    TarTotal2 += t[i];
                }
                for (int i = 0; i < t.Length; i++)
                {
                    if (!LenDic.ContainsKey(t[i].ToString()))
                    {
                        return false;
                    }
                }
                return TarTotal1 == TarTotal2;
            }
        }
        public bool IsAnagramLastMemory(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }
            else
            {
                var TarIntArr = s.ToCharArray().ToList();
                foreach (char c in t)
                {
                    if (!TarIntArr.Contains(c))
                    {
                        return false;
                    }
                    else
                    {
                        TarIntArr.Remove(c);
                    }
                }
                return true;
            }
        }
    }
}

