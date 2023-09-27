using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class DivideTwoIntegers
    {
        public int Divide(int dividend, int divisor)
        {
            int InputSign = 1;
            int Quotient = 0;
            //如果它負得太大
            if (dividend == int.MaxValue && divisor <= 1 && divisor >= -1)
            {
                return divisor > 0 ? int.MaxValue : int.MinValue + 1;
            }
            else if (dividend == int.MinValue && divisor <= 1 && divisor >= -1)
            {
                return divisor < 0 ? int.MaxValue : int.MinValue;
            }
            else if (dividend == int.MinValue && (divisor > 1 || divisor < -1))
            {
                dividend = -(dividend + 1);
                InputSign = -1;
                Quotient++;
            }

            if (dividend == int.MinValue)
            {
                dividend = -(dividend + 1);
                InputSign = -1;
            }
            if (dividend > 0 && divisor < 0)
            {
                divisor *= -1;
                InputSign = -1;
            }
            else if (dividend < 0 && divisor > 0)
            {
                dividend *= -1;
                InputSign = -1;
            }
            else if (dividend < 0 && divisor < 0)
            {
                dividend *= -1;
                divisor *= -1;
            }
            else if (dividend == 0)
            {
                return dividend;
            }

            while (dividend > -1)
            {
                dividend -= divisor;
                if (Quotient == int.MaxValue)
                {
                    return Quotient;
                }
                Quotient++;
            }
            return (Quotient - 1) * InputSign;

        }
    }
}
