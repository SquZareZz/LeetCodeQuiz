using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class IntersectionOfTwoArrays
    {
        public int[] Intersection(int[] nums1, int[] nums2)
        {
            int[] longer;
            int[] shorter;
            var Result = new List<int>();
            if (nums1.Length < nums2.Length)
            {
                shorter = nums1.ToArray();
                longer = nums2.ToArray();
            }
            else
            {
                shorter = nums2.ToArray();
                longer = nums1.ToArray();
            }

            for (int i = 0; i < shorter.Length; i++)
            {
                int temp = shorter[i];
                if (longer.Contains(temp) && shorter.Contains(temp))
                {
                    Result.Add(temp);
                }
            }
            var ReResult = new HashSet<int>(Result);
            return ReResult.ToArray();
        }
    }
}
