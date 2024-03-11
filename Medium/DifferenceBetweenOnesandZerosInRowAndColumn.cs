using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class DifferenceBetweenOnesandZerosInRowAndColumn
    {
        public int[][] OnesMinusZeros(int[][] grid)
        {
            int Len = grid.Length;
            int Width = grid[0].Length;
            int[][] Result = new int[Len][];
            int[] ZerosRow = new int[Len], OnesRow = new int[Len];
            int[] ZerosCol = new int[Width], OnesCol = new int[Width];
            for (int k = 0; k < Width; k++)
            {
                //鎖住橫排
                for (int j = 0; j < Len; j++)
                {
                    if (grid[j][k] == 1)
                    {
                        OnesCol[k]++;
                    }
                    else
                    {
                        ZerosCol[k]++;
                    }
                }
            }

            for (int i = 0; i < Len; i++)
            {
                Result[i] = new int[grid[0].Length];
                //橫排只需要做一次
                ZerosRow[i] = grid[i].Count(x => x == 0);
                OnesRow[i] = grid[i].Length - ZerosRow[i];
                for (int k = 0; k < Width; k++)
                {
                    Result[i][k] = OnesRow[i] + OnesCol[k] - ZerosCol[k] - ZerosRow[i];
                }
            }
            return Result;
        }
        public int[][] OnesMinusZeros2(int[][] grid)
        {
            int Len = grid.Length, Width = grid[0].Length;
            int[][] Result = new int[Len][];
            int[] RowTotal = new int[Len], ColTotal = new int[Width];
            for (int k = 0; k < Width; k++)
            {
                //鎖住橫排
                for (int j = 0; j < Len; j++)
                {
                    if (grid[j][k] == 1)
                    {
                        ColTotal[k]++;
                    }
                    else
                    {
                        ColTotal[k]--;
                    }
                }
            }
            for (int i = 0; i < Len; i++)
            {
                Result[i] = new int[Width];
                //橫排只需要做一次
                //1的個數
                RowTotal[i] = grid[i].Count(x => x == 1);
                //0的個數
                RowTotal[i] -= (grid[i].Length - RowTotal[i]);
                for (int k = 0; k < Width; k++)
                {
                    Result[i][k] = RowTotal[i] + ColTotal[k];
                }
            }
            return Result;
        }
    }
}
