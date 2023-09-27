using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class LongestPalindrome
    {
        public int LongestPalindrome1(string s)
        {
            bool oddExisting = false;
            if (s.Length > 0)
            {
                var sDict = new Dictionary<char, int>();
                string PalindromeResult = "";
                foreach (char c in s)
                {
                    if (!sDict.ContainsKey(c))
                    {
                        sDict.Add(c, 1);
                    }
                    else
                    {
                        sDict[c]++;
                    }
                }
                foreach (char c in sDict.Keys)
                {
                    if (!oddExisting)
                    {
                        oddExisting = sDict[c] % 2 == 1;
                    }
                    int PalLength = sDict[c] / 2;
                    for (int i = 0; i < PalLength; i++)
                    {
                        PalindromeResult += c;
                    }
                }
                int Result = PalindromeResult.Length;
                if (Result > 0)
                {
                    if (oddExisting)
                    {
                        return Result * 2 + 1;
                    }
                    else
                    {
                        return Result * 2;
                    }

                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 0;
            }
        }
        public int LongestPalindromeFastest(string s)
        {
            bool oddExisting = false;
            int Result = 0;
            var sDict = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (!sDict.ContainsKey(c))
                {
                    sDict.Add(c, 1);
                }
                else
                {
                    sDict[c]++;
                }
            }
            foreach (char c in sDict.Keys)
            {
                if (!oddExisting)
                {
                    oddExisting = sDict[c] % 2 == 1;
                }
                Result += sDict[c] / 2;
            }
            if (Result > 0)
            {
                if (oddExisting)
                {
                    return Result * 2 + 1;
                }
                else
                {
                    return Result * 2;
                }
            }
            else
            {
                return 1;
            }
        }
    }
}
