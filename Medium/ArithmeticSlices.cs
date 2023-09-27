using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace QuizSolution.Medium
{
    public class ArithmeticSlices
    {
        public int NumberOfArithmeticSlices(int[] nums)
        {
            if (nums.Length < 3)
            {
                return 0;
            }
            int Result = 0,  Len = nums.Length;
            for (int i = 0; i < Len - 2; i++)
            {
                int TempFact = 2, Gap = nums[i + 1] - nums[i];
                for (int j = i + 1; j < Len - 1; j++)
                {
                    if (Gap == nums[j + 1] - nums[j] && Gap != 0)
                    {
                        TempFact++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (TempFact >= 3)
                {
                    for (int j = 1; j < TempFact - 1; j++)
                    {
                        Result += j;
                    }
                    i += TempFact - 2;
                }
            }
            return Result;
        }
    }
}
