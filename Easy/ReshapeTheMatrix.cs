using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class ReshapeTheMatrix
    {
        public int[][] MatrixReshapeFail(int[][] mat, int r, int c)
        {
            var flatMatrix = mat.SelectMany(x => x).ToArray();
            int Len = flatMatrix.Length;
            if (r == c)
            {

            }
            int[][] Result = new int[Len][];
            int Count = 0;
            var temp = new List<int>();
            if (r < c)
            {
                for (int i = 0; i < Len; i++)
                {
                    temp.Add(flatMatrix[i]);
                    if ((i + 1) % (c / r) == 0)
                    {
                        Result[Count] = temp.ToArray();
                        Count++;
                        temp = new List<int>();
                    }
                }
            }
            else
            {
                for (int i = 0; i < Len; i++)
                {
                    temp.Add(flatMatrix[i]);
                    if ((i + 1) % c == 0)
                    {
                        Result[Count] = temp.ToArray();
                        Count++;
                        temp = new List<int>();
                    }
                }
            }


            return Result;
        }
        public int[][] MatrixReshape(int[][] mat, int r, int c)
        {
            var flatMatrix = mat.SelectMany(x => x).ToArray();
            if (flatMatrix.Length != r * c)
            {
                return mat;
            }
            int[][] Result = new int[r][];
            int Count = 0;
            var temp = new List<int>();
            for (int i = 0; i < flatMatrix.Length; i++)
            {
                temp.Add(flatMatrix[i]);
                if ((i + 1) % c == 0)
                {
                    Result[Count] = temp.ToArray();
                    Count++;
                    temp.Clear();
                }
            }
            return Result;
        }
    }
}
