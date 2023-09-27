using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class IntegerReplacement
    {
        public int IntegerReplacement1(int n)
        {
            int Times = 0;
            if (n == Int32.MaxValue)
            {
                n /= 2;
                Times = 1;
            }
            while (n > 1)
            {
                //商如果是2^n倍，+1(除了3的情況)
                //其他情況都用減的
                switch (n % 2)
                {
                    case 0:
                        n /= 2;
                        break;
                    case 1:
                        if ((n + 1) / 2 % 2 == 0 && (n - 1) / 2 == 1)
                        {
                            n--;
                        }
                        else if((n + 1) / 2 % 2 == 0)
                        {
                            n++;
                        }
                        else
                        {
                            n--;
                        }
                        break;
                }
                Times++;
            }
            return Times;
        }
        public int IntegerReplacement2(int n)
        {
            int Times = 0;
            if (n == Int32.MaxValue)
            {
                n /= 2;
                Times++;
            }
            while (n > 1)
            {
                //商如果是2^n倍，+1(除了3的情況)
                //其他情況都用減的
                switch (n % 2)
                {
                    case 0:
                        n /= 2;
                        break;
                    case 1:
                        if ((n + 1) / 2 % 2 == 0 && (n - 1) / 2 == 1)
                        {
                            //捨棄餘數動作，所以補一個++
                            n /= 2;
                            Times++;
                        }
                        else if ((n + 1) / 2 % 2 == 0)
                        {
                            n++;
                        }
                        else
                        {
                            n /= 2;
                            Times++;
                        }
                        break;
                }
                Times++;
            }
            return Times;
        }
    }
}
