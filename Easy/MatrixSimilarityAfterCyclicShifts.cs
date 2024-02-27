using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class MatrixSimilarityAfterCyclicShifts
    {
        public bool AreSimilar(int[][] mat, int k)
        {
            foreach (var Line in mat)
            {
                int move = k % Line.Length;
                if (move == 0)
                {
                    continue;
                }
                else
                {
                    var TransAfter = new List<int>();
                    foreach (var num in Line.Skip(move))
                    {
                        TransAfter.Add(num);
                    }
                    foreach (var num in Line.Take(move))
                    {
                        TransAfter.Add(num);
                    }
                    if (!Line.SequenceEqual(TransAfter))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
