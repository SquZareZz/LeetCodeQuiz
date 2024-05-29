using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class TargetSum
    {
        int Result = 0;
        //堆疊結構
        public int FindTargetSumWays(int[] nums, int target)
        {
            if (nums.Length == 1) return (nums[0] == target || nums[0] == -target) ? 1 : 0;
            //從正值開始
            FindResult(1, nums, target, -1, 0);
            //從負值開始
            FindResult(-1, nums, target, -1, 0);
            return Result;
        }
        public void FindResult(int AddOrNot, int[] nums, int target, int NowLocate, int Total)
        {
            NowLocate++;
            Total += AddOrNot * nums[NowLocate];
            if (NowLocate < nums.Length - 1)
            {
                FindResult(1, nums, target, NowLocate, Total);
                FindResult(-1, nums, target, NowLocate, Total);
            }
            else
            {
                Result += Total == target ? 1 : 0;
            }
        }
    }
}
