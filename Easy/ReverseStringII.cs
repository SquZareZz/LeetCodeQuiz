using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class ReverseStringII
    {
        //rule
        //if s.Length>2k => before k reverse
        //if (s.Length-2*n*k)<2k =>
        //type 1 is num of chars are less k => reverse all
        //type 2 is num of chars between k and 2k => reverse all k
        public string ReverseStr(string s, int k)
        {
            if (s.Length <= k)
            {
                string temp = "";
                foreach (char c in s)
                {
                    temp = c + temp;
                }
                return temp;
            }
            else
            {
                int LenS = s.Length;
                string temp = "";
                int Count = 0;
                for (int i = k - 1; i < LenS; i += 2 * k)
                {
                    for (int j = i; j > i - k; j--)
                    {
                        temp += s[j];
                    }
                    if (LenS > i + k)
                    {
                        temp += s.Substring(i + 1, k);
                    }
                    else
                    {
                        temp += s.Substring(i + 1, LenS - i - 1);
                    }
                    Count++;
                }
                int ProcessNum = 2 * k * Count;
                if (LenS - ProcessNum < k)
                {
                    for (int j = LenS - 1; j >= ProcessNum; j--)
                    {
                        temp += s[j];
                    }
                }
                else
                {
                    for (int j = ProcessNum + k + 1; j >= ProcessNum; j--)
                    {
                        temp += s[j];
                    }
                }
                return temp;
            }
        }
        public string ReverseStrFastest(string s, int k)
        {
            int LenS = s.Length;
            if (LenS >= k)
            {
                string temp = "";
                for (int i = 0; i < LenS; i += 2 * k)
                {
                    if (i + k <= LenS)
                    {
                        char[] charArray = s.Substring(i, k).ToCharArray();
                        Array.Reverse(charArray);
                        temp += new string(charArray);
                        if (i + 2 * k < LenS)
                        {
                            temp += s.Substring(i + k, k);
                        }
                        else
                        {
                            temp += s.Substring(i + k, LenS - i - k);
                        }
                    }
                    else
                    {
                        char[] charArray = s.Substring(i, LenS - i).ToCharArray();
                        Array.Reverse(charArray);
                        temp += new string(charArray);
                    }
                }
                return temp;
            }
            else
            {
                char[] charArray = s.ToCharArray();
                Array.Reverse(charArray);
                return new string(charArray);
            }
        }
        public string ReverseStr3(string s, int k)
        {
            int LenS = s.Length;
            if (LenS >= k)
            {
                string temp = "";
                for (int i = 0; i < LenS; i += 2 * k)
                {
                    if (i + k <= LenS)
                    {
                        temp += new string(s.Substring(i, k).Reverse().ToArray());
                        if (i + 2 * k < LenS)
                        {
                            temp += s.Substring(i + k, k);
                        }
                        else
                        {
                            temp += s.Substring(i + k, LenS - i - k);
                        }
                    }
                    else
                    {
                        temp += new string(s.Substring(i, LenS - i).Reverse().ToArray());
                    }
                }
                return temp;
            }
            else
            {
                return new string(s.Reverse().ToArray());
            }
        }
    }
}
