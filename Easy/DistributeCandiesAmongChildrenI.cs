using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class DistributeCandiesAmongChildrenI
    {
        public int DistributeCandies(int n, int limit)
        {
            FileStream streamDestination = File.OpenRead(@"D:\GDFileTemp\test.csv");
            //排容原理
            //|A∪B∪C|=|A|+|B|+|C|-|A∩B|-|A∩C|-|B∩C|+|A∩B∩C|            
            int Res = 0;
            int TwoPair = 0;
            int ThreePair = 0;
            for (int i = 0; i <= limit; i++)
            {
                if (i <= n && (n - i) <= limit * 2)
                {
                    Res++;
                }
            }
            for (int i = 0; i <= limit; i++)
            {
                if (2 * i <= n && n - 2 * i <= limit && n - 2 * i != i)
                {
                    TwoPair++;
                }
            }
            for (int i = 0; i < limit; i++)
            {
                if (n == 3 * i && i < limit)
                {
                    ThreePair++;
                }
            }
            return 3 * Res - 3 * TwoPair + ThreePair;
        }
    }
}
