using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class MaximumSubarray
    {
        //要記錄兩個數：現在的數與累加數
        //如果現在的數比累加數大，那更新結果(可能累加/沒加)
        //如果現在出現的數小於0，那把現在的數當新的起點
        public int MaxSubArray(int[] nums)
        {
            int Len = nums.Length;
            if (Len == 0)
            {
                return 0;
            }
            int Result = nums[0], now = nums[0];
            for (int i = 1; i < Len; i++)
            {
                if (now > 0)
                {
                    now += nums[i];
                }
                else
                {
                    now = nums[i];
                }
                if (now > Result)
                {
                    Result = now;
                }
            }
            return Result;
        }
        public int MaxSubArray2(int[] nums)
        {
            int Result = nums[0], now = Result;
            nums = nums.Skip(1).ToArray();
            foreach (int num in nums)
            {
                if (now > 0)
                {
                    now += num;
                }
                else
                {
                    now = num;
                }
                if (now > Result)
                {
                    Result = now;
                }
            }
            return Result;
        }
    }
}
