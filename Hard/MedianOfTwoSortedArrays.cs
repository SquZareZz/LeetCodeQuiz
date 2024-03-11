using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Hard
{
    public class MedianOfTwoSortedArrays
    {
        List<int> Result = new List<int>() { };
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int Len1 = nums1.Length;
            int Len2 = nums2.Length;
            if (Len1 < 2 || Len2 < 2)
            {
                return CaseLowerOne(nums1, nums2, Len1, Len2);
            }
            //ex:4
            if ((Len1 + Len2) % 2 == 0)
            {
                int End = (Len1 + Len2) / 2, i, j;
                for (i = 0, j = 0; i < Len1 || j < Len2;)
                {
                    bool EndI = i >= Len1, EndJ = j >= Len2;
                    if (Result.Count == End)
                    {
                        int ToAdd = 0;
                        if (!EndI && !EndJ)
                        {
                            ToAdd = Math.Min(nums1[i], nums2[j]);
                        }
                        else if (EndI)
                        {
                            ToAdd = nums2[j];
                        }
                        else if (EndJ)
                        {
                            ToAdd = nums1[i];
                        }
                        return (double)(Result.Last() + ToAdd) / 2;
                    }
                    if (!EndI && !EndJ)
                    {
                        var temp = Nums1OverNums2(nums1, nums2, i, j);
                        i = temp[0];
                        j = temp[1];
                    }
                    if (EndI)
                    {
                        j = Nums1End(nums1, nums2, i, j);
                    }
                    else if (EndJ)
                    {
                        i = Nums2End(nums1, nums2, i, j);
                    }
                }
                return 0;
            }
            else
            {
                int End = (Len1 + Len2 + 1) / 2, i, j;
                for (i = 0, j = 0; i < Len1 || j < Len2;)
                {
                    bool EndI = i >= Len1, EndJ = j >= Len2;
                    if (Result.Count == End)
                    {
                        return (double)(Result.Last());
                    }
                    if (!EndI && !EndJ)
                    {
                        var temp = Nums1OverNums2(nums1, nums2, i, j);
                        i = temp[0];
                        j = temp[1];
                    }
                    if (EndI)
                    {
                        j = Nums1End(nums1, nums2, i, j);
                    }
                    else if (EndJ)
                    {
                        i = Nums2End(nums1, nums2, i, j);
                    }
                }
                return 0;
            }
        }
        public double CaseLowerOne(int[] nums1, int[] nums2, int Len1, int Len2)
        {
            if (Len1 == 0)
            {
                return Len2 % 2 == 0 ? (double)(nums2[Len2 / 2] + nums2[Len2 / 2 - 1]) / 2 :
                    (double)nums2[Len2 / 2];
            }
            else if (Len1 == 1)
            {
                var temp = nums2.Append(nums1[0]).OrderBy(x => x).ToArray();
                return (Len2 + Len1) % 2 == 0 ? (double)(temp[(Len2 + Len1) / 2] + temp[(Len2 + Len1) / 2 - 1]) / 2 :
                    (double)temp[(Len2 + Len1) / 2];
            }
            if (Len2 == 0)
            {
                return Len1 % 2 == 0 ? (double)(nums1[Len1 / 2] + nums1[Len1 / 2 - 1]) / 2 :
                    (double)nums1[Len1 / 2];
            }
            else if (Len2 == 1)
            {
                var temp = nums1.Append(nums2[0]).OrderBy(x => x).ToArray();
                return (Len2 + Len1) % 2 == 0 ? (double)(temp[(Len2 + Len1) / 2] + temp[(Len2 + Len1) / 2 - 1]) / 2 :
                    (double)temp[(Len2 + Len1) / 2];
            }
            return 0;
        }
        public int[] Nums1OverNums2(int[] nums1, int[] nums2, int i, int j)
        {
            if (nums1[i] > nums2[j])
            {
                Result.Add(nums2[j]);
                j++;
            }
            else
            {
                Result.Add(nums1[i]);
                i++;
            }
            return new int[] { i, j };
        }
        public int Nums1End(int[] nums1, int[] nums2, int i, int j)
        {
            Result.Add(nums2[j]);
            return j+1;
        }
        public int Nums2End(int[] nums1, int[] nums2, int i, int j)
        {
            Result.Add(nums1[i]);
            return i+1;
        }
    }
}
