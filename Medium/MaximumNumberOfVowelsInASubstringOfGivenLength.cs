using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class MaximumNumberOfVowelsInASubstringOfGivenLength
    {
        public int MaxVowels(string s, int k)
        {
            char[] template = { 'a', 'e', 'i', 'o', 'u' };
            if (k == 1)
            {
                return s.Count(x => template.Contains(x)) > 1 ? 1 : 0;
            }
            int Res = s.Substring(0, k).Count(x => template.Contains(x));
            int Last = Res;
            if (Res == k)
            {
                return k;
            }
            for (int i = 0; i <= s.Length - k - 1; i++)
            {
                int temp = Last;
                //Console.WriteLine("Before = " + s.Substring(i, k));
                temp -= template.Contains(s[i]) ? 1 : 0;
                temp += template.Contains(s[i + k]) ? 1 : 0;
                if (temp == k)
                {
                    return k;
                }
                Res = Math.Max(temp, Res);
                Last = temp;
                //Console.WriteLine("After = "+s.Substring(i+1, k));
                //Console.WriteLine(Last);
            }
            return Res;
        }
    }
}
