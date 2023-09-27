using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class RangeAdditionII
    {
        public int MaxCount(int m, int n, int[][] ops)
        {
            if (ops.Length == 0)
            {
                return m * n;
            }
            else
            {
                int MinRow = ops[0][0];
                int MinCol = ops[0][1];
                for (int i = 1; i < ops.Length; i++)
                {
                    MinRow = ops[i][0] < MinRow ? ops[i][0] : MinRow;
                    MinCol = ops[i][1] < MinCol ? ops[i][1] : MinCol;
                }
                return MinRow * MinCol;
            }
        }
    }
}
