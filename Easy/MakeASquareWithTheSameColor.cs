using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class MakeASquareWithTheSameColor
    {
        public bool CanMakeSquare(char[][] grid)
        {
            for (int i = 0; i < grid.Length - 1; i++)
            {
                for (int j = 0; j < grid[i].Length - 1; j++)
                {
                    int Candidate = 0;
                    if (grid[i][j] == grid[i][j + 1]) Candidate++;
                    if (grid[i][j] == grid[i + 1][j]) Candidate++;
                    if (grid[i][j] == grid[i + 1][j + 1]) Candidate++;
                    if (Candidate != 1) return true;
                }
            }
            return false;
        }
    }
}
