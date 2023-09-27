using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class IntegerBreak
    {
        public int IntegerBreakFail(int n)
        {
            int TarSqrt = (int)Math.Sqrt(n);
            int Result = 1, TempN = n;
            var Candidates = new List<int>();
            while (TempN > 0)
            {
                if (Candidates.Count < 2 && (n == 2 || n == 3))
                {
                    Candidates.Add(n - 1);
                    Candidates.Add(1);
                    break;
                }
                else if (TempN - TarSqrt < TarSqrt)
                {
                    Candidates.Add(TempN);
                    break;
                }
                else
                {
                    Candidates.Add(TarSqrt);
                    TempN -= TarSqrt;
                }
            }
            foreach (int i in Candidates)
            {
                Result *= i;
            }
            return Result;
        }
        public int IntegerBreak1(int n)
        {
            //2和3是一種特例，只會是回傳它自己-1
            //1*1、2*1
            if (n == 2 || n == 3)
            {
                return n - 1;
            }
               
            if (n % 3 == 0)
            {
                //3的倍數是一種特例，最大解是3的n次方
                return (int)Math.Pow(3, n / 3);
            }
            else if (n % 3 == 1)
            {
                //3的倍數+1是一種特例，要把其中一個拆成4，剩下用3的n次方
                return 4 * (int)Math.Pow(3, (n - 4) / 3);
            }
            else
            {
                //3的倍數+2是一種特例，一個2拆出來，其餘盡量往3的n次方湊
                return 2 * (int)Math.Pow(3, (n - 2) / 3);
            }
                
        }
    }
}
