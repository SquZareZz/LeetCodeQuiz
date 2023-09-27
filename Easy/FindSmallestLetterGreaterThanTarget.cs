using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class FindSmallestLetterGreaterThanTarget
    {
        public char NextGreatestLetter(char[] letters, char target)
        {
            char Result = letters[0];
            int Nearest = 27;
            foreach (char c in letters)
            {
                int temp = c - target;
                if (temp > 0 && temp < Nearest)
                {
                    Result = c;
                    Nearest = temp;
                }
            }
            return Result;
        }
    }
}
