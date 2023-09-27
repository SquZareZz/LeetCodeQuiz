using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class IsomorphicStrings
    {
        public bool IsIsomorphicFail(string s, string t)
        {
            //baba;badc
            var DicIsomorphicS = new Dictionary<string, string>();
            for (int i = 0; i < s.Length; i++)
            {
                string ToDependS = s[i].ToString();
                string ToDependT = t[i].ToString();
                if (DicIsomorphicS.ContainsKey(ToDependS))
                {
                    if (DicIsomorphicS[ToDependS] != ToDependT)
                    {
                        return false;
                    }
                    //DicIsomorphicS.TryGetValue(ToDependT, out var temp);
                    //if (temp!=)
                }
                else if (DicIsomorphicS.ContainsKey(ToDependT))
                {
                    if (DicIsomorphicS[ToDependT] != ToDependS)
                    {
                        return false;
                    }
                }
                else
                {
                    DicIsomorphicS.Add(s[i].ToString(), t[i].ToString());
                }
            }
            return true;
        }
        public bool IsIsomorphicTooSlow(string s, string t)
        {
            //badc;baba
            var DicIsomorphicS = new Dictionary<string, string>();
            for (int i = 0; i < s.Length; i++)
            {
                if (!DicIsomorphicS.ContainsKey(s[i].ToString()))
                {
                    DicIsomorphicS.Add(s[i].ToString(), t[i].ToString());
                }
                string ToDepend = DicIsomorphicS[s[i].ToString()];
                if (ToDepend != t[i].ToString() || s[i].ToString() != DicIsomorphicS.FirstOrDefault(x => x.Value == ToDepend).Key)
                {
                    return false;
                }
            }
            return true;
        }
        public bool IsIsomorphic(string s, string t)
        {
            //badc;baba
            for (int i = 0; i < s.Length; i++)
            {
                int dupCheck = s.LastIndexOf(s[i]);
                int dupCheck2 = t.LastIndexOf(t[i]);
                if (i != dupCheck)
                {
                    if (t[i] != t[dupCheck])
                    {
                        return false;
                    }
                }
                else if (i != dupCheck2)
                {
                    if (s[i] != s[dupCheck2])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
