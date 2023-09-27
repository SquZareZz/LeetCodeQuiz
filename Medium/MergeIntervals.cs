using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class MergeIntervals
    {
        public int[][] Merge(int[][] intervals)
        {
            //首先排出左邊，由小到大
            //接著排出右邊，也是由小到大
            //如果下一號的左邊比當前的右邊還大，代表換了一個區間
            //如果到了最後一號左極限，也是最後一個區間
            //做完以後把起始點跳到下一號
            int Len = intervals.Length;
            int[] Starts = new int[Len];
            int[] Ends = new int[Len];
            for(int i = 0; i < Len; i++)
            {
                Starts[i] = intervals[i][0];
                Ends[i] = intervals[i][1];
            }
            Array.Sort(Starts);
            Array.Sort(Ends);
            List<int[]> Result= new List<int[]>();
            for(int i = 0,j=0; i < Len; i++)
            {
                if (i == Len - 1 || Starts[i + 1] > Ends[i])
                {
                    Result.Add(new int[] { Starts[j], Ends[i] });
                    j = i+ 1;
                }
            }
            return Result.Select(i =>i).ToArray();
        }
    }
}
