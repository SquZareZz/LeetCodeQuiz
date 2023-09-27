using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class UncrossedLines
    {
        public int MaxUncrossedLinesFail(int[] nums1, int[] nums2)
        {
            int Result = 0;
            int Over = 0;
            for (int i = 0; i < nums1.Length; i++)
            {
                int target = nums1[i];
                for (int j = Over; j < nums2.Length; j++)
                {
                    if (target == nums2[j])
                    {
                        Result++;
                        Over = j;
                        break;
                    }
                }
            }
            return Result;
        }
        public int MaxUncrossedLinesFail2(int[] nums1, int[] nums2)
        {
            var LinkedList = new List<int[]>();
            // nums1/nums2
            for (int i = 0; i < nums1.Length; i++)
            {
                int target = nums1[i];
                for (int j = 0; j < nums2.Length; j++)
                {
                    if (target == nums2[j])
                    {
                        LinkedList.Add(new int[] { i, j });
                    }
                }
            }
            for (int i = 1; i < LinkedList.Count; i++)
            {
                foreach (var temp in LinkedList.SkipLast(LinkedList.Count - i))
                {
                    if (!(LinkedList[i][1] > temp[1]))
                    {
                        LinkedList.RemoveAt(i);
                        i--;
                        break;
                    }
                }

            }
            return LinkedList.Count;
        }
        public int MaxUncrossedLines(int[] nums1, int[] nums2)
        {
            int Len1 = nums1.Length, Len2 = nums2.Length;
            var LinkedList = new int[Len1 + 1, Len2 + 1];
            for (int i = 1; i < Len1 + 1; i++)
            {
                for (int j = 1; j < Len2 + 1; j++)
                {
                    if (nums1[i - 1] == nums2[j - 1])
                    {
                        //上下相等時，更新在前一號上
                        LinkedList[i, j] = LinkedList[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        //上下不等時，注意到要採用 x 的上一號答案
                        //還是 y 的上一號答案，選比較大的那個
                        LinkedList[i, j] = Math.Max(LinkedList[i - 1, j], LinkedList[i, j - 1]);
                    }
                }
            }
            return LinkedList[Len1, Len2];
        }
    }
}
