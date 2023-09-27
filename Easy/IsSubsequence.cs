using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class IsSubsequence
    {
        public bool IsSubsequenceFail(string s, string t)
        {
            int LastIndex = 0;
            if (s.Length == 0)
            {
                return true;
            }
            else if (t.Length < s.Length)//開頭結尾、後比前長
            {
                return false;
            }
            else
            {
                foreach (var word in s)
                {
                    int NowIndex = t.IndexOf(word);
                    if (NowIndex < 0)
                    {
                        return false;
                    }
                    if (NowIndex < LastIndex && NowIndex != 0 && LastIndex > t.LastIndexOf(word))
                    {
                        return false;
                    }
                    //t = t.Remove(NowIndex, 1);
                    LastIndex = NowIndex;
                }
            }
            return true;
        }
        public bool IsSubsequence1(string s, string t)
        {
            int i, j;
            for (i = 0, j = 0; i < s.Length && j < t.Length;)
            {
                if (s[i] == t[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    j++;
                }
            }
            return i >= s.Length;
        }
    }
}
