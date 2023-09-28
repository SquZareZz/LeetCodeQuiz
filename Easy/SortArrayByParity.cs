using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class SortArrayByParity
    {
        public int[] SortArrayByParity1(int[] nums)
        {
            var Result = new List<int>();
            foreach (int num in nums)
            {
                if (num % 2 == 1)
                {
                    Result.Add(num);
                }
                else
                {
                    Result.Insert(0, num);
                }
            }
            return Result.ToArray();
        }
        public int[] SortArrayByParity2(int[] nums)
        {
            Array.Sort(nums, (x, y) =>
            {
                // 如果 x 是偶數而 y 是奇數，將 x 放在 y 前面
                // 如果 x 是奇數而 y 是偶數，將 y 放在 x 前面
                // 不考慮同性質排列，因此不另外假設
                return (x % 2 == 0 && y % 2 != 0) ? -1 : 1;
            });
            return nums;
        }
    }
}
