using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class MinimumPathSum
    {
        public int MinPathSum2D(int[][] grid)
        {
            //找出所有可能，再用最小值覆蓋原位
            //最上邊和最左邊只有一種可能，所以可以先算
            int Len = grid[0].Length;
            int Width=grid.Length;
            for(int i = 1; i < Len; i++)
            {
                grid[0][i] += grid[0][i - 1];
            }
            for(int i = 1; i < Width; i++)
            {
                grid[i][0]+=grid[i - 1][0];
            }
            //找剩餘部分
            for(int j = 1; j < Width; j++)
            {
                for(int i=1; i < Len; i++)
                {
                    grid[j][i] += Math.Min(grid[j - 1][i], grid[j][i - 1]);
                }
            }
            return grid[Width - 1][Len - 1];
        }
        public int MinPathSum1D(int[][] grid)
        {
            //找出所有可能，再用最小值覆蓋原位
            //最上邊和最左邊只有一種可能，所以可以先算
            int Len = grid[0].Length;
            int Width = grid.Length;
            int[] Total = new int[Width * Len];
            int Count = 0;
            foreach(var WidthTemp in grid)
            {
                foreach(var LenTemp in WidthTemp)
                {
                    Total[Count] = LenTemp;
                    Count++;
                }
            }
            for (int i = 1; i < Len; i++)
            {
                Total[i] += Total[i - 1];
            }
            for (int i = 1; i < Width; i++)
            {
                Total[i*Len] += Total[(i-1) * Len];
            }
            //找剩餘部分
            for (int j = 1; j < Width; j++)
            {
                for (int i = 1; i < Len; i++)
                {
                    Total[i+j*Len] += Math.Min(Total[i + (j-1) * Len], Total[(i-1) + j * Len]);
                }
            }
            return Total[Width * Len-1];
        }
        public int MinPathSum2DMix(int[][] grid)
        {
            //找出所有可能，再用最小值覆蓋原位
            //最上邊和最左邊只有一種可能，但是放一起找
            int Len = grid[0].Length;
            int Width = grid.Length;
            for (int j = 0; j < Width; j++)
            {
                for (int i = 0; i < Len; i++)
                {
                    if (i == 0 && j == 0)
                    {
                        continue;
                    }
                    else if (i == 0)
                    {
                        grid[j][i] += grid[j - 1][i];
                    }
                    else if(j == 0)
                    {
                        grid[j][i] += grid[j][i - 1];
                    }
                    else
                    {
                        grid[j][i] += Math.Min(grid[j - 1][i], grid[j][i - 1]);
                    }
                }
            }
            return grid[Width - 1][Len - 1];
        }
    }
}
