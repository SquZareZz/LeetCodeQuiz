using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class FindTheIntegerAddedToArrayI
    {
        public int AddedInteger(int[] nums1, int[] nums2)
        {
            return nums2.Max() - nums1.Max();
        }
    }
}