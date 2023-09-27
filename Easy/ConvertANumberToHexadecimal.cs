using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class ConvertANumberToHexadecimal
    {
        public string ToHex(int num)
        {
            if (num >= 0)
            {
                return Convert.ToString(num, 16);
            }
            else
            {
                return num.ToString("X8").ToLowerInvariant();
            }
        }
    }
}
