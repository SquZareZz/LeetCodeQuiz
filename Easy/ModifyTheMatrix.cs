using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class ModifyTheMatrix
    {
        public int[][] ModifiedMatrix(int[][] matrix)
        {
            for(int i = 0; i < matrix.Length; i++)
            {
                for(int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == -1)
                    {
                        var Tar = matrix[i][j];
                        foreach(var temp in matrix)
                        {
                            Tar = Math.Max(temp[j], Tar);
                        }
                        matrix[i][j] = Tar;
                    }
                }
            }
            return matrix;
        }
    }
}
