using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class SetMismatch
    {
        public int[] FindErrorNumsFail(int[] nums)
        {
            int i = 1;
            foreach (int num in nums)
            {
                if (num != i)
                {
                    return i - 1 == num ? new int[] { num, num + 1 } : new int[] { num, num - 1 };
                }
                i++;
            }
            return null;
        }
        public int[] FindErrorNums(int[] nums)
        {
            int[] Result = new int[2];
            int Len = nums.Length;
            var NumDict = new Dictionary<int, int>();
            for (int i = 0; i < Len; i++)
            {
                if (!NumDict.ContainsKey(nums[i]))
                {
                    NumDict.Add(nums[i], 1);
                }
                else
                {
                    Result[0] = nums[i];
                }
            }
            for (int i = 1; i < Len + 1; i++)
            {
                if (!NumDict.ContainsKey(i))
                {
                    Result[1] = i;
                    return Result;
                }
            }
            return Result;
        }
        public int[] FindErrorNumsFail2(int[] nums)
        {
            int[] Result = new int[2];
            int Len = nums.Length;
            var NumDict = new Dictionary<int, int>();
            for (int i = 0; i < Len; i++)
            {
                if (!NumDict.ContainsKey(nums[i]))
                {
                    NumDict.Add(nums[i], 1);
                }
                else
                {
                    Result[0] = nums[i];
                    if (nums[0] == nums[1])
                    {
                        return nums[0] == 1 ? new int[] { 1, 2 } : new int[] { 2, 1 };
                    }
                    else
                    {
                        for (int j = i; j > 0; j--)
                        {
                            if (!NumDict.ContainsKey(j))
                            {
                                Result[1] = j;
                                return Result;
                            }
                        }
                        Result[1] = nums[i] + 1;
                        return Result;
                    }
                }
            }
            return Result;
        }
    }
}
