using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace QuizSolution.Medium
{
    public class EqualRowAndColumnPairs
    {
        public int EqualPairs(int[][] grid)
        {
            int Result = 0;
            foreach (var pair in grid)
            {
                for (int i = 0; i < grid.Length; i++)
                {
                    var Candidate = grid.Select(x => x[i]).ToList();
                    bool PassCheck = true;
                    for (int j = 0; j < grid.Length; j++)
                    {
                        if (pair[j] != Candidate[j])
                        {
                            PassCheck = false;
                            break;
                        }
                    }
                    Result += PassCheck ? 1 : 0;
                }
            }
            return Result;
        }
        public int EqualPairsFail(int[][] grid)
        {
            //組字串太慢
            int Result = 0;
            foreach (var pair in grid)
            {
                for (int i = 0; i < grid.Length; i++)
                {
                    var Candidate = grid.Select(x => x[i]).ToList();
                    Result += String.Equals(String.Join(",", pair), String.Join(",", Candidate)) ? 1 : 0;
                }
            }
            return Result;
        }
        public int EqualPairs2(int[][] grid)
        {
            int Result = 0;
            foreach (var pair in grid)
            {
                for (int i = 0; i < grid.Length; i++)
                {
                    var Candidate = grid.Select(x => x[i]).ToArray();
                    Result += pair.SequenceEqual(Candidate) ? 1 : 0;
                }
            }
            return Result;
        }
    }
}
