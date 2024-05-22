using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class CountTheNumberOfSpecialCharactersI
    {
        public int NumberOfSpecialChars(string word)
        {
            var HisList = new HashSet<string>();
            var Res = 0;
            foreach (char c in word)
            {
                var judge = c.ToString();
                if (HisList.Contains(judge.ToUpper()))
                {
                    continue;
                }
                switch ((int)c)
                {
                    case > 96:
                        var judgeTemp = judge.ToUpper();
                        if (word.Contains(judgeTemp))
                        {
                            Res++;
                            HisList.Add(judgeTemp);
                        }
                        break;
                    case < 97:
                        var judgeTemp2 = judge.ToLower();
                        if (word.Contains(judgeTemp2))
                        {
                            Res++;
                            HisList.Add(judge);
                        }
                        break;
                }
            }
            return Res;
        }
        public int NumberOfSpecialChars2(string word)
        {
            var HisList = new HashSet<int>();
            var Res = 0;
            foreach (char c in word)
            {
                switch ((int)c)
                {
                    case > 96:
                        if (HisList.Contains(c - 'a'))
                        {
                            continue;
                        }
                        if (word.Contains((char)(c - 32)))
                        {
                            Res++;
                            HisList.Add(c - 'a');
                        }
                        break;
                    case < 97:
                        if (HisList.Contains(c - 'A'))
                        {
                            continue;
                        }
                        if (word.Contains((char)(c + 32)))
                        {
                            Res++;
                            HisList.Add(c - 'A');
                        }
                        break;
                }


            }
            return Res;
        }
    }
}
