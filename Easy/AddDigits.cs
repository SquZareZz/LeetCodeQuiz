using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class AddDigits
    {
        public int AddDigits1(int num)
        {
            while (num > 0)
            {
                string TarTemp = num.ToString();
                int TarLen = TarTemp.Length;
                if (TarLen < 2)
                {
                    return num;
                }
                else
                {
                    num = 0;
                    for (int i = 0; i < TarLen; i++)
                    {
                        num += TarTemp[i] - '0';
                    }
                }
            }
            return num;
        }
    }
}
