using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class LongestIncreasingSubsequence
    {
        public int LengthOfLIS(int[] nums)
        {
            int Len = nums.Length;
            int[] LIS_Len=new int[Len];  // 第 x 格的值為 s[0...x] 的 LIS 長度
            // 初始化。每一個數字本身就是長度為一的 LIS。
            for (int i = 0; i < Len; i++)
            {
                LIS_Len[i] = 1;
            }
            for (int i = 0; i < Len; i++)
            {
                // 找出 nums[i] 後面能接上哪些數字，
                // 若是可以接，長度就增加。
                // 從0開始看，去看後續所有可能
                // 到1的時候，每一項會涵蓋從0看的所有可能，所以可以當作0的延伸
                // 到每一項都經歷過以後，變考慮所有的可能
                for (int j = i + 1; j < Len; j++)
                {
                    if (nums[i] < nums[j]) 
                    {
                        LIS_Len[j] = Math.Max(LIS_Len[j], LIS_Len[i] + 1);
                    }
                        
                }
            }
            // length[] 之中最大的值即為 LIS 的長度。
            return LIS_Len.Max();
        }
    }
}
