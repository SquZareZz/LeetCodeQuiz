using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class PrimeNumberOfSetBitsInBinaryRepresentation
    {
        public int CountPrimeSetBits(int left, int right)
        {
            int Result = 0;
            for (int i = left; i < right + 1; i++)
            {
                if (IsPrime(Convert.ToString(i, 2).Count(x => x == '1')))
                {
                    Result++;
                }
            }
            return Result;
        }
        public bool IsPrime(int ToDetect)
        {
            int Factor = 0;
            if (ToDetect < 2 || ToDetect != 2 && ToDetect % 2 == 0)
            {
                return false;
            }
            for (int i = 1; i < ToDetect + 1; i++)
            {
                if (ToDetect % i == 0)
                {
                    Factor++;
                }
                if (Factor > 2)
                {
                    return false;
                }
            }
            return true;
        }
    }

}
