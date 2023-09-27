using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class WiggleSortII
    {
        public void WiggleSort(int[] nums)
        {
            Array.Sort(nums);
            int Len = nums.Length;
            Stack<int> LeftSide;
            Stack<int> RightSide;
            if (Len % 2 == 0)
            {
                LeftSide = new Stack<int>(nums.Take(Len / 2));
                RightSide = new Stack<int>(nums.Skip(Len / 2));
            }
            else
            {
                LeftSide = new Stack<int>(nums.Take(Len / 2 + 1));
                RightSide = new Stack<int>(nums.Skip(Len / 2 + 1));
            }
            for (int i = 0; i < Len; i++)
            {
                switch (i % 2)
                {
                    case 0:
                        nums[i] = LeftSide.Pop();
                        break;
                    case 1:
                        nums[i] = RightSide.Pop();
                        break;
                }
            }
        }
    }
}
