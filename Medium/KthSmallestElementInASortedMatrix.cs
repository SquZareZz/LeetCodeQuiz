using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class KthSmallestElementInASortedMatrix
    {
        public int KthSmallest(int[][] matrix, int k)
        {
            var FlatArray=new List<int>();
            foreach (var row in matrix)
            {
                foreach (var element in row)
                {
                    FlatArray.Add(element);
                }                
            }
            FlatArray.Sort();
            return FlatArray[k-1];
        }
        public int KthSmallest2(int[][] matrix, int k)
        {
            //太久
            var Result = new int[k];
            int MatrixLen = matrix[0].Length;
            var MatrixCount = new int[MatrixLen];
            for(int i = 0; i < k; i++)
            {
                var Candidate = new int[MatrixLen];
                for(int j = 0; j < MatrixLen; j++)
                {
                    if(MatrixCount[j]==MatrixLen)
                    {
                        Candidate[j] = Int32.MaxValue;
                    }
                    else
                    {
                        Candidate[j] = matrix[j][MatrixCount[j]];
                    }
                }
                Result[i] = Candidate.Min();
                MatrixCount[Array.IndexOf(Candidate, Result[i])]++;
            }
            return Result[k-1];
        }
        public int KthSmallest3(int[][] matrix, int k)
        {
            //太久
            var Result = new int[k];
            int MatrixLen = matrix[0].Length;
            var MatrixCount = new int[MatrixLen];
            var Candidate = new int[MatrixLen];
            for (int j = 0; j < MatrixLen; j++)
            {
                Candidate[j] = matrix[j][0];
            }
            for (int i = 0; i < k; i++)
            {
                Result[i] = Candidate.Min();
                int index = Array.IndexOf(Candidate, Result[i]);
                MatrixCount[index]++;
                if (MatrixCount[index] == MatrixLen)
                {
                    Candidate[index] = Int32.MaxValue;
                }
                else
                {
                    Candidate[index] = matrix[index][MatrixCount[index]];
                }
            }
            return Result[k - 1];
        }
    }
}
