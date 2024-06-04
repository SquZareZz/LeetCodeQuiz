using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class SingleNumberIII
    {
        public int[] SingleNumber(int[] nums)
        {
            var DictCheck = new Dictionary<int, int>();
            foreach (var i in nums)
            {
                if (DictCheck.ContainsKey(i))
                {
                    DictCheck[i]++;
                }
                else
                {
                    DictCheck.Add(i, 1);
                }
            }
            return DictCheck.Where(x => x.Value == 1).Select(x => x.Key).ToArray();
        }
        public int[] SingleNumber2(int[] nums)
        {
            return nums.GroupBy(x => x)
                .Where(x=>x.Count()==1)
                .Select(x => x.Key)
                .ToArray();
        }
    }
}
