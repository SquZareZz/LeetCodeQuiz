using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class TotalHammingDistance
    {
        public int TotalHammingDistanceFail(int[] nums)
        {
            //太慢
            HashSet<int[]> uniqueCombine = new HashSet<int[]>();
            int Result = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    var temp = new int[] { nums[i], nums[j] };
                    //Array.Sort(temp);
                    uniqueCombine.Add(temp);
                }
            }
            foreach (var Candidate in uniqueCombine)
            {
                int xor = Candidate[0] ^ Candidate[1]; // 對兩整數進行XOR
                int distance = 0;

                // XOR结果中1的位数，即為漢明距離
                while (xor != 0)
                {
                    if ((xor & 1) == 1)
                    {
                        distance++;
                    }
                    xor >>= 1; // 右移一位，检查下一位
                }
                Result += distance;
            }
            return Result;
        }

        public int TotalHammingDistanceFail2(int[] nums)
        {
            //還是太慢
            int Result = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    int xor = nums[i] ^ nums[j]; // 對兩整數進行XOR
                    // XOR结果中1的位数，即為漢明距離
                    while (xor != 0)
                    {
                        if ((xor & 1) == 1)
                        {
                            Result++;
                        }
                        xor >>= 1; // 右移一位，检查下一位
                    }
                }
            }
            return Result;
        }
        public int TotalHammingDistance1(int[] nums)
        {
            int res = 0, n = nums.Length;
            //32是因為int的最大位數，2^32
            for (int i = 0; i < 32; i++)
            {
                int cnt = 0;
                foreach (int num in nums)
                {
                    //檢查第 n 位的數字是否為 1，如果是 => ++
                    if ((num & (1 << i)) != 0) cnt++;
                }
                //計算所有數字在每一位的 "1" * "0" 的數量，就是所有組合的總和
                res += cnt * (n - cnt);
            }
            return res;
        }
    }
}
