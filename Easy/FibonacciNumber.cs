using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class FibonacciNumber
    {
        public int Fib(int n)
        {
            switch (n)
            {
                case 0:
                    return 0;
                case 1:
                    return 1;
                default:
                    int BF1 = 1;
                    int BF2 = 0;
                    int Result = 0;
                    for (int i = 1; i < n; i++)
                    {
                        Result = BF1 + BF2;
                        BF2 = BF1;
                        BF1 = Result;
                    }
                    return Result;
            }
        }
    }
}
