using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class FirstUniqueCharacterInAString
    {
        public int FirstUniqChar(string s)
        {
            var S_Dic = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (!S_Dic.ContainsKey(c))
                {
                    S_Dic.Add(c, 1);
                }
                else
                {
                    S_Dic[c]++;
                }
            }
            return s.IndexOf(S_Dic.FirstOrDefault(x => x.Value == 1).Key);
        }
    }
}
