using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class AverageSalaryExcludingTheMinimumAndMaximumSalary
    {
        public double Average(int[] salary)
        {
            Double a = salary.Where(x => x != salary.Max() && x != salary.Min()).Sum();
            Double Len = salary.Length - 2;
            return a/Len;
        }
    }
}
