using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class MinimumNumberGame
    {
        public int[] NumberGame(int[] nums)
        {
            List<int> resultTemp = new List<int>();
            Array.Sort(nums);
            for (int i = 0; i < nums.Length; i++)
            {
                if (i % 2 == 0)
                {
                    resultTemp.Add(nums[i + 1]);
                }
                else
                {
                    resultTemp.Add(nums[i - 1]);
                }
            }
            return resultTemp.ToArray();
        }
    }
}
