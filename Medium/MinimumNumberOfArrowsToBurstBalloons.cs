using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class MinimumNumberOfArrowsToBurstBalloons
    {
        public int FindMinArrowShotsFail(int[][] points)
        {
            //不能提防極大值
            var DictLine = new Dictionary<int, bool>();
            int Result = 0;
            foreach (var line in points)
            {
                for (int i = line[0]; i <= line[1]; i++)
                {
                    if (DictLine.ContainsKey(i))
                    {
                        Result--;
                        break;
                    }
                    else
                    {
                        DictLine[i] = true;
                    }
                }
                Result++;
            }
            return Result;
        }
        public int FindMinArrowShots(int[][] points)
        {
            //排序以確保不會有重複算的情況
            Array.Sort(points, (a, b) => a[0].CompareTo(b[0]));

            int Res = 1;
            int RightLimit = points[0][1];

            for (int i = 1; i < points.Length; ++i)
            {
                //新一條線的左邊小於等於上一條線右邊時
                //不需要再射一標，代表它們重疊
                if (points[i][0] <= RightLimit)
                {
                    //必須以第二顆氣球為準，移動極限距離
                    RightLimit = Math.Min(RightLimit, points[i][1]);
                }
                else
                {
                    //如果新一條線的左邊在上一條線右邊時，更新極限距離
                    ++Res;
                    RightLimit = points[i][1];
                }
            }

            return Res;
        }
    }
}
