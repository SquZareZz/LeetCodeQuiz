using NPOI.SS.Formula.Functions;
using NPOI.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class GoatLatin
    {
        public string ToGoatLatin(string sentence)
        {
            string result = "";
            var SplitSentence = sentence.Split(' ');
            var Pattern = new char[] { 'a', 'e', 'i', 'o', 'u' };
            int a = 1;
            foreach (var split in SplitSentence)
            {
                if (Array.IndexOf(Pattern, split[0]) > -1)
                {
                    result += split.Skip(1).ToString() + split[0] + "ma";
                }
                else
                {

                }
                result += string.Join("", Enumerable.Repeat('a', a))+" ";
                a++;
            }
            return result.Trim();
        }
    }
}
