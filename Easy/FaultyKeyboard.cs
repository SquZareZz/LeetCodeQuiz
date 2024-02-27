using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class FaultyKeyboard
    {
        public string FinalString(string s)
        {
            StringBuilder sb = new StringBuilder();
            //char[] pattern = { 'a', 'e', 'i', 'o', 'u' };
            foreach (char c in s)
            {
                if (c == 'i')
                {
                    var temp = sb.ToString().Reverse();
                    sb.Clear();
                    foreach (var c2 in temp)
                    {
                        sb.Append(c2);
                    }
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
        public string FinalString2(string s)
        {
            var Res = new Queue<char>();
            foreach (char c in s)
            {
                if (c == 'i')
                {
                    Res= new Queue<char>(Res.Reverse());
                }
                else
                {
                    Res.Enqueue(c);
                }
            }            
            return String.Join("", Res);
        }
    }
}
