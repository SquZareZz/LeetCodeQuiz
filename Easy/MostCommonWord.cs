using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class MostCommonWord
    {
        public string MostCommonWord1(string paragraph, string[] banned)
        {
            string tempParagraph = "";
            foreach(char c in paragraph)
            {
                tempParagraph += !Char.IsPunctuation(c)? c:' ';
            }
            var SplitParagraph = tempParagraph.Split(' ').Where(x=>!String.IsNullOrEmpty(x));
            var times = new Dictionary<string, int>();
            foreach (var word in SplitParagraph)
            {
                string temp = string.Join("", word.ToLower());
                if (times.ContainsKey(temp))
                {
                    times[temp]++;
                }
                else
                {
                    times.Add(temp, 1);
                }
            }
            while (true)
            {
                foreach (var temp2 in times)
                {
                    if (temp2.Value == times.Values.Max() && banned.Contains(temp2.Key))
                    {
                        times.Remove(temp2.Key);
                        break;
                    }
                    else if (temp2.Value == times.Values.Max() && !banned.Contains(temp2.Key))
                    {
                        return temp2.Key;
                    }
                }
            }
        }
    }
}
