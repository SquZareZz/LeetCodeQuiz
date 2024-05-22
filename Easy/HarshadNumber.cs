using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class HarshadNumber
    {
        public int SumOfTheDigitsOfHarshadNumber(int x)
        {
            var judge = x.ToString();
            var Harshed = 0;
            foreach (var c in judge)
            {
                Harshed += (c - '0');
            }
            return x % Harshed == 0 ? Harshed : -1;
        }
    }
}
