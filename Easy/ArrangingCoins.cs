using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class ArrangingCoins
    {
        public int ArrangeCoins(int n)
        {
            int j = Convert.ToInt32(Math.Sqrt(n));
            while (j < n)
            {
                double TotalCoin = (j + 1) / 2 * Convert.ToDouble(j);//防止溢位
                if (TotalCoin < n)
                {
                    j++;
                }
                else if (TotalCoin == n)
                {
                    return j;
                }
                else
                {
                    return j - 1;
                }
            }
            return 1;
        }
    }
}
