using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class AsFarFromLandAsPossible
    {
        //其實只是在做深度搜尋法或廣度搜尋法
        //檢查每個陸地可以接觸到海洋的範圍，將接觸到的地方填滿陸地
        //最後被剩下的元素，那個點就是最遠的距離，接著要用曼哈頓距離來算，所以只要算迴圈做了幾次，就是最遠距離
        public int MaxDistanceFail(int[][] grid)
        {
            int EdgeLen = grid[0].Length;
            int[][] Map = new int[EdgeLen][];
            Map = grid;
            int Result = 0;
            int ZeroPresent = 0;
            foreach (var C in grid)
            {
                ZeroPresent = C.Where(x => x == 0).FirstOrDefault();
                if (ZeroPresent != -1)
                {
                    break;
                }
            }
            while (ZeroPresent != -1)
            {
                for (int j = 0; j < EdgeLen; j++)
                {
                    for (int i = 0; i < EdgeLen; i++)
                    {
                        switch (grid[j][i])
                        {
                            case 1:
                                if (i > 0)
                                {
                                    Map[j][i - 1] = 1;
                                }
                                if (i < EdgeLen - 1)
                                {
                                    Map[j][i + 1] = 1;
                                }
                                if (j > 0)
                                {
                                    Map[j - 1][i] = 1;
                                }
                                if (j < EdgeLen - 1)
                                {
                                    Map[j + 1][i] = 1;
                                }
                                break;
                        }
                    }
                }
                Result++;
                grid = Map;
                foreach (var C in grid)
                {
                    ZeroPresent = Array.IndexOf(C, 0);
                    if (ZeroPresent != -1)
                    {
                        break;
                    }
                }
            }
            return Result;
        }
        public int MaxDistance(int[][] grid)
        {
            int RowLen = grid[0].Length;
            int ColLen = grid.Length;
            int Result = 0;
            int[] SmoothArr = new int[RowLen * ColLen];//一維陣列比較好處理，故SMOOTH化
            for (int j = 0; j < ColLen; j++)
            {
                for (int i = 0; i < RowLen; i++)
                {
                    SmoothArr[j * ColLen + i] = grid[j][i];
                }
            }
            int AllElementCheck = SmoothArr.Count(x => x == 1);
            if (AllElementCheck == 0 || AllElementCheck == RowLen * ColLen)
            {
                return -1;
            }
            while (Array.IndexOf(SmoothArr, 0) != -1)
            {
                int[] tempArr = SmoothArr.ToArray();//複製一個預計更改的Array，迴圈結束後才對原始項修改
                for (int j = 0; j < ColLen; j++)
                {
                    for (int i = 0; i < RowLen; i++)
                    {
                        switch (SmoothArr[j * ColLen + i])
                        {
                            case 1:
                                if (i > 0)
                                {
                                    tempArr[j * ColLen + (i - 1)] = 1;
                                }
                                if (i < RowLen - 1)
                                {
                                    tempArr[j * ColLen + i + 1] = 1;
                                }
                                if (j > 0)
                                {
                                    tempArr[(j - 1) * ColLen + i] = 1;
                                }
                                if (j < ColLen - 1)
                                {
                                    tempArr[(j + 1) * ColLen + i] = 1;
                                }
                                break;
                        }
                    }
                }
                Result++;
                SmoothArr = tempArr;
            }
            return Result;
        }
        public int MaxDistance2(int[][] grid)
        {
            var DicGrid = new Dictionary<int, int>();
            int RowLen = grid[0].Length;
            int ColLen = grid.Length;
            int Result = 0;
            for (int j = 0; j < ColLen; j++)
            {
                for (int i = 0; i < RowLen; i++)
                {
                    DicGrid.Add(j * ColLen + i, grid[j][i]);
                }
            }
            int AllElementCheck = DicGrid.Values.Sum();
            if (AllElementCheck == 0 || AllElementCheck == RowLen * ColLen)
            {
                return -1;
            }
            while (AllElementCheck < RowLen * ColLen)
            {
                var ToDoList = new Dictionary<int, int>();
                for (int j = 0; j < ColLen; j++)
                {
                    for (int i = 0; i < RowLen; i++)
                    {
                        switch (DicGrid[j * ColLen + i])
                        {
                            case 1:
                                //if(!ToDoList.ContainsKey(j * ColLen + i))
                                int Loc;
                                if (i > 0)
                                {
                                    Loc = j * ColLen + (i - 1);
                                    if (!ToDoList.ContainsKey(Loc)) ToDoList.Add(Loc, 1);
                                }
                                if (i < RowLen - 1)
                                {
                                    Loc = j * ColLen + i + 1;
                                    if (!ToDoList.ContainsKey(Loc)) ToDoList.Add(Loc, 1);
                                }
                                if (j > 0)
                                {
                                    Loc = (j - 1) * ColLen + i;
                                    if (!ToDoList.ContainsKey(Loc)) ToDoList.Add(Loc, 1);
                                }
                                if (j < ColLen - 1)
                                {
                                    Loc = (j + 1) * ColLen + i;
                                    if (!ToDoList.ContainsKey(Loc)) ToDoList.Add(Loc, 1);
                                }
                                break;
                        }
                    }
                }
                Result++;
                foreach (int Num in ToDoList.Keys)
                {
                    DicGrid[Num] = 1;
                }
                AllElementCheck = DicGrid.Values.Sum();
            }
            return Result;
        }
    }
}
