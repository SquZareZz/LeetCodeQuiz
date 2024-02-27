using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class MaxConsecutiveOnesIII
    {
        public int LongestOnes(int[] nums, int k)
        {
            //會過，但花費時間很長
            int Quota;
            int Result = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (Result > nums.Length - i - 1)
                {
                    break;
                }
                Quota = nums[i] == 1 ? k : k - 1;
                int temp = Quota >= 0 ? 1 : 0;
                for (int j = i + 1; j < nums.Length; j++)
                {
                    Quota -= nums[j] == 0 ? 1 : 0;
                    if (Quota < 0)
                    {
                        break;
                    }
                    temp++;
                }
                Result = Math.Max(temp, Result);
            }
            return Result;
        }
        public int LongestOnesFail(int[] nums, int k)
        {
            //Fail
            int Above = nums.Count(x => x == 0);
            int ToRemoveFront = 0;
            int ToRemoveBack = 0;
            while (Above > k)
            {
                int Len = nums.Length;
                var Candidate = nums.Select((num, index) => new { num, index })
                                 .Where(x => x.num == 0)
                                 .Select(x => x.index)
                                 .ToList();
                if (k == 0)
                {
                    if (Candidate[0] < Len - 1 - Candidate[Candidate.Count() - 1])
                    {
                        nums = nums.Skip(Candidate[0] + 1).ToArray();
                    }
                    else
                    {
                        nums = nums.Take(Candidate[Candidate.Count() - 1]).ToArray();
                    }
                }
                else
                {
                    if (Candidate[k] - 1 < Len + 1 - Candidate[Candidate.Count() - k])
                    {
                        nums = nums.Skip(Candidate[0] + 1).ToArray();
                    }
                    else if (Candidate[k] - 1 == Len + 1 - Candidate[Candidate.Count() - k - 1] + 1)
                    {
                        int temp = 1;
                        while (Candidate[k - temp] - 1 == Len + 1 - Candidate[Candidate.Count() - k + temp - 1] + 1)
                        {
                            temp++;
                        }
                        if (Candidate[k - temp] - 1 == Len + 1 - Candidate[Candidate.Count() - k + temp - 1] + 1)
                        {
                            nums = nums.Skip(Candidate[0] + 1).ToArray();
                        }
                        else
                        {
                            nums = nums.Take(Candidate[Candidate.Count() - 1]).ToArray();
                        }

                    }
                    else
                    {
                        nums = nums.Take(Candidate[Candidate.Count() - 1]).ToArray();
                    }
                }
                Above--;
            }
            return nums.Length;
        }
        public int LongestOnes2(int[] nums, int k)
        {
            //只需要討論能夠湊出最大解的方式，並沒有限制每次動作必須刪除哪一項
            //所以滑窗後的結果不代表索引值。
            int n = nums.Length, i = 0, j = 0;
            for (; j < n; ++j)
            {
                //無論任何情況都從最左滑窗到最右
                //當遇到 0 的時候，Quota - 1
                if (nums[j] == 0)
                {
                    k--;
                }
                //如果 Quota = 0 的時候，左滑窗開始移動
                //並判斷最左是 0 或 1，如果是 0 Quota 必須 + 1
                if (k < 0)
                {
                    //如果
                    if (nums[i] == 0)
                    {
                        k++;
                    }
                    i++;
                }
            }
            //因為是最右索引減最左索引，所以直接是長度
            return j - i;
        }
    }
}