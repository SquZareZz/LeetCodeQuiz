using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class _4SumII
    {
        public int FourSumCount(int[] nums1, int[] nums2, int[] nums3, int[] nums4)
        {
            int Len = nums1.Length;
            var DictAB_Sum = new List<int[,]>();
            int Result = 0;
            for(int i=0;i< Len; i++)
            {
                for(int j = 0; j < Len; j++)
                {
                    //DictAB_Sum
                }
            }
            return Result;
        }
        public int FourSumCountFail(int[] nums1, int[] nums2, int[] nums3, int[] nums4)
        {
            var DictAB_Sum = new Dictionary<int, int>();
            int Result = 0;
            //先用前兩個數字(A、B)算出組合的數量有幾個
            foreach (var num1 in nums1)
            {
                foreach (var num2 in nums2)
                {
                    int temp = num2 + num1;
                    if (!DictAB_Sum.ContainsKey(temp))
                    {
                        DictAB_Sum.Add(temp, 1);
                    }
                    else
                    {
                        DictAB_Sum[temp]++;
                    }
                }
            }
            //再用後兩個數字(C、D)算出有誰能配對
            foreach (var num3 in nums3)
            {
                foreach (var num4 in nums4)
                {
                    int temp = -(num3 + num4);
                    if (DictAB_Sum.ContainsKey(temp))
                    {
                        Result+= DictAB_Sum[temp];
                    }
                }
            }
            return Result;
        }
    }
}
