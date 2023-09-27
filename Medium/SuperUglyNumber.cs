using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class SuperUglyNumber
    {
        public int NthSuperUglyNumber(int n, int[] primes)
        {
            var ugly = new int[n + 1];
            ugly[0] = 1;
            var PointerList = new int[primes.Length];
            for (int i = 1; i < n; i++)
            {
                ulong LowestNum=0;//避免溢位
                LowestNum = (ulong)(primes[0] * ugly[PointerList[0]]);
                for (int j = 1; j < primes.Length; j++)
                {
                    LowestNum = Math.Min(LowestNum, (ulong)(primes[j] * ugly[PointerList[j]]));
                }
                ugly[i] = Convert.ToInt32(LowestNum);
                for(int j = 0; j < PointerList.Length; j++)
                {
                    if(ugly[i]== primes[j] * ugly[PointerList[j]])
                    {
                        PointerList[j]++;
                    }
                }
            }
            return ugly[n - 1];
        }
    }
}
