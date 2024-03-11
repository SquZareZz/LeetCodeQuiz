using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class SplitTheArray
    {
        public bool IsPossibleToSplit(int[] nums)
        {
            var Times = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (Times.ContainsKey(num))
                {
                    Times[num]++;
                }
                else
                {
                    Times[num] = 1;
                }
            }
            if (Times.Values.Any(x => x > 2)) return false;
            return Times.Values.Count(x => x == 1) % 2 == 0;
        }
    }
}
