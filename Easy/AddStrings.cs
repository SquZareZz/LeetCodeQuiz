using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class AddStrings
    {
        public string AddStringsFail(string num1, string num2)
        {
            string Result = "";
            char ToAdd = '\0';
            int TarLen1 = num1.Length;
            int TarLen2 = num2.Length;
            bool TwoOrOne;
            int BasedLen;
            if (TarLen2 > TarLen1)
            {
                BasedLen = TarLen1;
                TwoOrOne = false;
            }
            else
            {
                BasedLen = TarLen2;
                TwoOrOne = true;
            }
            if (TwoOrOne)
            {
                for (int i = BasedLen - 1; i > -1; i--)
                {
                    int Total = num1[i] + num2[i] + ToAdd - 96;
                    if (Total > 10)
                    {
                        ToAdd = (char)(Total - 10);
                        Total -= 10;
                    }
                    Result += Total.ToString();
                }
                for (int i = 0; i > TarLen1 - BasedLen; i++)
                {
                    Result += num1[i].ToString();
                }
            }
            else
            {
                for (int i = TarLen2 - 1; i > BasedLen - 1; i--)
                {
                    int Total = num1[i] + num2[i] + ToAdd - 96;
                    if (Total > 10)
                    {
                        ToAdd = (char)(Total - 10);
                        Total -= 10;
                    }
                    Result += Total.ToString();
                }
                for (int i = 0; i > TarLen2 - BasedLen; i++)
                {
                    Result += num2[i].ToString();
                }
            }
            return Result;
        }
        public string AddStrings1(string num1, string num2)
        {
            string Result = "";
            char ToAdd = '0';
            int i, j;
            for (i = num1.Length - 1, j = num2.Length - 1; i > -1 || j > -1; i--, j--)
            {
                int Total = 0;
                int nums = 1;
                if (i > -1)
                {
                    nums++;
                    Total += num1[i];
                }
                if (j > -1)
                {
                    Total += num2[j];
                    nums++;
                }
                Total += ToAdd - 48 * nums;
                switch (Total)
                {
                    case >= 10:
                        ToAdd = '1';
                        Total -= 10;
                        break;
                    default:
                        ToAdd = '0';
                        break;
                }
                Result = Total.ToString() + Result;
            }
            if (ToAdd != '0')
            {
                Result = ToAdd.ToString() + Result;
            }
            return Result;
        }
    }
}
