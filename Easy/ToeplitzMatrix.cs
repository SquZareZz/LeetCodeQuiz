using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class ToeplitzMatrix
    {
        public bool IsToeplitzMatrix(int[][] matrix)
        {
            int Height = matrix.Length - 1;
            if (Height == 0)
            {
                return true;
            }
            else if (matrix[0].Length == 1)
            {
                return true;
            }
            for (int i = 0; i < Height; i++)
            {
                int DoWidth = i == 0 ? matrix[0].Length - 1 : 1;
                for (int j = 0; j < DoWidth; j++)
                {
                    int k = i + 1, jTemp = j + 1;
                    while (k < Height + 1)
                    {
                        if (matrix[k][jTemp] != matrix[k - 1][jTemp - 1])
                        {
                            return false;
                        }
                        k++;
                    }
                }
            }
            return true;
        }
    }
}
