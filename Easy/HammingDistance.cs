using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class HammingDistance
    {
        public int HammingDistance1(int x, int y)
        {
            string xStr = Convert.ToString(x, 2).PadLeft(32, '0');
            string yStr = Convert.ToString(y, 2).PadLeft(32, '0');
            int Result = 0;
            for (int i = 0; i < xStr.Length; i++)
            {
                if (xStr[i] != yStr[i])
                {
                    Result++;
                }
            }
            return Result;
        }
        public int HammingDistance2(int x, int y)
        {
            string xStr = Convert.ToString(x, 2);
            string yStr = Convert.ToString(y, 2);
            int BasedOnWho;//少補幾顆零
            if (x > y)
            {
                BasedOnWho = xStr.Length;
            }
            else
            {
                BasedOnWho = yStr.Length;
            }
            xStr = xStr.PadLeft(BasedOnWho, '0');
            yStr = yStr.PadLeft(BasedOnWho, '0');
            int Result = 0;
            for (int i = 0; i < xStr.Length; i++)
            {
                if (xStr[i] != yStr[i])
                {
                    Result++;
                }
            }
            return Result;
        }
    }
}
