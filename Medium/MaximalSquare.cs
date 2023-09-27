using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class MaximalSquare
    {
        public int MaximalSquare1(char[][] matrix)
        {
            //-48
            int MaxArea = matrix.Select(x => x.Contains('1')).Contains(true) ? 1 : 0;
            for (int j = 0; j < matrix.Length; j++)
            {
                MaxArea = Math.Max(MaxArea, MaximalRightEdge(0, j, matrix, MaxArea, 0));
            }
            return MaxArea;
        }
        public int MaximalRightEdge(int StartX, int StartY, char[][] matrix, int MaxArea, int Length)
        {
            int Len = matrix[0].Length;
            for (int i = StartX; i < Len; i++)
            {
                if (matrix[StartY][i] == '1' && i != Len - 1)
                {
                    MaxArea = MaximalRightEdge(i + 1, StartY, matrix, MaxArea, Length + 1);
                    i += Length;
                }
                else
                {
                    Length = matrix[StartY][i] == '1' ? Length + 1 : Length;
                    StartX = matrix[StartY][i] == '1' ? StartX : StartX - 1;
                    while (Length * Length > MaxArea)
                    {
                        var CheckEachRow = matrix.Skip(StartY).Take(Length)
                            .Select(x => x.Skip(StartX + 1 - Length))
                            .Select(x => x.Take(Length))
                            .Where(x => !x.Contains('0'));
                        if (CheckEachRow.Count() != Length)
                        {
                            StartX--;
                            Length--;
                        }
                        else
                        {
                            return Math.Max(MaxArea, Length * Length);
                        }
                    }
                }
                Length = 0;
            }
            return MaxArea;
        }
        public int MaximalRightEdgeFail(int StartX, int StartY, char[][] matrix, int MaxArea, int Length)
        {
            int Len = matrix[0].Length;
            for (int i = StartX; i < Len; i++)
            {
                if (matrix[StartY][i] == '1' && i != Len - 1)
                {
                    MaxArea = MaximalRightEdge(i + 1, StartY, matrix, MaxArea, Length + 1);
                    if ((Len - i) * (Len - i) < MaxArea)
                    {
                        i += (int)Math.Sqrt(MaxArea);
                    }
                }
                else
                {
                    Length = matrix[StartY][i] == '1' ? Length + 1 : Length;
                    StartX = matrix[StartY][i] == '1' ? StartX : StartX - 1;
                    int StartXLoc = StartX - Length;
                    int LimitX = -1;
                    bool report = false;
                    while (Length * Length > MaxArea)
                    {
                        if (Len - StartY + 1 >= Length)
                        {
                            for (int a = StartY; a < Len; a++)
                            {
                                int temp = 0;
                                for (int b = StartXLoc; b < StartXLoc + Length; b++)
                                {
                                    temp += matrix[a][b] - 48;
                                }
                                if (temp != Length)
                                {
                                    report = false;
                                    break;
                                }
                                else
                                {
                                    report = true;
                                }
                            }
                            if (report)
                            {
                                return Math.Max(MaxArea, Length * Length);
                            }
                        }
                        Length--;
                        LimitX++;
                    }
                }
                Length = 0;
            }
            return MaxArea;
        }

        public int MaximalSquare2(char[][] matrix)
        {
            //右畫到左
            //↓ ↓ ↓ ↓ ↓
            int RowNum = matrix.Length, ColNum = matrix[0].Length, res = 0, LeftSide = 0;
            //每個 DP 只負責一行，又每一號的上限只看到該行擁有的列數。
            //所以第一次的DP最大可能值只有1、第二次2......
            //每次找完1，讓它跟DP比較最大值
            //最後做最大值平方
            //只需要看該值上方和左方，左上方已經被前一號DP Check過了
            var dp = new int[RowNum + 1];
            for (int j = 0; j < ColNum; j++)
            {
                for (int i = 1; i <= RowNum; i++)
                {
                    int temp = dp[i];
                    if (matrix[i - 1][j] == '1')//Left Side
                    {
                        //dp[i - 1] => TopSide
                        //如果在上邊界，dp[i - 1] 恆等於 0

                        dp[i] = Math.Min(dp[i], Math.Min(dp[i - 1], LeftSide)) + 1;
                        res = Math.Max(res, dp[i]);
                    }
                    else
                    {
                        dp[i] = 0;
                    }
                    LeftSide = temp;
                }
            }
            return res * res;
        }
    }
}
