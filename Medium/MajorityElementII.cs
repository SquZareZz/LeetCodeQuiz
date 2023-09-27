using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class MajorityElementII
    {
        public IList<int> MajorityElement(int[] nums)
        {
            int LenLimit = nums.Length / 3;
            var StatisticNums = new Dictionary<int, int>();
            foreach (int i in nums)
            {
                if (StatisticNums.ContainsKey(i))
                {
                    StatisticNums[i]++;
                }
                else
                {
                    StatisticNums.Add(i, 1);
                }
            }
            return StatisticNums.Where(x => x.Value > LenLimit).Select(x => x.Key).ToList();
        }
    }
}
