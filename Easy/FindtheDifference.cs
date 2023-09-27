using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class FindtheDifference
    {
        public char FindTheDifferenceSlower(string s, string t)
        {
            if (s.Length == 0)
            {
                return t[0];
            }
            else
            {
                while (s.Length > 0)
                {
                    int IndexS = s.IndexOf(t[0]);
                    if (IndexS == -1)
                    {
                        return t[0];
                    }
                    else
                    {
                        s = s.Remove(IndexS, 1);
                        t = t.Remove(0, 1);
                    }
                }
            }
            return t[t.Length - 1];
        }
        public char FindTheDifference(string s, string t)
        {
            var sDict = new Dictionary<char, int>();
            foreach (var word in s)
            {
                if (!sDict.ContainsKey(word))
                {
                    sDict.Add(word, 1);
                }
                else
                {
                    sDict[word]++;
                }
            }
            foreach (var word in t)
            {
                if (!sDict.ContainsKey(word))
                {
                    return word;
                }
                else if (sDict[word] < 1)
                {
                    return word;
                }
                else
                {
                    sDict[word]--;
                }
            }
            return t[t.Length - 1];
        }
    }
}
