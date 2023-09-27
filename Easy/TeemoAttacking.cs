using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class TeemoAttacking
    {
        public int FindPoisonedDuration(int[] timeSeries, int duration)
        {
            int FirstEnd = timeSeries[0] + duration;
            int Result = duration;
            for (int i = 1; i < timeSeries.Length; i++)
            {
                int duplicatedTime = 0;
                int Start = timeSeries[i];
                if (Start < FirstEnd)
                {
                    duplicatedTime = FirstEnd - Start;
                }
                Result += duration - duplicatedTime;
                FirstEnd = timeSeries[i] + duration;
            }
            return Result;

        }
    }
}
