using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class RotateImage
    {
        public void Rotate(int[][] matrix)
        {
            var TempArr = matrix.Select(x => x.ToArray()).ToArray();
            int Len = matrix.Length;
            for (int i = 0; i < Len; i++)
            {
                for (int j = 0; j < Len; j++)
                {
                    matrix[i][j] = TempArr[Len - 1 - j][i];
                }
            }
        }
        public void Rotate2(int[][] matrix)
        {
            //先對對角線翻轉，再水平翻轉
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = i + 1; j < matrix.Length; j++)
                {
                    (matrix[i][j], matrix[j][i]) = (matrix[j][i], matrix[i][j]);
                }
                Array.Reverse(matrix[i]);
            }
        }
    }
}
