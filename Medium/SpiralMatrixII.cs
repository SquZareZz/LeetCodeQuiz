using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class SpiralMatrixII
    {
        public int[][] GenerateMatrix(int n)
        {
            //因為是方陣，所以長寬都相等，不另外列式
            int Count=1, times = n;//不可以是n-1，因為有可能是1*1
            int[][] Result = new int[n][];
            for(int i=0;i<n;i++)
            {
                Result[i] = new int[n];
            }
            for (int i = 0; i < times; i++,n -= 2)
            {
                //畫一圈為一個循環，一個循環後，寬和高都-2
                for (int col = i; col < i + n; col++)//左往右
                {
                    Result[i][col] = Count;
                    Count++;
                }
                for (int row = i + 1; row < i + n; row++)//上往下
                {
                    Result[row][i + n - 1] = Count;
                    Count++;
                }
                if (n == 1 )//如果做到高或寬=1的時候，表示做完了，跳出去
                {
                    break;
                }
                for (int col = i + n - 2; col >= i; col--)//沒有的話繼續做右往左
                {
                    Result[i + n - 1][col]=Count;
                    Count++;
                }
                for (int row = i + n - 2; row > i; row--)//下往上
                {
                    Result[row][i] = Count;
                    Count++;
                }
            }
            return Result;
        }
    }
}
