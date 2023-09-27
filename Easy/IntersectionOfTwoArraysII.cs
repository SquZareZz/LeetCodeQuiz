using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class IntersectionOfTwoArraysII
    {
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            //3,4,9,1,5
            //3,5
            Array.Sort(nums1);
            Array.Sort(nums2);
            var ans = new List<int>();
            for (int i = 0, j = 0; i < nums1.Length && j < nums2.Length;)
            {
                if (nums1[i] == nums2[j])
                {
                    ans.Add(nums1[i]);
                    i++;
                    j++;
                }
                else if (nums1[i] > nums2[j])
                {
                    j++;
                }
                else
                {
                    i++;
                }
            }

            return ans.ToArray();
        }
    }
}
