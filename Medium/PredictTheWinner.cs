using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class PredictTheWinner
    {
        public bool PredictTheWinnerFail(int[] nums)
        {
            //沒有DP
            var ScoreTable = new int[2];
            bool P1Turn = true;
            while (nums.Length > 1)
            {
                if (nums[0] > nums[nums.Length - 1])
                {
                    if (P1Turn)
                    {
                        ScoreTable[0] += nums[0];
                    }
                    else
                    {
                        ScoreTable[1] += nums[0];
                    }
                    nums = nums.Skip(1).ToArray();
                    P1Turn = !P1Turn;
                }
                else
                {
                    if (P1Turn)
                    {
                        ScoreTable[0] += nums[nums.Length - 1];
                    }
                    else
                    {
                        ScoreTable[1] += nums[nums.Length - 1];
                    }
                    nums = nums.Take(nums.Length - 1).ToArray();
                    P1Turn = !P1Turn;
                }
            }
            return ScoreTable[0] > ScoreTable[1];
        }
        public bool PredictTheWinner1(int[] nums)
        {
            return CanWin(nums, 0, 0, true);
        }
        public bool CanWin(int[] nums, int sum1, int sum2, bool P1)
        {
            int Len = nums.Length;
            //如果沒了，直接判定大小
            if (Len < 1)
            {
                return sum1 > sum2;
            }
            //如果只剩一個值，有幾種可能
            //兩個值相等 => 看最後拿的是誰，所以要看現在輪到誰，如果只有一個0值，P1會勝利，所以>=
            //輪到 P1 => P1 有得加
            //輪到 P2 => P2 有得加
            else if (Len == 1)
            {
                return P1 ? sum1 + nums[0] >= sum2 : sum1 > sum2 + nums[0];
            }
            //需要動態規劃的，是當前List(nums)去掉頭或去掉尾是否會贏
            //如果下一次的判斷，下一家兩種狀況都不會贏的話，那可以確定上一家會贏了
            if (P1)
            {
                //只是 TF 可以省一個參數
                return !CanWin(nums.Skip(1).ToArray(), sum1 + nums[0], sum2, false) ||
                    !CanWin(nums.Take(Len - 1).ToArray(), sum1 + nums[Len - 1], sum2, false);
            }
            else
            {
                //只是 TF 可以省一個參數
                return !CanWin(nums.Skip(1).ToArray(), sum1, sum2 + nums[0], true) ||
                    !CanWin(nums.Take(Len - 1).ToArray(), sum1, sum2 + nums[Len - 1], true);
            }
        }
    }
}
