using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class ReverseWordsInAStringIII
    {
        public string ReverseWords(string s)
        {
            string result = "";
            foreach (string S in s.Split(' '))
            {
                result += new string(S.Reverse().ToArray()) + " ";
            }
            return result.Trim(' ');
        }
        public string ReverseWords2(string s)
        {
            string[] Ssplit = s.Split(' ');
            string result = "";
            foreach (string S in Ssplit)
            {
                char[] charArray = S.ToCharArray();
                Array.Reverse(charArray);
                result += new string(charArray) + " ";
            }
            return result.Trim(' ');
        }
        public string ReverseWordsFastest(string s)
        {
            string[] Ssplit = s.Split(' ');
            for (int i = 0; i < Ssplit.Length; i++)
            {
                Ssplit[i] = new string(Ssplit[i].Reverse().ToArray());
            }
            return string.Join(" ", Ssplit);
        }

    }
}
