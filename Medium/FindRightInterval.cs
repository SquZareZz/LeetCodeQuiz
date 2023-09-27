using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class FindRightInterval
    {
        public int[] FindRightIntervalFail(int[][] intervals)
        {
            //太久
            var NextStart = intervals.Select(x => x[0]).ToList();
            var Result = new int[intervals.Length];
            var SortedNextStart = NextStart.ToList();
            SortedNextStart.Sort(); ;
            for (int i = 0; i < intervals.Length; i++)
            {
                var Tar = intervals[i][1];
                if (Tar > NextStart.Max())
                {
                    Result[i] = -1;
                }
                else
                {
                    Tar = SortedNextStart.Where(x => x >= Tar).FirstOrDefault();
                    Result[i] = NextStart.IndexOf(Tar);
                }
            }
            return Result;
        }
        public int[] FindRightInterval1(int[][] intervals)
        {
            int Len = intervals.Length;
            var SortedByHead = intervals.ToArray();
            Array.Sort(SortedByHead, (a, b) => { return a[0] - b[0]; });
            var ArrayZero = intervals.Select(x => x[0]).ToList();
            var Result = Enumerable.Repeat(-1, Len).ToArray();
            for (int i = 0; i < Len; i++)
            {
                var Tar = intervals[i][1];
                if (Tar == intervals[i][0])
                {
                    Result[i] = i;
                }
                else
                {
                    for (int j = 0; j < Len; j++)
                    {
                        if (SortedByHead[j][1] > Tar && SortedByHead[j][0] >= Tar)
                        {
                            Result[i] = ArrayZero.IndexOf(SortedByHead[j][0]);
                            break;
                        }
                    }
                }
            }
            return Result;
        }
    }
}
