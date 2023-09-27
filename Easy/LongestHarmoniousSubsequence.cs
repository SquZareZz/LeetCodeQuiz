using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class LongestHarmoniousSubsequence
    {
        public int FindLHS(int[] nums)
        {
            Array.Sort(nums);
            int Lens = nums.Length, Result = 0;
            for (int i = 0; i < Lens; i++)
            {
                int FirstTemp = nums[i], CountTemp = 0;
                if (Result > Lens - i)
                {
                    return Result;
                }
                while (true)
                {
                    if (i + CountTemp == Lens)
                    {
                        if (nums[i - 1 + CountTemp] == FirstTemp + 1 && Result < CountTemp)
                        {
                            Result = CountTemp;
                        }
                        break;
                    }
                    if (nums[i + CountTemp] == FirstTemp || nums[i + CountTemp] - 1 == FirstTemp)
                    {
                        CountTemp++;
                    }
                    else
                    {
                        if (nums[i - 1 + CountTemp] == FirstTemp + 1 && Result < CountTemp)
                        {
                            Result = CountTemp;
                        }
                        break;
                    }
                }
            }
            return Result;
        }
    }
}
