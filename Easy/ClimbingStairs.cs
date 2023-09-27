using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class ClimbingStairs
    {
        public int ClimbStairsFail(int n)
        {
            //x+2y=n and x的組合不超過n/2種
            //x!/x!*y! ;x+2y=n
            //常規作法，有溢位風險
            if (n <= 1)
            {
                return 1;
            }
            else
            {
                long result = 0;
                int CombinationCount = n / 2;
                for (int i = 0; i < CombinationCount + 1; i++)
                {
                    result += CountOrder(n - i) / (CountOrder(n - 2 * i) * CountOrder(i));
                }
                return Convert.ToInt32(result);
            }
        }
        public int ClimbStairsFail2(int n)
        {
            //x+2y=n and x的組合不超過n/2種
            //x!/x!*y! ;x+2y=n
            //常規作法，有溢位風險
            if (n <= 1)
            {
                return 1;
            }
            else
            {
                long result = 0;
                int CombinationCount = n / 2;
                for (int i = 0; i < CombinationCount + 1; i++)
                {
                    result += CountReductionOrder(n - i, n - 2 * i) / CountOrder(i);
                }
                return Convert.ToInt32(result);
            }
        }
        public long CountOrder(int num)
        {
            if (num == 0)
            {
                return 1;
            }
            else
            {
                long total = 1;
                for (int i = num; i > 0; i--)
                {
                    total = total * i;
                }
                return total;
            }
        }
        public long CountReductionOrder(int num, int halfNum)
        {
            if (num == 0)
            {
                return 1;
            }
            else
            {
                long total = 1;
                for (long i = num; i > halfNum; i--)
                {
                    total = total * i;
                }
                return total;
            }
        }

        public int ClimbStairs(int n)
        {
            //費式數列
            if (n <= 1)
            {
                return 1;
            }
            else if (n == 2)
            {
                return 2;
            }
            else
            {
                int result = 3;
                int before = 2;
                for (int i = 4; i < n + 1; i++)
                {
                    int temp = result;
                    result = result + before;
                    before = temp;
                }
                return result;
            }
        }
    }
}
