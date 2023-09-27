using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class CountingBits
    {
        public int[] CountBitsSlowest(int n)
        {
            //n*log(n)
            int[] Result = new int[n + 1];
            for (int i = 0; i < n + 1; i++)
            {
                int TarTemp = i;
                int j = 1;
                int ToTrans = 0;
                while (TarTemp > 0)
                {
                    if (TarTemp == 1)
                    {
                        ToTrans++;
                        break;
                    }
                    var TarTemp2 = Convert.ToInt32(Math.Pow(2, j));
                    if (TarTemp / TarTemp2 > 0 && TarTemp != TarTemp2)
                    {
                        j++;
                    }
                    else
                    {
                        j--;
                        TarTemp2 = Convert.ToInt32(Math.Pow(2, j));
                        if (TarTemp >= TarTemp2)
                        {
                            TarTemp -= TarTemp2;
                            ToTrans++;
                        }
                    }
                }
                Result[i] = ToTrans;
            }
            return Result;

        }
        public int[] CountBitsFail(int n)
        {
            int[] Result = new int[n + 1];
            int[] type1 = { 1, 2, 2, 3 };
            int[] type2 = { 2, 3, 3, 4 };
            int[] type3 = { 1, 1, 2, 1 };
            for (int i = 0; i < n + 1; i++)
            {
                int Judge = i % 4;
                if (i == 0)
                {
                    Result[i] = 0;
                    continue;
                }
                int Judge2 = i / 4 % 4;
                switch (Judge)
                {

                    case 0:
                        switch (Judge2)
                        {
                            case 0:
                                Result[i] = type3[3];
                                break;
                            case 3:
                                Result[i] = i / 16 + type3[2];
                                break;
                            default:
                                Result[i] = i / 16 + type3[1];
                                break;
                        }
                        break;
                    case 3:
                        Result[i] = i / 16 + type2[Judge2];
                        break;
                    default:
                        Result[i] = i / 16 + type1[Judge2];
                        break;
                }
            }
            return Result;
        }
        public int[] CountBitsFail2(int n)
        {
            int[] Result = new int[n + 1];
            int[] type1 = { 1, 2, 2, 3 };
            int[] type2 = { 2, 3, 3, 4 };
            int[] type3 = { 1, 1, 2, 1 };
            for (int i = 0; i < n + 1; i++)
            {
                int Judge = i % 4;
                if (i == 0)
                {
                    Result[i] = 0;
                    continue;
                }
                int Judge2 = i / 4 % 4;
                int j = 1;
                switch (Judge)
                {
                    //16>48>48+48
                    case 0:
                        while (i > 16 * (1 + j) * j / 2)
                        {
                            j++;
                        }
                        switch (Judge2)
                        {
                            case 0:
                                Result[i] = i / 16 - Convert.ToInt32(Math.Pow(2, j - 1)) + type3[3];
                                break;
                            case 3:
                                Result[i] = j - 1 + type3[2];
                                break;
                            default:
                                Result[i] = j - 1 + type3[1];
                                break;
                        }
                        break;
                    case 3:
                        while (i > 16 * (1 + j) * j / 2)
                        {
                            j++;
                        }
                        Result[i] = j - 1 + type2[Judge2];
                        break;
                    default:
                        while (i > 16 * (1 + j) * j / 2)
                        {
                            j++;
                        }
                        Result[i] = j - 1 + type1[Judge2];
                        break;
                }
            }
            return Result;
        }
        public int[] CountBitsFastest(int n)
        {
            int[] Result = new int[n + 1];
            if (n == 0)
            {
                Result[0] = 0;
            }
            else if (n == 1)
            {
                Result[1] = 1;
            }
            else
            {
                Result[0] = 0;
                Result[1] = 1;
            }
            for (int i = 2; i < n + 1; i++)
            {
                Result[i] = Result[i / 2] + Result[i % 2];
            }
            return Result;
        }
    }
}
