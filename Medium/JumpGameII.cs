using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class JumpGameII
    {
        public int JumpFail(int[] nums)
        {
            int Count = 0;
            if (nums.Length < 2)
            {
                return 0;
            }
            int Len = nums.Length;
            for (int i = 0; i < Len - 1;)
            {
                int temp;
                if (nums[i] >= Len - 1 - i)
                {
                    Count++;
                    break;
                }
                else
                {
                    temp = nums[i];
                }
                int[] temp2 = new int[temp];
                if (i < Len - 1)
                {
                    Array.Copy(nums, i + 1, temp2, 0, temp);
                    i += temp2.Max() > 0 ? Array.LastIndexOf(temp2, temp2.Max()) + 1 : 1;
                }
                else
                {
                    i++;
                }
                Count++;
            }
            return Count;
        }
        public int Jump(int[] nums)
        {
            int Count = 0;
            if (nums.Length < 2)
            {
                return 0;
            }
            int Len = nums.Length;
            int Before = 0; int After = 0;
            int Now = 0;
            //計算走過一步以後，和前幾步可能造成的步伐，選擇最大值做為決策
            while (Now < Len - 1)
            {
                int PossibleNums = Now;
                for (; Before <= PossibleNums; Before++)
                {
                    Now = Math.Max(Now, Before + nums[Before]);
                }
                if (PossibleNums == Now)//當所有步伐為0的時候
                {
                    return -1;
                }
                Count++;
            }
            return Count;
        }
    }
}
