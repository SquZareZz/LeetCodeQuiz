using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class ConstructTheRectangle
    {
        public int[] ConstructRectangleFail(int area)
        {
            int[] Result = new int[2];
            var PrimeNums = new List<int>();
            int temp = area;
            for (int i = 2; i <= area; i++)
            {
                if (temp % i == 0)
                {
                    temp = temp / i;
                    PrimeNums.Add(i);
                    i--;  //防止有多個能被相同數整除的情況
                }
                else if (temp == 1)
                {
                    break;
                }
            }
            Result[0] = PrimeNums[0];
            Result[1] = PrimeNums.Count > 1 ? PrimeNums[1] : 1;
            for (int i = PrimeNums.Count - 1; i > 1; i--)
            {
                if (Result[0] * PrimeNums[i] < Result[1] * PrimeNums[i])
                {
                    Result[0] *= PrimeNums[i];
                }
                else
                {
                    Result[1] *= PrimeNums[i];
                }
            }
            return Result;
        }
        public int[] ConstructRectangle(int area)
        {
            int temp = Convert.ToInt32(Math.Sqrt(area));
            while (true)
            {
                if (area % temp == 0)
                {
                    return new int[2] { area / temp, temp };
                }
                else
                {
                    temp--;
                }
            }
        }
    }
}
