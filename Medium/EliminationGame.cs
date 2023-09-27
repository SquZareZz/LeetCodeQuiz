using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class EliminationGame
    {
        public int LastRemaining(int n)
        {
            //規律是：2倍*(1+ 本項/2 -前一項2^(n-1)項)
            //2^0項=1
            return n == 1 ? 1 : 2 * (1 + n / 2 - LastRemaining(n / 2));
        }
    }
}
