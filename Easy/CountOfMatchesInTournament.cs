using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class CountOfMatchesInTournament
    {
        public int NumberOfMatches(int n)
        {
            int Result = 0;
            while (n > 1)
            {
                Result += n / 2;
                n -= n / 2;
            }
            return Result;
        }
    }
}
