using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class CountPrimes
    {
        public int CountPrimesFail(int n)
        {
            //太慢 ： 499979
            int Result = 0;
            for (int i = 2; i < n; i++)
            {
                for (int j = 2; j < i + 1; j++)
                {
                    if (j == i)
                    {
                        Result++;
                    }
                    else if (i % j == 0)
                    {
                        break;
                    }
                }
            }
            return Result;
        }
        public int CountPrimesFail2(int n)
        {
            //太慢 ： 499979
            var PrimeResult = new List<int>();
            bool IsPrime = true;
            for (int i = 2; i < n; i++)
            {
                foreach (var Prime in PrimeResult)
                {
                    if (i % Prime == 0)
                    {
                        IsPrime = false;
                        break;
                    }
                }
                if (IsPrime)
                {
                    PrimeResult.Add(i);
                }
                else
                {
                    IsPrime = true;
                }
            }
            return PrimeResult.Count;
        }
        public int CountPrimes1(int n)
        {
            //用刪去法，先把第一個質數的所有倍數刪掉
            //會比逐個算來得更快
            int Result = 0;
            var IsPrime = new bool[n];
            for(int i=0;i<n;i++)
            {
                IsPrime[i] = !IsPrime[i];
            }
            for (int i = 2; i < n; i++)
            {
                if (IsPrime[i])
                {
                    Result++;
                }
                for(int j = 2; i*j < n; j++)
                {
                    IsPrime[i*j] = false;
                }
            }
            return Result;
        }
        public int CountPrimes2(int n)
        {
            //比起上個方法，配合初值做布林反轉
            int Result = 0;
            var IsPrime = new bool[n];
            for (int i = 2; i < n; i++)
            {
                if (!IsPrime[i])
                {
                    Result++;
                }
                for (int j = 2; i * j < n; j++)
                {
                    IsPrime[i * j] = true;
                }
            }
            return Result;
        }
    }
}
