using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class CountNegativeNumbersInASortedMatrix
    {
        public int CountNegatives(int[][] grid)
        {
            int Result = 0;
            foreach (var row in grid) 
            {
                foreach(var cell in row)
                {
                    if (cell < 0)
                    {
                        Result++;
                    }
                }
            }
            return Result;
        }
    }
}
