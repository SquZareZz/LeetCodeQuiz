using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class MergeSortedArray
    {
        public void MergeFail(int[] nums1, int m, int[] nums2, int n)
        {
            if (m == 0 && n == 0)
            {
                nums1 = nums1;
            }
            else if (m != 0 && n == 0)
            {
                nums1 = nums1;
            }
            else if (m == 0 && n != 0)
            {
                nums1 = nums2;
            }
            else
            {
                var temp = new int[m + n];
                int ArrCount = 0;
                int j = 0;
                int nums1Temp = 0; int nums2Temp = 0;
                //bool CallElement2 = true;
                while (m > ArrCount)
                {
                    if (nums1.Length > ArrCount)
                    {
                        if (nums1[ArrCount] != 0)
                        {
                            temp[j] = nums1[ArrCount];
                            j++;
                        }
                        ArrCount++;
                    }
                }
                ArrCount = 0;
                while (n > ArrCount)
                {
                    if (nums2.Length > ArrCount)
                    {
                        if (nums2[ArrCount] != 0)
                        {
                            temp[j] = nums2[ArrCount];
                            j++;
                        }
                        ArrCount++;
                    }
                }
                Array.Sort(temp);
                nums1 = new int[m + n];
                for (int i = 0; i < temp.Length; i++)
                {
                    nums1[i] = temp[i];
                }
            }
        }
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            //nums1.length == m + n
            //nums2.length == n
            //0 <= m, n <= 200
            //1 <= m + n <= 200
            while (m > 0 && n > 0)
            {
                if (nums1[m - 1] < nums2[n - 1])
                {
                    nums1[m + n - 1] = nums2[n - 1];
                    n--;
                }
                else
                {
                    nums1[m + n - 1] = nums1[m - 1];
                    m--;
                }
            }
            while (n > 0)
            {
                nums1[m + n - 1] = nums2[n - 1];
                n--;
            }
        }
        public void Merge2(int[] nums1, int m, int[] nums2, int n)
        {
            //nums1.length == m + n
            //nums2.length == n
            //0 <= m, n <= 200
            //1 <= m + n <= 200
            int Len = m + n;
            while (m > 0 && n > 0)
            {
                if (nums1[m - 1] < nums2[n - 1])
                {
                    nums1[Len - 1] = nums2[n - 1];
                    n--;
                }
                else
                {
                    nums1[Len - 1] = nums1[m - 1];
                    m--;
                }
            }
            while (n > 0)
            {
                nums1[Len - 1] = nums2[n - 1];
                n--;
            }
        }
    }
}
