using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class FindTheDifferenceOfTwoArrays
    {
        public IList<IList<int>> FindDifference(int[] nums1, int[] nums2)
        {
            var Result = new List<IList<int>>();
            var List1 = new List<int>();
            var List2 = new List<int>();
            foreach (var i in nums1)
            {
                if (Array.IndexOf(nums2, i) == -1 && !List1.Contains(i))
                {
                    List1.Add(i);
                }
            }
            foreach (var i in nums2)
            {
                if (Array.IndexOf(nums1, i) == -1 && !List2.Contains(i))
                {
                    List2.Add(i);
                }
            }
            Result.Add(List1); Result.Add(List2);
            return Result;
        }
    }
}
