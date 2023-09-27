using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class ArrayPartition
    {
        public int ArrayPairSum(int[] nums)
        {
            Array.Sort(nums);
            var NewInt = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0 || i % 2 == 0)
                {
                    NewInt.Add(nums[i]);
                }
            }
            return NewInt.Sum();
        }
        public int ArrayPairSumFastestWay(int[] nums)
        {
            Array.Sort(nums);
            int Result = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                Result += i % 2 == 0 ? nums[i] : 0;
            }
            return Result;
        }
    }
}
