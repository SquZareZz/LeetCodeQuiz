using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class NumberOfEmployeesWhoMetTheTarget
    {
        public int NumberOfEmployeesWhoMetTarget(int[] hours, int target)
        {
            var Result = 0;
            foreach (var hour in hours)
            {
                if (hour >= target)
                {
                    Result++;
                }
            }
            return Result;
        }
        public int NumberOfEmployeesWhoMetTarget2(int[] hours, int target)
        {
            return hours.Count(x => x <= target);
        }
    }
}
