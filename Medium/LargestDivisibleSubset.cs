using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class LargestDivisibleSubset
    {
        public IList<int> LargestDivisibleSubset1(int[] nums)
        {
            int Len=nums.Length;
            if (nums.Length == 0)
            {
                return new List<int>();
            }
            Array.Sort(nums);
            var dp = new List<List<int>>();
            for(int i = 0; i < Len; i++)
            {
                dp.Add(new List<int>() { nums[i] });
            }
            for (int i = 1; i < Len; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] % dp[j].Last() == 0 && dp[i].Count < dp[j].Count + 1)
                    {
                        dp[i] = new List<int>(dp[j])
                        {
                            nums[i]
                        };
                    }
                }
            }
            return dp.Where(x=>x.Count==dp.Max(x => x.Count)).FirstOrDefault();
        }
    }
}
