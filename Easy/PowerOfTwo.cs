using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class PowerOfTwo
    {
        public bool IsPowerOfTwo(int n)
        {
            bool CheckOut = true;
            int i = 0;
            while (CheckOut)
            {
                if (Math.Pow(2, i) == n)
                {
                    return true;
                }
                else if (Math.Pow(2, i) > n)
                {
                    return false;
                }
                i++;
            }
            return false;
        }
    }
}
