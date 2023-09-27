using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class UniquePathsII
    {
        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            //攤平成一維
            int Width = obstacleGrid.Length, Len = obstacleGrid[0].Length, Total = Width * Len;
            if (Total == 1)
            {
                return obstacleGrid[0][0] == 0 ? 1 : 0;
            }
            var DP = new int[Total];
            var Location = new List<int>();
            int LocationTemp = 0;
            foreach (var temp in obstacleGrid)
            {
                foreach (var temp2 in temp)
                {
                    if (temp2 == 1)
                    {
                        Location.Add(LocationTemp);
                    }
                    LocationTemp++;
                }
            }
            bool obstacleLen = Location.Contains(0)|| Location.Contains(Width * Len), obstacleWidth = obstacleLen;
            //原點和終點如果是0，那後續不用做了
            //做兩邊
            for (int i= 1; i < Total; i++)
            {
                if(i < Len) 
                { 
                        if (Location.Contains(i))
                        {
                            obstacleLen = true;
                        }
                        if (!obstacleLen)
                        {
                            DP[i] = 1;
                        }
                }
                else if(i >= Len && i % Len == 0)
                {
                    if (Location.Contains(i))
                    {
                        obstacleWidth = true;
                    }
                    if (!obstacleWidth)
                    {
                        DP[i] = 1;
                    }
                }
            }
            //做中間
            for (int i = 1; i < Width; i++)
            {
                for (int j = 1; j < Len; j++)
                {
                    if (!Location.Contains(Len * i + j))
                    {
                        DP[Len * i  + j] = DP[j + Len * (i  - 1)] + DP[(j - 1) + Len * i];
                    }
                    
                }
            }
            return DP[Total - 1];
        }
        public int UniquePathsWithObstacles2(int[][] obstacleGrid)
        {
            //維持二維
            int Width = obstacleGrid.Length, Len = obstacleGrid[0].Length, Total = Width * Len;
            var DP = new int[Total];
            if (Width == 1)
            {
                return obstacleGrid[0].Contains(1) ? 0 : 1;
            }
            else if (Len == 1)
            {
                foreach(var temp in obstacleGrid)
                {
                    if (temp[0] == 1)
                    {
                        return 0;
                    }
                }
                return 1;
            }
            else if (obstacleGrid[0][0]==1 || obstacleGrid[Width - 1][Len-1]==1)
            {
                return 0;
            }
            bool obstacleLen = false, obstacleWidth = false;
            //做兩邊
            for (int i = 1; i < Total; i++)
            {
                if (i < Len)
                {
                    if (obstacleGrid[0][i]==1)
                    {
                        obstacleLen = true;
                    }
                    if (!obstacleLen)
                    {
                        DP[i] = 1;
                    }
                }
                else if (i >= Len && i % Len == 0)
                {
                    if (obstacleGrid[i/Len][0] == 1)
                    {
                        obstacleWidth = true;
                    }
                    if (!obstacleWidth)
                    {
                        DP[i] = 1;
                    }
                }
            }
            //做中間
            for (int i = 1; i < Width; i++)
            {
                for (int j = 1; j < Len; j++)
                {
                    if (obstacleGrid[i][j] == 0) 
                    { 
                        DP[Len * i + j] = DP[j + Len * (i - 1)] + DP[(j - 1) + Len * i];
                    }

                }
            }
            return DP[Total - 1];
        }
    }
}
