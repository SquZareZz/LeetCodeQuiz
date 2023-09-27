using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class SpiralMatrix
    {
        public IList<int> SpiralOrderFail(int[][] matrix)
        {
            var Result = new List<int>();
            bool ReverseOrNot = false;
            int High = matrix.Length - 1;
            int Width = matrix[0].Length;
            if (High == 0)
            {
                foreach (var num in matrix[0])
                {
                    Result.Add(num);
                }
                return Result;
            }
            else if (Width == 1)
            {
                foreach (var num in matrix)
                {
                    Result.Add(num[0]);
                }
                return Result;
            }
            int Total = (Width + 1) * (High + 2);
            int Count = 0, i = 0, j = 0;
            while (Count < Total && Width > 0 && High > 0)
            {
                if (!ReverseOrNot)
                {
                    for (; j < Width; j++)
                    {
                        Result.Add(matrix[i][j]);
                        Count++;
                    }
                    j--; i++;//抵銷超出去的部分+去下一號
                    for (; i <= High; i++)
                    {
                        Result.Add(matrix[i][j]);
                        Count++;
                    }
                    i--; j--;//抵銷超出去的部分+去下一號
                }
                else
                {
                    int Start1 = j, Start2 = i;
                    for (; j > Start1 - Width; j--)
                    {
                        Result.Add(matrix[i][j]);
                        Count++;
                    }
                    j++; i--;//抵銷超出去的部分+去下一號
                    if (High > 0)
                    {
                        for (; i >= Start2 - High; i--)
                        {
                            Result.Add(matrix[i][j]);
                            Count++;
                        }
                        i++;//抵銷超出去的部分
                    }
                    j++;
                }
                High--;
                Width--;
                ReverseOrNot = !ReverseOrNot;
            }
            for (int k = j; k <= Width; k++)
            {
                Result.Add(matrix[i][j]);
            }
            return Result;
        }
        public IList<int> SpiralOrder(int[][] matrix)
        {
            int High = matrix.Length, Width = matrix[0].Length;
            var Result = new List<int>();
            int Times = High > Width ? (Width + 1) / 2 : (High + 1) / 2;//計算畫一個圈的次數
            //當長比寬大時，最後一圈繞的是直的;反之相同
            for (int i = 0; i < Times; i++, High -= 2, Width -= 2)
            {
                //畫一圈為一個循環，一個循環後，寬和高都-2
                for (int col = i; col < i + Width; col++)//左往右
                {
                    Result.Add(matrix[i][col]);
                }
                for (int row = i + 1; row < i + High; row++)//上往下
                {
                    Result.Add(matrix[row][i + Width - 1]);
                }
                if (High == 1 || Width == 1)//如果做到高或寬=1的時候，表示做完了，跳出去
                {
                    break;
                }
                for (int col = i + Width - 2; col >= i; col--)//沒有的話繼續做右往左
                {
                    Result.Add(matrix[i + High - 1][col]);
                }
                for (int row = i + High - 2; row > i; row--)//下往上
                {
                    Result.Add(matrix[row][i]);
                }
            }
            return Result;
        }
    }
}
