using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class ReverseBits
    {
        public uint reverseBits(uint n)
        {
            //這個不熟
            //新的數值不斷左移+舊的數值&1運算
            uint result = 0;
            for (var i = 0; i < 32; i++)
            {
                result = (result << 1) + (n & 1);
                n = n >> 1;
            }
            return result;
        }
    }
}
