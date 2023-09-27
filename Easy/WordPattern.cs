using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class WordPattern
    {
        public bool WordPatternSlower(string pattern, string s)
        {
            var WordDecode = new Dictionary<char, string>();
            var Wordcode = new Dictionary<string, char>();
            string[] sList = s.Split(' ');
            if (sList.Length != pattern.Length)
            {
                return false;
            }
            for (int i = 0; i < sList.Length; i++)
            {
                if (WordDecode.ContainsKey(pattern[i]))
                {
                    if (sList[i] != WordDecode[pattern[i]])
                    {
                        return false;
                    }
                }
                else
                {
                    WordDecode.Add(pattern[i], sList[i]);
                }
                if (Wordcode.ContainsKey(sList[i].ToString()))
                {
                    if (pattern[i] != Wordcode[sList[i]])
                    {
                        return false;
                    }
                }
                else
                {
                    Wordcode.Add(sList[i], pattern[i]);
                }
            }
            return true;
        }
        public bool WordPatternFaster(string pattern, string s)
        {
            var WordDecode = new string[25];//'a'=97
            string[] sList = s.Split(' ');
            if (sList.Length != pattern.Length)
            {
                return false;
            }
            for (int i = 0; i < sList.Length; i++)
            {
                int Depend = pattern[i] - 97;
                if (WordDecode[Depend] == null)
                {
                    WordDecode[Depend] = sList[i];
                }
                else
                {
                    if (sList[i] != WordDecode[Depend])
                    {
                        return false;
                    }
                }
                if (Array.IndexOf(WordDecode, sList[i]) != Array.LastIndexOf(WordDecode, sList[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
