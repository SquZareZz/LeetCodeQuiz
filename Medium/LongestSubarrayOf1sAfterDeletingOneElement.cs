using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class LongestSubarrayOf1sAfterDeletingOneElement
    {
        public int LongestSubarray(int[] nums)
        {
            //先找出原本的索引值            
            var ZeroIndex = nums.Select((num, index) => new { num, index })
                             .Where(pair => pair.num == 0)
                             .Select(pair => pair.index)
                             .ToList();
            if (ZeroIndex.Count() == 0 || ZeroIndex.Count() == 1)
            {
                return nums.Length - 1;
            }
            else
            {
                var Result = 0;
                int PrevNum = ZeroIndex[0];
                for (int i = 0; i < ZeroIndex.Count(); i++)
                {
                    //重疊 0 時可以跳過不做，答案不變
                    if (PrevNum == ZeroIndex[i] - 1)
                    {
                        PrevNum = ZeroIndex[i];
                        continue;
                    }
                    else
                    {
                        PrevNum = ZeroIndex[i];
                    }
                    //找出刪除一個 0 後的新 List
                    var RemoveOne = nums.ToList();
                    RemoveOne.RemoveAt(ZeroIndex[i]);
                    var RemoveOne_ZeroIndex = new List<int>();
                    foreach (var Index in ZeroIndex)
                    {
                        if (Index == ZeroIndex[i])
                        {
                            continue;
                        }
                        else if (Index > ZeroIndex[i])
                        {
                            RemoveOne_ZeroIndex.Add(Index - 1);
                        }
                        else
                        {
                            RemoveOne_ZeroIndex.Add(Index);
                        }
                    }

                    for (int j = 0; j < RemoveOne_ZeroIndex.Count; j++)
                    {
                        if (j == 0)
                        {
                            Result = Math.Max(Result, RemoveOne_ZeroIndex[j]);
                        }
                        else
                        {
                            Result = Math.Max(Result, RemoveOne_ZeroIndex[j] - RemoveOne_ZeroIndex[j - 1] - 1);
                        }
                    }
                    Result = Math.Max(Result, RemoveOne.Count - RemoveOne_ZeroIndex.Last() - 1);
                }
                return Result;
            }

        }
    }
}
