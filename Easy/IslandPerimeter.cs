using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class IslandPerimeter
    {
        public int IslandPerimeter1(int[,] grid)
        {
            int Result = 0;
            int RowLen = grid.GetLength(0);
            int ColLen = grid.GetLength(1);
            for (int i = 0; i < RowLen; i++)
            {
                for (int j = 0; j < ColLen; j++)
                {
                    if (grid[i, j] == 1)
                    {
                        if (j == 0 || grid[i, j - 1] == 0)//上
                        {
                            Result++;
                        }
                        if (i == 0 || grid[i - 1, j] == 0)//左
                        {
                            Result++;
                        }
                        if (j == ColLen - 1 || grid[i, j + 1] == 0)//下
                        {
                            Result++;
                        }
                        if (i == RowLen - 1 || grid[i + 1, j] == 0)//右
                        {
                            Result++;
                        }

                    }
                }
            }
            return Result;
        }
        public int IslandPerimeter2(int[][] grid)
        {
            //上下左右各看一次，有四個事件處理
            //當它為邊框時直接計算，所以每個事件都有一個OR條件
            int Result = 0;
            int RowLen = grid.GetLength(0);
            int ColLen = grid[0].GetLength(0);
            for (int i = 0; i < RowLen; i++)
            {
                for (int j = 0; j < ColLen; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        if (j == 0 || grid[i][j - 1] == 0)//上
                        {
                            Result++;
                        }
                        if (i == 0 || grid[i - 1][j] == 0)//左
                        {
                            Result++;
                        }
                        if (j == ColLen - 1 || grid[i][j + 1] == 0)//下
                        {
                            Result++;
                        }
                        if (i == RowLen - 1 || grid[i + 1][j] == 0)//右
                        {
                            Result++;
                        }

                    }
                }
            }
            return Result;
        }
    }
}
