using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class SingleNumberII
    {
        public int SingleNumberFormatWay(int[] nums)
        {
            return nums.GroupBy(e => e).Where(e => e.Count() == 1).SelectMany(x => x).ToList()[0];
        }
        public int SingleNumber(int[] nums)
        {
            var Result = new Dictionary<int, int>();
            foreach (var x in nums) 
            {
                if(Result.ContainsKey(x)) 
                {
                    Result[x]++;
                }
                else
                {
                    Result.Add(x, 1);
                }
            }
            return Result.Where(x=>x.Value==1).FirstOrDefault().Key;
        }

    }
}
