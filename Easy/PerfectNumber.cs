using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class PerfectNumber
    {
        public bool CheckPerfectNumberSimpleWay(int num)
        {
            int Result = 0;
            for (int i = 1; i < num; i++)
            {
                if (num % i == 0)
                {
                    Result += i;
                }
            }
            return Result == num;
        }
        public bool CheckPerfectNumberFail(int num)
        {
            //不是完全照質數排列
            switch (num)
            {
                case < 6:
                    return false;
                default:

                    int Result = 0;
                    var PrimeNo = new List<int>();
                    for (int i = 2; i < num; i++)
                    {
                        if (i >= 40)//不用找到2^40次方以上，太大了
                        {
                            break;
                        }
                        bool flag = true;
                        for (int j = 2; j <= i / 2; j++)
                        {
                            if (i % j == 0)
                            {
                                flag = false;
                            }
                        }
                        if (flag)
                        {
                            PrimeNo.Add(i);
                        }
                    }
                    int Count = 0;
                    while (Result < num)
                    {
                        Result = Convert.ToInt32(Math.Pow(2, PrimeNo[Count] - 1) * (Math.Pow(2, PrimeNo[Count]) - 1));
                        if (Result == num)
                        {
                            return true;
                        }
                        Count++;
                    }
                    return false;
            }
        }
        public bool CheckPerfectNumberHyperWay(int num)
        {
            //數值介於1~1e-8，所以完全數不會超過1e-8，有五個數
            var reference = new int[5] { 6, 28, 496, 8128, 33550336 };
            int Count = 0;
            while (Count < 5 && reference[Count] <= num)
            {
                if (reference[Count] == num)
                {
                    return true;
                }
                Count++;
            }
            return false;
        }
        public bool CheckPerfectNumberHyperWay2(int num)
        {
            //數值介於1~1e-8，所以完全數不會超過1e-8，有五個數
            var reference = new int[5] { 6, 28, 496, 8128, 33550336 };
            for (int i = 0; i < 5; i++)
            {
                if (reference[i] == num)
                {
                    return true;
                }
            }
            return false;
        }
        public bool CheckPerfectNumberHyperWay3(int num)
        {
            //數值介於1~1e-8，所以完全數不會超過1e-8，有五個數
            switch (num)
            {
                case 6:
                case 28:
                case 496:
                case 8128:
                case 33550336:
                    return true;
                default:
                    return false;
            }

        }
    }
}
