using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class MajorityElement
    {
        public int MajorityElementOn(int[] nums)
        {
            var numsDic = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                if (numsDic.ContainsKey(num))
                {
                    numsDic[num]++;
                }
                else
                {
                    numsDic.Add(num, 1);
                }
            }
            return numsDic.FirstOrDefault(x => x.Value == numsDic.Values.Max()).Key;
        }
        public int MajorityElementO_n_To_O_logn(int[] nums)
        {
            var numsDic = new Dictionary<int, int>();
            int CheckLen = nums.Length / 2;
            foreach (int num in nums)
            {
                if (numsDic.ContainsKey(num))
                {
                    numsDic[num]++;
                    if (numsDic[num] > CheckLen)
                    {
                        return numsDic.FirstOrDefault(x => x.Value == numsDic.Values.Max()).Key;
                    }
                }
                else
                {
                    numsDic.Add(num, 1);
                }
            }

            return numsDic.FirstOrDefault(x => x.Value == numsDic.Values.Max()).Key;
        }
    }
}
