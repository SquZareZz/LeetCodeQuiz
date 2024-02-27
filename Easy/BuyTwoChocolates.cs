using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class BuyTwoChocolates
    {
        public int BuyChoco(int[] prices, int money)
        {
            Array.Sort(prices);
            if (prices[0] > money)
            {
                return money;
            }
            else if (money - prices[0] - prices[1] < 0)
            {
                return money;
            }
            else
            {
                return money - prices[0] - prices[1];
            }
        }
    }
}
