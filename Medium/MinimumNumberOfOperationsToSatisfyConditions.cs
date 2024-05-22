using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class MinimumNumberOfOperationsToSatisfyConditions
    {
        public int MinimumOperations(int[][] grid)
        {
            //4 2 2
            //8 2 5
            //1 5 2

            //7,1,1,9
            //8,5,1,5
            //2,9,8,9
            //5,1,3,8
            //3+2+3+2
            // 狀況有幾種：
            // 1. 每一排數字出現最多次都跟右邊沒重複 => 最小動是不重複數字 -1
            // 2. 每一排數字出現最多次跟右邊有重複 =>
            //    a. 一排裡每個數字都和右排一樣（只有一個數字） => 其中一排要完全變成不重複的數字
            //    b. 一排裡面部分數字雷同 => 左邊選最少動的，右邊先排除左邊數字，再選最少動的
            // 所以每兩排一個比較
            int Res = 0, Point = -1;
            for (int j = 0; j < grid[0].Length; j++)
            {
                var NoDuplicateNums = new Dictionary<int, int>();
                var NoDuplicateNumsRight = new Dictionary<int, int>();
                //整理出不重複
                for (int i = 0; i < grid.Length; i++)
                {
                    NoDuplicateNums[grid[i][j]] =
                        NoDuplicateNums.ContainsKey(grid[i][j]) ? NoDuplicateNums[grid[i][j]] + 1 : 1;
                }
                if (j != grid[0].Length - 1)
                {
                    for (int i = 0; i < grid.Length; i++)
                    {
                        NoDuplicateNumsRight[grid[i][j + 1]] =
                            NoDuplicateNumsRight.ContainsKey(grid[i][j + 1]) ? NoDuplicateNumsRight[grid[i][j + 1]] + 1 : 1;
                    }
                }
                //最右直接算
                if (j == grid[0].Length - 1 )
                {
                    NoDuplicateNums.Remove(Point);
                    Res += NoDuplicateNums.Count > 0 ?
                        grid.Length - NoDuplicateNums[NoDuplicateNums.Where(x => x.Value == NoDuplicateNums.Values.Max()).First().Key] : 1;
                }
                else
                {
                    var judge = NoDuplicateNums.Keys.Intersect(NoDuplicateNumsRight.Keys).Count();
                    //全交集 + 只有一種數字
                    if (judge == NoDuplicateNums.Count && NoDuplicateNums.Count == 1)
                    {
                        //如果重複，一次做完兩行                        
                        //其中一行全部改掉，所以*2
                        if (NoDuplicateNumsRight.Count != 1)
                        {
                            NoDuplicateNumsRight.Remove(NoDuplicateNums.Keys.First());
                            Point = NoDuplicateNumsRight.Where(x => x.Value == NoDuplicateNumsRight.Values.Max()).First().Key;
                            Res += grid.Length - NoDuplicateNumsRight[Point];
                        }
                        else
                        {
                            Res++;
                        }
                        j++;
                    }
                    //完全交集，但不只一種數字
                    //部分交集，且不只一種數字
                    else if (judge <= NoDuplicateNums.Count && NoDuplicateNums.Count != 1 && judge > 0)
                    {
                        Point = NoDuplicateNums.Where(x => x.Value == NoDuplicateNums.Values.Max()).First().Key;
                        Res += grid.Length - NoDuplicateNums[Point];
                        NoDuplicateNumsRight.Remove(Point);
                        Point = NoDuplicateNumsRight.Where(x => x.Value == NoDuplicateNumsRight.Values.Max()).First().Key;
                        Res += grid.Length - NoDuplicateNumsRight[Point];
                        j++;
                    }
                    //完全沒交集 = 隨便找
                    else
                    {
                        Point = NoDuplicateNums.Where(x => x.Value == NoDuplicateNums.Values.Max()).First().Key;
                        Res += grid.Length - NoDuplicateNums[Point];
                    }
                }
            }
            return Res;
        }
        public int MinimumOperations2(int[][] grid)
        {
            //4 2 2
            //8 2 5
            //1 5 2
            //2
            // 狀況有幾種：
            // 1. 每一排數字出現最多次都跟右邊沒重複 => 最小動是不重複數字 -1
            // 2. 每一排數字出現最多次跟右邊有重複 =>
            //    a. 一排裡每個數字都和右排一樣（只有一個數字） => 其中一排要完全變成不重複的數字
            //    b. 一排裡面部分數字雷同 => 左邊選最少動的，右邊先排除左邊數字，再選最少動的

            //Point => 上一個取出來的數字，也就是說下一排先把這個數字排除掉，再更新 Point
            //如果刪除候補到剩空的 => 表示要找一個沒重複過的數字 => 加上原始長度
            //如果排除掉不存在的 Key => 不會被影響
            //Point 必須不跟
            int Res = 0, Point = -1;            
            return Res;
        }
    }
}
