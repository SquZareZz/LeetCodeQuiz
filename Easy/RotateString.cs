using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class RotateString
    {
        public bool RotateString1(string s, string goal)
        {
            if (goal.Equals(s))
            {
                return true;
            }
            int Len = s.Length;
            for (int i = 0; i < Len - 1; i++)
            {
                string temp1 = s.Substring(0, i + 1);
                string temp2 = s.Substring(i + 1, Len - (i + 1));
                if (goal.Equals(temp2 + temp1))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
