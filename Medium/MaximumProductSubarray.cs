using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class MaximumProductSubarray
    {
        public int MaxProductFail(int[] nums)
        {
            int max = Int32.MinValue;
            for(int i=0; i<nums.Length; i++) //每一個數
            {
                int temp = nums[i];
                max = Math.Max(temp, max);
                for (int j=i+1; j<nums.Length; j++) //當前推進
                {
                    temp *= nums[j];
                    max = Math.Max(temp,max);
                }
            }
            return max;

        }
        public int MaxProduct(int[] nums)
        {
            int res = nums[0], n = nums.Length;
            var MaxItem = new int[n];
            var MinItem = new int[n];
            //用一個等長的 Array 來儲存直到 n 個累加的結果
            //進入下一號以後，會把第 n+1 號的內容再刷新，所以相當於兩個迴圈的結果
            MaxItem[0] = nums[0];//找最大
            MinItem[0] = nums[0];//找最小
            for (int i = 1; i < n; ++i)
            {
                MaxItem[i] = Math.Max(Math.Max(MaxItem[i - 1] * nums[i], MinItem[i - 1] * nums[i]), nums[i]);
                //上一號跟這一號相比，因為最小向可能是負數向，所以也要跟最小向的乘積相比，再跟現階段單一向相比
                MinItem[i] = Math.Min(Math.Min(MaxItem[i - 1] * nums[i], MinItem[i - 1] * nums[i]), nums[i]);
                //上一號跟這一號相比，因為最小向可能是負數向，所以也要跟最小向的乘積相比，再跟現階段單一向相比
                res = Math.Max(res, MaxItem[i]);
            }
            return res;

        }
    }
}
