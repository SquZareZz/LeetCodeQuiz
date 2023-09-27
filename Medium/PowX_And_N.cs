using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class PowX_And_N
    {
        public double MyPowFunWay(double x, int n)
        {
            return Math.Pow(x, n);
        }
        public double MyPowSlowestWay(double x, int n)
        {
            //var a = Math.Pow(x, Int32.MinValue);
            if (x == 1 || x == -1)
            {
                return n % 2 == 1 ? x : x * x;
            }
            double Result = 1;
            switch (n)
            {
                case > 0:
                    while (n > 0)
                    {
                        Result *= x;
                        n--;
                        if (Result > int.MaxValue)
                        {
                            return Result;
                        }
                    }
                    return Result;
                case < 0:
                    while (n < 0)
                    {
                        Result /= x;
                        n++;
                        if (Result < Math.Pow(10, -15))
                        {
                            return 0;
                        }
                    }
                    return Result;
                default:
                    return 1;
            }
        }
        public double MyPow(double x, int n)
        {
            //var a = Math.Pow(x, Int32.MinValue);
            if (x == 1 || x == -1)
            {
                return n % 2 == 1 ? x : x * x;
            }

            double Result = n > 0 ? x : 1 / x;
            int PowerNum = n > 0 ? 1 : -1;
            switch (n)
            {
                case > 0:
                    while (PowerNum < n)
                    {
                        Result *= Result;
                        PowerNum *= 2;
                        if (Result > int.MaxValue / Result)
                        {
                            while (PowerNum < n)
                            {
                                Result *= x;
                                PowerNum++;
                            }
                        }
                        if (Result < Math.Pow(10, -15) / Result)
                        {
                            while (PowerNum < n)
                            {
                                Result *= x;
                                PowerNum++;
                                if (Result < Math.Pow(10, -15) / x)
                                {
                                    return 0;
                                }
                            }
                        }
                    }
                    while (PowerNum > n)
                    {
                        Result /= x;
                        PowerNum--;
                    }
                    return Result;

                case < 0:
                    while (PowerNum > n)
                    {
                        Result *= Result;
                        PowerNum *= 2;
                        if (Result < Math.Pow(10, -15) / Result)
                        {
                            while (PowerNum > n)
                            {
                                Result *= 1 / x;
                                PowerNum--;
                            }
                        }
                        if (Result > int.MaxValue / Result)
                        {
                            while (PowerNum > n)
                            {
                                Result *= 1 / x;
                                PowerNum--;
                                if (Result > int.MaxValue / x)
                                {
                                    return int.MaxValue;
                                }
                            }
                        }
                    }
                    while (PowerNum < n)
                    {
                        Result *= x;
                        PowerNum++;
                    }
                    return Result;
                default:
                    return 1;
            }
        }
        public double MyPow2(double x, int n)
        {
            //利用函數做無窮迴圈
            //先判斷可以直接得到值的可能--
            //冪次為0=>1、冪次為1=>數值本身、冪次為-1=>倒數
            switch (n)
            {
                case 0:
                    return 1;
                case 1:
                    return x;
                case -1:
                    return 1.0 / x;
                default:
                    //接著將原先的n平方拆解成n/2次方
                    double Result = MyPow2(x, n / 2);
                    //如果是奇數次方，那就是累積項的平方*原始項
                    if (n % 2 == 1)
                    {
                        return Result * Result * x;
                    }
                    else if (n % 2 == 0)//如果是偶數次方，那就是累積項的平方
                    {
                        return Result * Result;
                    }
                    else//如果是小數，那就是累積項的平方/原始項
                    {
                        return Result * Result / x;
                    }
            }
            //過大自動回傳Infinity
        }
    }
}
