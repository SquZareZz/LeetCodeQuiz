using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class ReverseWordsInAString
    {
        public string ReverseWords(string s)
        {
            var TempArray = new List<string>();
            string temp = "", Result = "";
            int Sep = 0;
            foreach (var word in s)
            {
                if (word == ' ')
                {
                    if (temp != String.Empty) TempArray.Add(temp);
                    temp = "";
                    TempArray.Add(word.ToString());
                }
                else if (word == '\t')
                {
                    if (temp != String.Empty) TempArray.Add(temp);
                    temp = "";
                    TempArray.Add(" ");
                }
                else if (!" \t".Contains(word))
                {
                    temp += word;
                }
            }
            if (temp != String.Empty) TempArray.Add(temp);
            foreach (var word in TempArray.ToArray().Reverse())
            {
                Sep = " \t".Contains(word) ? Sep + 1 : 0;
                if (Sep > 1)
                {
                    continue;
                }
                else
                {
                    Result += word;
                }
            }
            return Result.Trim();
        }
        public string ReverseWords2(string s)
        {
            var a = "99.85%".Trim('%');
            var TempArray = s.Split(' ');
            string Result = "";
            foreach (var word in TempArray.Reverse())
            {
                if (word == String.Empty)
                {
                    continue;
                }
                else
                {
                    Result += word + " ";
                }
            }
            return Result.Trim();
        }
    }
}
