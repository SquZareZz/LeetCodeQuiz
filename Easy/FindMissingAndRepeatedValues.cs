using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class FindMissingAndRepeatedValues
    {
        public int[] FindMissingAndRepeatedValues1(int[][] grid)
        {
            var DictGrid = new Dictionary<int, bool>();
            int[] Result = new int[2];
            foreach (var temp in grid)
            {
                foreach (var temp2 in temp)
                {
                    if (DictGrid.ContainsKey(temp2))
                    {
                        Result[0] = temp2;
                    }
                    else
                    {
                        DictGrid[temp2] = true;
                    }
                }
            }
            for (int j = 1; j <= grid.Length * grid[0].Length; j++)
            {
                if (!DictGrid.ContainsKey(j))
                {
                    Result[1] = j;
                    return Result;
                }
            }
            return Result;
        }
        public int[] FindMissingAndRepeatedValues2(int[][] grid)
        {
            var judge = new bool[grid.Length * grid[0].Length + 1];
            judge[0] = true;
            int[] Result = new int[2];
            foreach (var temp in grid)
            {
                foreach (var temp2 in temp)
                {
                    if (!judge[temp2])
                    {
                        judge[temp2] = true;
                    }
                    else
                    {
                        Result[0] = temp2;
                    }
                }
            }
            Result[1] = judge.Select((BoolRes, index) => new { BoolRes, index })
                        .Where(pair => pair.BoolRes == false)
                        .Select(pair => pair.index).First();
            return Result;
        }
    }
}
