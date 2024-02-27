using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class WidestVerticalAreaBetweenTwoPointsContainingNoPoints
    {
        public int MaxWidthOfVerticalArea(int[][] points)
        {
            int Result = 0;
            var Horizontal = new List<int>();
            foreach (var point in points)
            {
                Horizontal.Add(point[0]);
            }
            Horizontal.Sort();
            for (int i = 0; i < Horizontal.Count - 1; i++)
            {
                Result = Math.Max(Result, Horizontal[i + 1] - Horizontal[i]);
            }
            return Result;
        }
        public int MaxWidthOfVerticalArea2(int[][] points)
        {
            int Result = 0;
            Array.Sort(points, (a, b) => a[0].CompareTo(b[0]));
            for (int i = 0; i < points.Length - 1; i++)
            {
                Result = Math.Max(Result, points[i + 1][0] - points[i][0]);
            }
            return Result;
        }
    }
}
