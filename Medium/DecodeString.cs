using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class DecodeString
    {
        public string DecodeString1(string s)
        {
            while (s.Contains('['))
            {
                int StartLeft = s.LastIndexOf('[');
                int StartRight = String.Concat(s.Skip(StartLeft + 1)).IndexOf("]") + StartLeft + 1;
                int NumLeft = StartLeft - 1;
                string NumStr = "";
                while (NumLeft > -1 && Int32.TryParse(s[NumLeft].ToString(), out int a))
                {
                    NumStr = a + NumStr;
                    NumLeft--;
                }
                NumLeft++;
                var ToPut = string.Concat(Enumerable.Repeat(s.Substring(StartLeft + 1, StartRight - StartLeft - 1), Int32.Parse(NumStr)));
                if (NumLeft < 1)
                {
                    s = s.Remove(0, StartRight - NumLeft + 1);
                }
                else
                {
                    s = s.Remove(NumLeft, StartRight - NumLeft + 1);
                }
                s = s.Insert(NumLeft, ToPut);
            }
            return s;
        }
    }
}
