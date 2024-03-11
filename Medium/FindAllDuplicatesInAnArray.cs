using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace QuizSolution.Medium
{
    public class FindAllDuplicatesInAnArray
    {
        public IList<int> FindDuplicates(int[] nums)
        {
            var Result = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                if (Result.ContainsKey(num))
                {
                    Result[num]++;
                }
                else
                {
                    Result.Add(num, 1);
                }
            }
            return Result.Where(x => x.Value > 1).Select(x => x.Key).ToList();
        }
        public IList<int> FindDuplicatesFail(int[] nums)
        {
            //太慢
            var Result = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    if (j == i)
                    {
                        continue;
                    }
                    if (!Result.Contains(nums[i]) && nums[j] == nums[i])
                    {
                        Result.Add(nums[i]);
                        break;
                    }
                }
            }
            return Result;
        }
    }
}
