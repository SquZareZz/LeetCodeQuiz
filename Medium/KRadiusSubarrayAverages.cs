using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class KRadiusSubarrayAverages
    {
        public int[] GetAveragesFail(int[] nums, int k)
        {
            //捨棄位數後出錯
            var Result = new List<int>();
            decimal temp = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i < k || i + k >= nums.Length)
                {
                    Result.Add(-1);
                }
                else
                {
                    int Len = 2 * k + 1;
                    if (i - k == 0)
                    {
                        for (int j = 0; j < i + k + 1; j++)
                        {
                            temp += Math.Round((decimal)nums[j] / Len, 20);
                        }
                        Result.Add((int)temp);

                    }
                    else
                    {
                        var NewTemp = temp + Math.Round((decimal)nums[i + k] / Len, 20)
                            - Math.Round((decimal)nums[i - k - 1] / Len, 20);
                        Result.Add((int)NewTemp);
                        temp = NewTemp;

                    }

                }
            }
            return Result.ToArray();
        }
        public int[] GetAverages(int[] nums, int k)
        {
            var Result = new List<int>();
            ulong temp = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i < k || i + k >= nums.Length)
                {
                    Result.Add(-1);
                }
                else
                {
                    int Len = 2 * k + 1;
                    if (i - k == 0)
                    {
                        var Tar = nums.Take(Len);
                        foreach (int num in Tar)
                        {
                            temp += (ulong)num;
                        };
                        Result.Add((int)(temp / (ulong)Len));
                    }
                    else
                    {
                        var NewTemp = temp + (ulong)nums[i + k] - (ulong)nums[i - k - 1];
                        Result.Add((int)(NewTemp / (ulong)Len));
                        temp = NewTemp;
                    }

                }
            }
            return Result.ToArray();
        }
    }
}
