using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class PowerOfFour
    {
        public bool IsPowerOfFour(int n)
        {
            int PowOf4 = 0;
            //if (n % 4 != 0&& n!=1)
            //{
            //    return false;
            //}
            while (n > 0)
            {

                if (n > Math.Pow(4, PowOf4))
                {
                    PowOf4++;
                }
                else if (n == Math.Pow(4, PowOf4))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public bool IsPowerOfFourFail(int n)
        {
            if (n > 0 && n % 4 == 0)
            {
                return true;
            }
            else if (n == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsPowerOfFour2(int n)
        {
            while (n > 0)
            {
                if (n == 1)
                {
                    return true;
                }
                if (n % 4 != 0)
                {
                    return false;
                }
                else
                {
                    n /= 4;
                }
            }
            return false;
        }
    }
}
