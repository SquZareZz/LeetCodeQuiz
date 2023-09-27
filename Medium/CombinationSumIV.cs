using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class CombinationSumIV
    {
        public int CombinationSum4Fail(int[] nums, int target)
        {
            //組合爆炸
            var Result = new List<List<int>>();

            for (int i = 0; i < nums.Length; i++)
            {
                var temp = new List<int> { nums[i] };
                if (nums[i] > target)
                {
                    continue;
                }
                Result = FindCombination(Result, temp, nums, target);
            }
            return Result.Count;
        }
        public List<List<int>> FindCombination(List<List<int>> Result, List<int> temp, int[] nums, int target)
        {
            var TempToken = temp.ToList();
            int Total = TempToken.Sum();
            if (Total == target)
            {
                Result.Add(TempToken);
                return Result;
            }
            else if (nums.Where(x => x <= target - Total).Count() == 0)
            {
                return Result;
            }
            for (int i = 0; i < nums.Length; i++)
            {

                if (Total + nums[i] <= target)
                {
                    TempToken.Add(nums[i]);
                    FindCombination(Result, TempToken, nums, target);
                    TempToken.RemoveAt(TempToken.Count() - 1);
                }

            }
            return Result;
        }
        public int CombinationSum4Fail2(int[] nums, int target)
        {
            //組合爆炸
            var Result = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                var temp = new List<int> { nums[i] };
                if (nums[i] > target)
                {
                    continue;
                }
                Result = FindCombination2(Result, temp, nums, target);
            }
            return Result;
        }
        public int FindCombination2(int Result, List<int> temp, int[] nums, int target)
        {
            var TempToken = temp.ToList();
            int Total = TempToken.Sum();
            if (Total == target)
            {
                return Result + 1;
            }
            else if (nums.Where(x => x <= target - Total).Count() == 0)
            {
                return Result;
            }
            for (int i = 0; i < nums.Length; i++)
            {

                if (Total + nums[i] <= target)
                {
                    TempToken.Add(nums[i]);
                    Result = FindCombination2(Result, TempToken, nums, target);
                    TempToken.RemoveAt(TempToken.Count() - 1);
                }

            }
            return Result;
        }
        public int CombinationSum4(int[] nums, int target)
        {
            //把問題拆解成「a+b」的所有組合
            //a=nums[i],b=target-a
            //所以從1的組合推進到 target 值的組合即為答案
            //如果不具備組合不會進判別式、具備組合一定會有一個 = 1 的數值

            var DP = new int[target+1];
            DP[0] = 1;
            for (int i = 1; i <= target; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    if (nums[j] <= i)
                    {
                        DP[i] += DP[i - nums[j]];
                    }
                }
            }
            return DP[target];
        }
    }
}
