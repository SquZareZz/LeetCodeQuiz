using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class Non_overlappingIntervals
    {
        public int EraseOverlapIntervals(int[][] intervals)
        {
            //要找出數線不重複的地方，下一號的最小值 >= 上一號的最大值
            //為了避免數線的順序混淆，先按照數線的長度排序
            //也因為有按照順序排，起始一定是最小的數線
            Array.Sort(intervals, (a, b) => { return a[0] - b[0]; });
            int res = 0, n = intervals.Length, endLast = intervals[0][1];
            for (int i = 1; i < n; i++)
            {
                //因為是由小排到大，所以只要依循下一號的最小值 >= 上一號的最大值就能做
                int OverOrNot = endLast > intervals[i][0] ? 1 : 0;
                //如果重疊，把結束點更新成比較小條的數線；反之選擇下一號的最大值
                endLast = OverOrNot == 1 ? Math.Min(endLast, intervals[i][1]) : intervals[i][1];
                res += OverOrNot;
            }
            return res;
        }
    }
}
