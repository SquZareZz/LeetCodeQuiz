using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class Bulb_Switcher
    {
        public int BulbSwitch(int n)
        {
            //太慢
            bool[] Result = new bool[n];
            for (int i = 0; i < n; i++)
            {
                if (i == n - 1)
                {
                    Result[i] = !Result[i];
                }
                else
                {
                    for (int j = 0; j < n; j++)
                    {
                        if ((j + 1) % (i + 1) == 0)
                        {
                            Result[j] = !Result[j];
                        }
                    }
                }
            }
            return Result.Where(x => x == true).Count();
        }
        public int BulbSwitch2(int n)
        {
            //還是太慢
            var Result = 0;
            for (int i = 1; i < n + 1; i++)
            {
                int temp = 1;
                for (int j = 2; j <= i; j++)
                {
                    if (i % j == 0)
                    {
                        temp++;
                    }
                }
                if (temp % 2 != 0)
                {
                    Result++;
                }
            }
            return Result;
        }
        public int BulbSwitch3(int n)
        {
            //實際上，它問的是「範圍內的完全平方數」
            var Result = 0;
            var i = 1;
            while (i < Convert.ToInt32(Math.Sqrt(n)) + 1)
            {
                Result += Math.Pow(i, 2) <= n ? 1 : 0;
                i++;
            }
            return Result;
        }
        public int BulbSwitch4(int n)
        {
            //實際上，它問的是「範圍內的完全平方數」
            //所以有這個最簡化寫法
            return Math.Sqrt(n) < Convert.ToInt32(Math.Sqrt(n)) ?
                Convert.ToInt32(Math.Sqrt(n)) - 1 : Convert.ToInt32(Math.Sqrt(n));
        }
    }
}
