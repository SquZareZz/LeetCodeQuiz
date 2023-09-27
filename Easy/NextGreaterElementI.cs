using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class NextGreaterElementI
    {
        public int[] NextGreaterElement(int[] nums1, int[] nums2)
        {
            int Len1 = nums1.Length;
            int Len2 = nums2.Length;
            var Result = new int[Len1];

            for (int i = 0; i < Len1; i++)
            {
                int index = Array.IndexOf(nums2, nums1[i]);
                if (index + 1 == Len2)
                {
                    Result[i] = -1;
                }
                else
                {
                    for (int j = index + 1; i < Len2 + 1; j++)
                    {
                        if (j == Len2)
                        {
                            Result[i] = -1;
                            break;
                        }
                        if (nums2[j] > nums1[i])
                        {
                            Result[i] = nums2[j];
                            break;
                        }

                    }
                }
            }
            return Result;
        }
    }
}
