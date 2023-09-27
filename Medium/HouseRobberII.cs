using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class HouseRobberII
    {
        public int Rob(int[] nums)
        {
            int Len = nums.Length;
            var Wallet = new int[Len];
            bool Start;
            for (int i = 0; i < Len; i++)
            {
                Wallet[i] = nums[i];
                Start = true;
                int Target = i + 2;
                if (Target> Len - 1)
                {
                    Target = Target - Len;
                    Start = false;
                }
                var Stop = new List<int>() { i };
                if (i - 1 < 0)//最左
                {
                    Stop.Add(i + 1);
                    Stop.Add(Len - 1);
                }
                else if (i + 1 == Len)//最右
                {
                    Stop.Add(i - 1);
                    Stop.Add(0);
                }
                else//通常
                {
                    Stop.Add(i - 1);
                    Stop.Add(i + 1);
                }
                while (!(!Start&&(Target > i || Target == i)))
                {
                    if (Stop.Contains(Target))
                    {
                        break;
                    }
                    Wallet[i] += nums[Target];
                    if (Target + 2 > Len - 1)
                    {
                        Target = Target + 2 - Len;
                        Start = false;
                    }
                    else
                    {
                        Target += 2;
                    }
                }
            }
            return Wallet.Max();
        }
        public int Rob2(int[] nums)
        {
            if (nums.Length <= 1) return nums.Length==0 ? 0 : nums[0];
            //搶到第一家和最後一家會有迴圈狀的問題，所以先把第一家和最後一家分開獨立來看
            //因為是跳過其中一家，所以DP只考慮兩間房子的貪婪法
            //如果搶第一間=不搶最後一間;搶到最後一間=不搶第一間
            //共通都要決定是否搶中間的，所以用有搶第一間和有搶最後一間的選擇
            //兩種用個Max做比較
            return Math.Max(RogueTime(nums, 0, nums.Length - 1), RogueTime(nums, 1, nums.Length));
        }
        public int RogueTime(int[] nums, int left, int right)
        {
            int ThisChoice = 0, LastChoice = 0;
            for (int i = left; i < right; i++)
            {
                int preRob = ThisChoice, preNotRob = LastChoice;
                ThisChoice = preNotRob + nums[i];
                LastChoice = Math.Max(preRob, preNotRob);
            }
            return Math.Max(ThisChoice, LastChoice);
        }
    }
}
