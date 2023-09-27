using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class CombinationSum
    {
        public IList<IList<int>> CombinationSumFail(int[] candidates, int target)
        {
            var Result = new List<IList<int>>();
            foreach (var candidate in candidates)
            {
                if (candidate > target)
                {
                    candidates = candidates.Where((val, idx) => idx < Array.IndexOf(candidates, candidate)).ToArray();
                }
            }
            for (int i = candidates.Length - 1; i > -1; i--)
            {
                int tempSum = candidates[i];
                var temp = new List<int>() { tempSum };
                if (tempSum == target)
                {
                    Result.Add(temp);
                    continue;
                }
                else if (target - (tempSum + candidates[0]) < 0)
                {
                    continue;
                }
                if (i != 0)
                {
                    while (tempSum < target)
                    {
                        var temp2 = temp.ToList();
                        int targetIndex = i - 1;
                        while (temp2.Sum() < target)
                        {
                            temp2.Add(candidates[targetIndex]);
                            if (temp2.Sum() == target)
                            {
                                if (!Result.Any(p => p.SequenceEqual(temp2)))
                                {
                                    Result.Add(temp2);
                                }
                                break;
                            }
                        }
                        tempSum += candidates[targetIndex];
                        targetIndex--;
                    }
                }
                else if (target % tempSum == 0)
                {
                    for (int j = 0; j < target / tempSum - 1; j++)
                    {
                        temp.Add(tempSum);
                    }
                    Result.Add(temp);
                }
            }
            return Result;
        }
        public IList<IList<int>> CombinationSum1(int[] candidates, int target)
        {
            //窮舉法
            //計算從1~target有幾種可能
            var Result = new Dictionary<int, List<IList<int>>>();
            for (int cur_sum = 1; cur_sum < target + 1; cur_sum++)
            {
                //遍歷每個候選人
                for (int cand_index = 0; cand_index < candidates.Length; cand_index++)
                {
                    if (cur_sum < candidates[cand_index])
                    {
                        continue;
                    }
                    else if (cur_sum == candidates[cand_index])
                    {
                        var tempList = new List<int>() { candidates[cand_index] };
                        if (Result.ContainsKey(cur_sum))
                        {
                            Result[cur_sum].Add(tempList);
                        }
                        else
                        {
                            var tempList2 = new List<IList<int>>()
                            {
                                tempList
                            };
                            Result.Add(cur_sum, tempList2);
                        }
                        continue;
                    }
                    //用現在要求的數減掉目前候選人的index
                    int pre_cur_sum = cur_sum - candidates[cand_index];
                    //不存在可能值的時候，跳過
                    if (!Result.ContainsKey(pre_cur_sum))
                    {
                        continue;
                    }
                    //存在可能值的時候，遍歷每個可能值的矩陣，將它置入
                    int pre_cur_sum_size = Result[pre_cur_sum].Count;
                    for (int i = 0; i < pre_cur_sum_size; i++)
                    {
                        var targetTemp = Result[pre_cur_sum][i];
                        if (targetTemp[targetTemp.Count - 1] <= candidates[cand_index])
                        {
                            var tempList = new List<int>(targetTemp);
                            tempList.Add(candidates[cand_index]);
                            if (Result.ContainsKey(cur_sum))
                            {
                                Result[cur_sum].Add(tempList);
                            }
                            else
                            {
                                var tempList2 = new List<IList<int>>
                                {
                                    tempList
                                };
                                Result.Add(cur_sum, tempList2);
                            }
                        }
                    }
                }
            }
            return !Result.ContainsKey(target) ? new List<IList<int>>() : Result[target];
        }
    }
}
