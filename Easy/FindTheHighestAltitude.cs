using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class FindTheHighestAltitude
    {
        public int LargestAltitude(int[] gain)
        {
            int Result = 0, temp = 0;
            foreach (int i in gain)
            {
                temp += i;
                Result = Result > temp ? Result : temp;
            }
            return Result;
        }
    }
}
