using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class CountOddNumbersInAnIntervalRange
    {
        public int Slowest(int low, int high)
        {
            int Result = 0;
            for (int i = low; i <= high; i++)
            {
                if (i % 2 == 1)
                {
                    Result++;
                }
            }
            return Result;
        }
        public int CountOdds(int low, int high)
        {
            bool OddHigh = high % 2 == 1;
            bool OddLow = low % 2 == 1;
            if (OddLow)
            {
                return (high - low) / 2 + 1;
            }
            else
            {
                return OddHigh ? (high - low) / 2 + 1 : (high - low) / 2;
            }
        }
        public int CountOdds2(int low, int high)
        {
            //最簡寫法
            return low % 2 == 1 ? (high - low) / 2 + 1 : high % 2 == 1 ? (high - low) / 2 + 1 : (high - low) / 2;
        }
    }
}
