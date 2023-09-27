using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class FactorialTrailingZeroes
    {
        public int TrailingZeroes(int n)
        {
            //其實要知道有幾個0，只要看數值理具備幾個2和5的倍數
            //但2的倍數一定比5的倍數多，所以只要看5的倍數
            //5的n次方倍會有n個5的因數，因此要加回去
            int Result = 0;
            int Dumpiltcate = 1;
            while(n >= Math.Pow(5, Dumpiltcate))
            {
                Result += (int)(n / Math.Pow(5, Dumpiltcate));
                Dumpiltcate++;
            }
            return Result;
        }
    }
}
