using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class SpecialArrayWithXElementsGreaterThanOrEqualX
    {
        public int SpecialArray(int[] nums)
        {
            //做得出來，但太慢
            for (int i = 0; i <= nums.Length; i++)
            {
                if (nums.Count(x => x >= i) == i) return i;
            }
            return -1;
        }
        public int SpecialArray2(int[] nums)
        {
            for (int i = 0; i <= nums.Length; i++)
            {
                var temp = 0;
                foreach (var num in nums)
                {
                    if (num >= i) temp++;                    
                    if (temp > i)
                    {
                        break;
                    }
                }
                if (temp == i)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
