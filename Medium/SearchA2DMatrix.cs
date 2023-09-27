using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class SearchA2DMatrix
    {
        public bool SearchMatrix(int[][] matrix, int target)
        {
            foreach(var MatrixTemp in matrix)
            {
                foreach(int i in MatrixTemp)
                {
                    if(i == target)
                    {
                        return true;
                    }
                    else if (i > target)
                    {
                        return false;
                    }
                }
            }
            return false;
        }
    }
}
