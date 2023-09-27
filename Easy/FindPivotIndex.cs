using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class FindPivotIndex
    {
        public int PivotIndexFail(int[] nums)
        {
            //時間消耗太多
            for (int i = 0; i < nums.Length; i++)
            {
                int temp = nums.Take(i).Sum();
                int temp2 = nums.Skip(i + 1).Sum();
                if (temp == temp2)
                {
                    return i;
                }

            }
            return -1;
        }
        public int PivotIndex(int[] nums)
        {
            int Len = nums.Length;
            if (Len == 1)
            {
                return 0;
            }
            int Left = 0, Right = nums.Sum() - nums[0];
            for (int i = 0; i < Len - 1; i++)
            {
                if (Left == Right)
                {
                    return i;
                }
                else
                {
                    Left += nums[i];
                    Right -= nums[i + 1];
                }
            }
            return -1;
        }
    }
}
