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
            var Pattern = new char[] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            int a = 1;
            foreach (var split in sentence.Split(' '))
            {
                if (!Pattern.Contains(split[0]))
                {
                    result += string.Join("", split.Skip(1)) + split[0] + "ma";
                }
                else
                {
                    result += split + "ma";
                }
                result += string.Join("", Enumerable.Repeat('a', a)) + " ";
                a++;
            }
            return result.Trim();
        }
    }
}
