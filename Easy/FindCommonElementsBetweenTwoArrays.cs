using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class FindCommonElementsBetweenTwoArrays
    {
        public int[] FindIntersectionValues(int[] nums1, int[] nums2)
        {
            var Res = new int[2];
            for (int i = 0; i < nums1.Length; i++)
            {
                if (nums2.Contains(nums1[i]))
                {
                    Res[0]++;
                }
            }
            if (Res[0] == 0) return Res;
            for (int i = 0; i < nums2.Length; i++)
            {
                if (nums1.Contains(nums2[i]))
                {
                    Res[1]++;
                }
            }
            return Res;
        }
        public int[] FindIntersectionValues2(int[] nums1, int[] nums2)
        {
            var Res = new int[2];
            Res[0] = nums1.Count(x => nums2.Contains(x));
            Res[1] = nums2.Count(x => nums1.Contains(x));
            return Res;
        }
    }
}
