using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class MinimumOperationsToReduceXtoZero
    {
        public int MinOperationsFail(int[] nums, int x)
        {
            //失敗，如果被給出一個超大的目標或陣列，會做不完
            int limit = 0;
            limit = Possible(nums, x, 0, limit);
            return limit != 0 ? limit : -1;
        }
        public int Possible(int[] nums, int x, int ResultTemp, int limit)
        {
            int Len = nums.Length;
            if (x > 0 && nums.Length > 0)
            {
                if (ResultTemp < limit || limit == 0)
                {
                    limit = Possible(nums.Skip(1).ToArray(), x - nums[0], ResultTemp + 1, limit);
                }
                if (ResultTemp < limit || limit == 0)
                {
                    limit = Possible(nums.Take(Len - 1).ToArray(), x - nums[Len - 1], ResultTemp + 1, limit);
                }
            }
            if (x == 0)
            {
                limit = limit == 0 ? ResultTemp : Math.Min(ResultTemp, limit);
            }
            return limit;
        }

        public int MinOperations(int[] nums, int x)
        {
            //解題思路應該是，找出 nums 裡面相加 =x 最長子陣列
            //雖然不確定找頭或尾，但子陣列一定是連續的
            //Left -- SubArray -- Right
            //從正數的話，未走過的 = Right，Left + Right = x = target
            //正數總和 = Left + (nums.Sum - x) 

            // 目標子陣列總和
            int target = nums.Sum();
            int len = nums.Length;
            //剛好相等的情況
            if (target == x) return len;
            target -= x;
            //初始化，
            var map = new Dictionary<int, int>() { { 0, -1 } };            
            int LeftTotalSteps = int.MinValue;
            int sum = 0;
            for (int i = 0; i < len; i++)
            {
                sum += nums[i];
                //如果當前掃過的 >= 目標子陣列，找找看移除掉子陣列以後，是否有紀錄對應程度的值
                //如果 >，代表左邊需要被動
                //如果 =，代表只需要動右邊，到定點 = 找到答案
                if (map.ContainsKey(sum - target))
                {
                    LeftTotalSteps = Math.Max(LeftTotalSteps, i - map[sum - target]);
                }
                //記錄每一段落到 Dict，一定是從最左開始動，所以用累加的結果 .Sum()
                map.Add(sum, i);
            }
            return LeftTotalSteps == int.MinValue ? -1 : len - LeftTotalSteps;
        }
    }
}