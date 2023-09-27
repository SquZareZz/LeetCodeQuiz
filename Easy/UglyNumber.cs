using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class UglyNumber
    {
        public bool IsUgly(int n)
        {
            string CaseTemp = "";
            if (n == 1)
            {
                return true;
            }
            else if (n == 0)
            {
                return false;
            }
            else
            {
                while (n > 0)
                {
                    if (n % 2 == 0)
                    {
                        CaseTemp = "2";
                    }
                    else if (n % 3 == 0)
                    {
                        CaseTemp = "3";
                    }
                    else if (n % 5 == 0)
                    {
                        CaseTemp = "5";
                    }
                    else
                    {
                        return false;
                    }
                    switch (CaseTemp)
                    {
                        case "2":
                            while (n % 2 == 0)
                            {
                                n = n / 2;
                            }
                            break;
                        case "3":
                            while (n % 3 == 0)
                            {
                                n = n / 3;
                            }
                            break;
                        case "5":
                            while (n % 5 == 0)
                            {
                                n = n / 5;
                            }
                            break;
                    }
                    if (n == 1)
                    {
                        return true;
                    }

                }
                return false;
            }
        }
    }
}
