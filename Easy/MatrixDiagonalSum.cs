using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class MatrixDiagonalSum
    {
        public int DiagonalSum(int[][] mat)
        {
            int Result = 0;
            int j = 0;
            int Len = mat.Length;
            for (int i = 0; i < Len; i++)
            {
                Result += mat[i][i];
            }
            for (int i = Len - 1; i > -1; i--)
            {
                Result += mat[j][i];
                j++;
            }
            return Len % 2 != 0 ? Result - mat[Len / 2][Len / 2] : Result;
        }
        public int DiagonalSum2(int[][] mat)
        {            
            int Result = 0;
            int Len = mat.Length;
            for (int i = 0; i < Len; i++)
            {
                Result += mat[i][i];
                Result += mat[i][Math.Abs(Len - 1 - i)];
            }
            return Len % 2 != 0 ? Result - mat[Len / 2][Len / 2] : Result;
        }
    }
}
