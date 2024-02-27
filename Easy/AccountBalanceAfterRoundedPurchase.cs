using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class AccountBalanceAfterRoundedPurchase
    {
        public int AccountBalanceAfterPurchase(int purchaseAmount)
        {
            int temp = purchaseAmount % 10;
            int Result = 100 - (purchaseAmount - purchaseAmount % 10);
            return temp > 4 ? Result - 10 : Result;
        }
    }
}
