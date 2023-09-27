using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class MinimumTimeToCompleteTrips
    {
        public long MinimumTime(int[] time, int totalTrips)
        {
            long MostTime = Convert.ToInt64(Math.Pow(10,14));
            long Left = time.Min();
            while (Left < MostTime)
            {
                long Mid = (MostTime + Left) / 2;
                long totalTripsTemp = totalTrips;
                foreach (var t in time)
                {
                    totalTripsTemp -= Mid / t;
                }
                if(totalTripsTemp <= 0)
                {
                    MostTime = Mid;
                }
                else
                {
                    Left = Mid+1;
                }
            }
            return MostTime;
        }
        public long MinimumTime2(int[] time, int totalTrips)
        {
            long MostTime = 100000000000000;//10^14
            long Left =1;
            while (Left < MostTime)
            {
                long Mid = (MostTime + Left) / 2;// >> 1可以代替除以二
                long totalTripsTemp = totalTrips;
                foreach (var t in time)
                {
                    totalTripsTemp -= Mid /t;
                }
                if (totalTripsTemp <= 0)
                {
                    MostTime = Mid;
                }
                else
                {
                    Left = Mid + 1;
                }
            }
            return MostTime;
        }
    }
}
