using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class MagicalString
    {
        int magicalString(int n)
        {
            //
            if (n <= 0) return 0;
            if (n <= 3) return 1;
            int res = 1, head = 2, tail = 3, num = 1;
            var V = new List<int> { 1, 2, 2 };
            while (tail < n)
            {
                for (int i = 0; i < V[head]; i++)
                {
                    V.Add(num);
                    if (num == 1 && tail < n) res++;
                    tail++;
                }
                num ^= 3;
                head++;
            }
            return res;
        }
    }
}
