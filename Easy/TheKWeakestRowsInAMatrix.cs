using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class TheKWeakestRowsInAMatrix
    {
        public int[] KWeakestRows(int[][] mat, int k)
        {
            var ResultDict = new Dictionary<int, int>();
            var Result = new List<int>();
            for (var i=0;i<mat.Length;i++)
            {
                ResultDict.Add(i, mat[i].Where(x => x == 1).Count());
            }
            for (int i = 0; i < k; i++)
            {
                var Min = ResultDict.Where(x => x.Value == ResultDict.Values.Min()).FirstOrDefault().Key;
                Result.Add(Min);
                ResultDict.Remove(Min);
            }
            return Result.ToArray();
        }
        public int[] KWeakestRows2(int[][] mat, int k)
        {
            var ResultDict = new List<int>();
            for (var i = 0; i < mat.Length; i++)
            {
                ResultDict.Add(mat[i].Where(x => x == 1).Count());
            }            
            return ResultDict.Select((value, index) => new { Value = value, Index = index })
            .OrderBy(item => item.Value)
            .Take(k)
            .Select(item => item.Index)
            .ToArray(); 
        }
    }
}
