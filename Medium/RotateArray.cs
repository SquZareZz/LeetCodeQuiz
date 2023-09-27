using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class RotateArray
    {
        public void RotateFail(int[] nums, int k)
        {
            //太慢
            int Len=nums.Length;
            for(int i = 0; i < k; i++)
            {
                for(int j = Len-1; j > 0; j--)
                {
                    (nums[j], nums[j - 1]) = (nums[j - 1], nums[j]);
                }
            }
        }
        public void Rotate(int[] nums, int k)
        {
            int Len = nums.Length;
            while(k > Len)
            {
                k = k - Len;
            }
            var first = nums.Take(Len - k).ToArray();
            var second = nums.Skip(Len-k).ToArray();
            for (int i = 0; i < second.Length; i++)
            {
                nums[i] = second[i];
            }
            for(int i=0; i < first.Length; i++)
            {
                nums[i+ second.Length] = first[i];
            }
        }
    }
}
