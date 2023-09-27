using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class LongestContinuousIncreasingSubsequence
    {
        public int FindLengthOfLCIS(int[] nums)
        {
            if (nums.Length == 1)
            {
                return 1;
            }
            int Result = 1;
            int Diff = nums[1] - nums[0];
            int Before = nums[1];
            int temp = Diff > 0 ? 2 : 1;
            for (int i = 2; i < nums.Length; i++)
            {
                if (nums[i] - Before < 1)
                {
                    if (temp > Result)
                    {
                        Result = temp;
                    }
                    Diff = nums[i] - Before;
                    temp = Diff > 0 ? 2 : 1;
                    Before = nums[i];
                }
                else
                {
                    Diff = nums[i] - Before;
                    Before = nums[i];
                    temp++;
                }
            }
            return temp > Result ? temp : Result;
        }
        public int FindLengthOfLCIS2(int[] nums)
        {
            int Result = 1;
            int Before = nums[0];
            int temp = 1;
            for (int i = 1; i < nums.Length; i++)
            {

                if (nums[i] - Before < 1)
                {
                    if (temp > Result)
                    {
                        Result = temp;
                    }
                    temp = 1;
                    Before = nums[i];
                }
                else
                {
                    Before = nums[i];
                    temp++;
                }
            }
            return temp > Result ? temp : Result;
        }
        public int FindLengthOfLCIS3(int[] nums)
        {
            int Result = 1;
            int Before = nums[0];
            int temp = 1;
            int Len = nums.Length;
            for (int i = 1; i < Len; i++)
            {
                if (nums[i] - Before < 1)
                {
                    if (temp > Len - i)
                    {
                        break;
                    }
                    if (temp > Result)
                    {
                        Result = temp;
                    }
                    temp = 1;
                    Before = nums[i];
                }
                else
                {
                    Before = nums[i];
                    temp++;
                }
            }
            return temp > Result ? temp : Result;
        }
    }
}
