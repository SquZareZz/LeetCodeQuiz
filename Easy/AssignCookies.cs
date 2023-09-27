using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class AssignCookies
    {
        public int FindContentChildren(int[] g, int[] s)
        {
            Array.Sort(g);
            Array.Sort(s);
            int Result = 0;
            for (int i = 0, j = 0; i < g.Length && j < s.Length;)
            {
                if (g[i] <= s[j])
                {
                    Result++;
                    i++;
                }
                else
                {
                    j++;
                }
            }
            return Result;
        }
    }
}
