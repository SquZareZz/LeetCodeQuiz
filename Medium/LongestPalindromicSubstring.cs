using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class LongestPalindromicSubstring
    {
        public string LongestPalindromeFail(string s)
        {
            string Result = "" + s[0];
            if (s.Length == 1)
            {
                return s;
            }
            bool OddOrEven = s.Length % 2 == 1;
            int Len = OddOrEven ? (s.Length + 1) / 2 : s.Length / 2, Start = Len;

            for (int i = 0; i < Len; i++)
            {
                string CharFront = s.Substring(i, Start);
                int CharFrontLen = CharFront.Length;
                int CharAfterIndex = i + CharFrontLen - 1;
                int CountJ = 0;
                if (CharFrontLen == 1 && s[i] == s[i + 1] && Result.Length < 2)
                {
                    Result = s.Substring(i, 2);
                }
                for (int j = i; j < CharAfterIndex; j++)
                {
                    if (s[j] != s[i + CharFrontLen - CountJ])
                    {
                        Start--;
                        Start = Start == 0 ? Len : Start;
                        if (Start != Len)
                        {
                            i--;
                        }
                        break;
                    }
                    if (j == CharAfterIndex - 1)
                    {
                        if (Result.Length < 2 * CharFrontLen - 1)
                        {
                            Result = OddOrEven ? s.Substring(i, 2 * CharFrontLen - 1) : s.Substring(i, 2 * CharFrontLen);
                        }
                    }
                    CountJ++;
                }
                if (Result.Length >= Len)
                {
                    return Result;
                }
            }
            return Result;
        }
        public string LongestPalindrome(string s)
        {
            string Result = "" + s[0];
            for (int i = 0; i < s.Length; i++)
            {
                //無法事先決定奇偶，因為字串可能出現奇數、偶數
                Result = IsPalindromeSlideWindow(s, Result, i, i);//for奇數
                Result = IsPalindromeSlideWindow(s, Result, i, i + 1);//for偶數
            }
            return Result;
        }
        public string LongestPalindrome2(string s)
        {
            string Result = "" + s[0];
            for (int i = 0; i < s.Length; i++)
            {
                //無法事先決定奇偶，因為字串可能出現奇數、偶數
                //for奇數
                int Left = i, Right = i;
                while (Left > -1 && Right < s.Length && s[Left] == s[Right])
                {
                    Left--;
                    Right++;
                }
                Result = Right - Left - 1 > Result.Length ? s.Substring(Left + 1, Right - Left - 1) : Result;
                //for偶數
                Left = i; Right = i + 1;
                while (Left > -1 && Right < s.Length && s[Left] == s[Right])
                {
                    Left--;
                    Right++;
                }
                Result = Right - Left - 1 > Result.Length ? s.Substring(Left + 1, Right - Left - 1) : Result;
            }
            return Result;
        }
        public string IsPalindromeSlideWindow(string s, string Compare, int Left, int Right)
        {
            while (Left > -1 && Right < s.Length && s[Left] == s[Right])
            {
                Left--;
                Right++;
            }
            return Right - Left - 1 > Compare.Length ? s.Substring(Left + 1, Right - Left - 1) : Compare;
        }

    }
}
