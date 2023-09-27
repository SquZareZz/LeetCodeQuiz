using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class PlusOne
    {
        public int[] PlusOneLastMemory(int[] digits)
        {
            for (int i = digits.Length - 1; i > -1; i--)
            {
                if (digits[i] < 9)
                {
                    digits[i]++;
                    return digits;
                }
                else
                {
                    digits[i] = 0;
                    continue;
                }
            }
            var digitsTemp = new int[digits.Length + 1];
            digitsTemp[0] = 1;
            for (int i = 1; i < digits.Length + 1; i++)
            {
                digitsTemp[i] = digits[i - 1];
            }
            return digitsTemp;
        }
        public int[] PlusOneFast(int[] digits)
        {
            int TarLen = digits.Length;
            for (int i = TarLen - 1; i > -1; i--)
            {
                if (digits[i] < 9)
                {
                    digits[i]++;
                    return digits;
                }
                else
                {
                    digits[i] = 0;
                    continue;
                }
            }
            var digitsTemp = new int[TarLen + 1];
            digitsTemp[0] = 1;
            for (int i = 1; i < TarLen + 1; i++)
            {
                digitsTemp[i] = digits[i - 1];
            }
            return digitsTemp;
        }
    }
}
