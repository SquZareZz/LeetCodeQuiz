using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class KthMissingPositiveNumber
    {
        //嚴格遞增，所以等差一定是1，且從1開始
        public int FindKthPositive(int[] arr, int k)
        {
            //二元搜尋法
            //如果中點比編號+1還大，代表左邊有缺項，所以往左
            //反之缺項在右邊，所以中點+1往右
            int left = 0;
            int right = arr.Length;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (arr[mid] - mid >= k + 1)
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return left + k;
        }
        public int FindKthPositive2(int[] arr, int k)
        {
            int Result = 0;
            while (k > 0)
            {
                Result++;
                while (arr.Contains(Result))
                {
                    Result++;
                }
                k--;
            }
            return Result;
        }
    }
}
