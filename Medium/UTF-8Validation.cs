using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class UTF_8Validation
    {
        public bool ValidUtf8Fail(int[] data)
        {
            int digit = 0, Count = 0;
            foreach (var num in data)
            {
                if (digit == 0)
                {
                    foreach (var bit in Convert.ToString(num, 2).PadLeft(8, '0'))
                    {
                        if (bit == '1')
                        {
                            digit++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (digit == 1)
                    {
                        return false;
                    }
                    else if (digit > 1)
                    {
                        digit -= 1;
                        Count = 0;
                    }
                }
                else
                {
                    if (Convert.ToString(num, 2).PadLeft(8, '0').Substring(0, 2) != "10")
                    {
                        return false;
                    }
                    digit--;
                    Count++;
                    if (Count > 3)
                    {
                        return false;
                    }
                }
            }
            return digit == 0;
        }
        public bool ValidUtf8(int[] data)
        {
            int left = 0;
            foreach (var d in data)
            {
                if (left == 0)
                {
                    if ((d >> 3) == 0b11110)
                    {
                        left = 3;
                    }
                    else if ((d >> 4) == 0b1110)
                    {
                        left = 2;
                    }
                    else if ((d >> 5) == 0b110)
                    {
                        left = 1;
                    }
                    else if ((d >> 7) == 0b0)
                    {
                        left = 0;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if ((d >> 6) != 0b10)
                    {
                        return false;
                    }
                    left--;
                }
            }
            return left == 0;
        }
    }
}
