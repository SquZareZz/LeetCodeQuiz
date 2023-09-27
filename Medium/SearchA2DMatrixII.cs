using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class SearchA2DMatrixII
    {
        public bool SearchMatrix(int[][] matrix, int target)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                int Len = matrix[i].Length;
                if (matrix[i][Len - 1] < target)
                {
                    continue;
                }
                else if (matrix[i].Contains(target))
                {
                    return true;
                }
                int low = 0, high = Len - 1, mid;
                while (low < high)
                {
                    if (target == matrix[i][low] || target == matrix[i][high])
                    {
                        return true;
                    }
                    mid = (low + high) / 2;
                    if (target > matrix[i][mid])
                    {
                        low = mid + 1;
                    }
                    else if (target < matrix[i][mid])
                    {
                        high = mid - 1;
                    }
                    else
                    {
                        return true;
                    }
                }

            }
            return false;
        }
        public bool SearchMatrix2(int[][] matrix, int target)
        {
            //二元搜尋
            int Len = matrix[0].Length;
            foreach (var Tar in matrix)
            {
                if (Tar[Len - 1] < target)
                {
                    continue;
                }
                else if (Tar.Contains(target))
                {
                    return true;
                }
                int low = 0, high = Len - 1, mid;
                while (low < high)
                {
                    if (target == Tar[low] || target == Tar[high])
                    {
                        return true;
                    }
                    mid = (low + high) / 2;
                    if (target > Tar[mid])
                    {
                        low = mid + 1;
                    }
                    else if (target < Tar[mid])
                    {
                        high = mid - 1;
                    }
                    else
                    {
                        return true;
                    }
                }

            }
            return false;
        }
    }
}
