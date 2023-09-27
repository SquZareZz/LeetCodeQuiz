using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class UglyNumberII
    {
        public int NthUglyNumberFail(int n)
        {
            //太慢
            int Count = 1, Result = 1, Start = 2;
            while (Count < n)
            {
                int temp = Start;
                for (int i = 2; i <= 5;)
                {
                    if (temp % i == 0)
                    {
                        temp /= i;
                        continue;
                    }
                    i++;
                }
                if (temp == 1)
                {
                    Result = Start;
                    Count++;
                }
                Start++;
            }
            return Result;
        }
        public int NthUglyNumber(int n)
        {
            var ugly = new int[n + 1];
            ugly[0] = 1;
            int i2 = 0, i3 = 0, i5 = 0;
            for (int i = 1; i < n; i++)
            {
                ugly[i] = new[] { ugly[i2] * 2, ugly[i3] * 3, ugly[i5] * 5 }.Min();
                //原始寫法會比較快=>
                //ugly[i] = Math.Min(Math.Min(ugly[i2] * 2, ugly[i3] * 3), ugly[i5] * 5);
                //把數字推進到下次出現處
                if (ugly[i] == ugly[i2] * 2)
                {
                    i2++;
                }
                if (ugly[i] == ugly[i3] * 3)
                {
                    i3++;
                }
                if (ugly[i] == ugly[i5] * 5)
                {
                    i5++;
                }
            }
            return ugly[n - 1];
        }
    }
}
