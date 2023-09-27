using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class FindTheDuplicateNumber
    {
        public int FindDuplicate(int[] nums)
        {
            var Check=new Dictionary<int, int>();
            foreach (int i in nums) 
            {
                if (Check.ContainsKey(i))
                {
                    return i;
                }
                else
                {
                    Check.Add(i, i);
                }
            }
            return 0;
        }
        public int FindDuplicateFunWay(int[] nums)
        {
            return nums.GroupBy(x => x)
              .Where(g => g.Count() > 1)
              .Select(y => y.Key)
              .ToList()[0];
        }
    }
}
