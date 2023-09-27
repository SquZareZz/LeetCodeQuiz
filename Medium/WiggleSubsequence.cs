using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class WiggleSubsequence
    {
        public int WiggleMaxLengthFail(int[] nums)
        {
            int Result = 0;
            for (int i = 0; i < nums.Length - 1;)
            {
                if (Result >= nums.Length - i)
                {
                    break;
                }
                int Last = nums[i + 1];
                int temp = nums[i + 1] - nums[i];
                int tempResult = 2;
                foreach (var num in nums.Skip(i + 2))
                {
                    if (temp > 0)
                    {
                        if (num - Last >= 0)
                        {
                            break;
                        }
                        temp = num - Last;
                        Last = num;
                        tempResult++;
                    }
                    else if (temp < 0)
                    {
                        if (num - Last <= 0)
                        {
                            break;
                        }
                        temp = num - Last;
                        Last = num;
                        tempResult++;
                    }
                    else
                    {
                        break;
                    }
                }
                Result = Math.Max(Result, tempResult);
                i += tempResult - 1;
            }
            return Result;
        }
        public int WiggleMaxLength(int[] nums)
        {
            int Len = nums.Length;
            int[] DP = new int[Len];
            var judge = new List<int> { nums[0] };
            foreach (var num in nums.Skip(1))
            {
                if (num != judge.Last())
                {
                    judge.Add(num);
                }
            }
            if (judge.Count < 2)
            {
                return 1;
            }
            int FirstGap = judge[judge.Count - 1] - judge[judge.Count - 2];
            DP[1] = FirstGap == 0 ? 1 : 2;
            bool PositiveCK, LastCK = FirstGap > 0;
            for (int i = 2; i < Len; i++)
            {
                int temp = nums[Len - i] - nums[Len - i - 1];
                if (temp == 0)
                {
                    DP[i] = DP[i - 1];
                }
                else
                {
                    PositiveCK = temp > 0;
                    if (PositiveCK != LastCK)
                    {
                        LastCK = PositiveCK;
                        DP[i] = DP[i - 1] + 1;
                    }
                    else
                    {
                        DP[i] = DP[i - 1];
                    }
                }
            }
            return DP.Last();
        }
        public int WiggleMaxLength2(int[] nums)
        {
            var judge = new List<int> { nums[0] };
            foreach (var num in nums.Skip(1))
            {
                if (num != judge.Last())
                {
                    judge.Add(num);
                }
            }
            if (judge.Count < 2)
            {
                return 1;
            }
            int[] DP = new int[judge.Count];
            int Len = judge.Count;
            int FirstGap = judge[judge.Count - 1] - judge[judge.Count - 2];
            DP[1] = FirstGap == 0 ? 1 : 2;
            bool PositiveCK, LastCK = FirstGap > 0;
            for (int i = 2; i < Len; i++)
            {
                int temp = judge[Len - i] - judge[Len - i - 1];
                if (temp == 0)
                {
                    DP[i] = DP[i - 1];
                }
                else
                {
                    PositiveCK = temp > 0;
                    if (PositiveCK != LastCK)
                    {
                        LastCK = PositiveCK;
                        DP[i] = DP[i - 1] + 1;
                    }
                    else
                    {
                        DP[i] = DP[i - 1];
                    }
                }
            }
            return DP.Last();
        }
    }
}
