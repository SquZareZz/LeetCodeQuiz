using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class FindAllNumbersDisappearedInAnArray
    {
        public IList<int> FindDisappearedNumbersOn2(int[] nums)
        {
            var Result = new List<int>();
            for (int i = 1; i <= nums.Length; i++)
            {
                if (Array.IndexOf(nums, i) == -1)
                {
                    Result.Add(i);
                }
            }
            return Result;
        }
        public IList<int> FindDisappearedNumbersOn(int[] nums)
        {
            var Result = new List<int>();
            var DictNum = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                if (!DictNum.ContainsKey(num))
                {
                    DictNum.Add(num, num);
                }
            }
            for (int i = 1; i < nums.Length + 1; i++)
            {
                if (!DictNum.ContainsKey(i))
                {
                    Result.Add(i);
                }
            }
            return Result;
        }
        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            var Result = new List<int>();
            int ReplaceNum = nums.Length + 1;
            int[] Temp = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                if (Temp[nums[i] - 1] != ReplaceNum)
                {
                    Temp[nums[i] - 1] = ReplaceNum;
                }
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (Temp[i] != ReplaceNum)
                {
                    Result.Add(i + 1);
                }
            }
            return Result;
        }
        public IList<int> FindDisappearedNumbers2(int[] nums)
        {
            List<int> result = new List<int>();
            int numsLength = nums.Length;

            for (int i = 0; i < numsLength; i++)
            {
                int index = Math.Abs(nums[i]) - 1;
                if (nums[index] > 0)
                {
                    nums[index] = -nums[index];
                }
            }

            for (int i = 0; i < numsLength; i++)
            {
                if (nums[i] > 0)
                {
                    result.Add(i + 1);
                }
            }

            return result;
        }

    }
}
