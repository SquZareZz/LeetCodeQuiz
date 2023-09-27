using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class NumberOfSegmentsInAString
    {
        public int CountSegments(string s)
        {
            if (s.Length == 0)
            {
                return 0;
            }
            else
            {
                string[] Result = s.Split(' ');
                Result = Result.Where(w => w != "").ToArray();
                return Result.Length;
            }
        }
    }
}
