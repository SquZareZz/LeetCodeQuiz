using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class PowerOfThree
    {
        public bool IsPowerOfThree(int n)
        {
            if (n < 1)
            {
                return false;
            }
            else
            {
                int PowOf3 = 0;
                while (PowOf3 > -1)
                {
                    if (n > Math.Pow(3, PowOf3))
                    {
                        PowOf3++;

                    }
                    else if (n == Math.Pow(3, PowOf3))
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
        }
        public bool IsPowerOfThreeFastest(int n)
        {
            //用最簡迴圈和四則運算
            if (n < 1)
            {
                return false;
            }
            else
            {
                while (n > 0)
                {
                    if (n % 3 == 0)
                    {
                        n /= 3;

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
                return true;
            }
        }
    }
}
