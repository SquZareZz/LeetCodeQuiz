using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class _1_bitAnd2_bitCharacters
    {
        public bool IsOneBitCharacter(int[] bits)
        {
            int Len = bits.Length;
            for (int i = 0; i < Len; i++)
            {
                if (i == Len - 2)
                {
                    return bits[i] != 1;
                }
                if (bits[i] == 0)
                {
                    continue;
                }
                else
                {
                    i++;
                }
            }
            return true;
        }
    }
}
