using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class ValidPalindrome
    {
        public bool IsPalindromeSlowest(string s)
        {
            if (s.Length <= 1 && s.Length > -1)
            {
                return true;
            }
            else
            {
                s = new string(s.ToLower().Where(c => !char.IsPunctuation(c) && !c.Equals('`')).ToArray()).Replace(" ", "");
                string sReverse = "";
                for (int i = s.Length - 1; i > -1; i--)
                {
                    sReverse = sReverse + s[i].ToString();
                }
                if (s == sReverse)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
        public bool IsPalindrome(string s)
        {
            if (s.Length <= 1 && s.Length > -1)
            {
                return true;
            }
            else
            {
                s = new string(s.ToLower().Where(c => !char.IsPunctuation(c) && !c.Equals('`')).ToArray()).Replace(" ", "");
                for (int i = 0; i < s.Length / 2; i++)
                {
                    if (s[i] != s[s.Length - 1 - i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        public bool IsPalindromeSlower(string s)
        {
            if (s.Length <= 1 && s.Length > -1)
            {
                return true;
            }
            else
            {
                s = Regex.Replace(s.ToLower(), "[!\"#$%&'()*+,-./:;<=>?@\\[\\]^_`{|}~' ]", string.Empty);//正則表達式
                for (int i = 0; i < s.Length / 2; i++)
                {
                    if (s[i] != s[s.Length - 1 - i])
                    {
                        return false;
                    }
                }
                return true;
            }

        }
    }
}
