using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class Permutations
    {
        public IList<IList<int>> PermuteFail(int[] nums)
        {
            var Result = new List<IList<int>>();
            if (nums.Length == 2)
            {
                Result.Add(new List<int>() { nums[0], nums[1] });
                Result.Add(new List<int>() { nums[1], nums[0] });
            }
            else if (nums.Length == 1)
            {
                Result.Add(new List<int>() { nums[0] });
            }
            else
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    for (int j = 0; j < nums.Length; j++)
                    {
                        if (i == j)
                        {
                            continue;
                        }
                        for (int k = 0; k < nums.Length; k++)
                        {
                            if (k == i || k == j)
                            {
                                continue;
                            }
                            var NumsTemp = nums.ToArray();
                            var ToTurnTemp = new List<int> { nums[i], nums[j], nums[k] };
                            for (int l = 0; l < NumsTemp.Length; l++)
                            {
                                if (l != i && l != j && l != k)
                                {
                                    ToTurnTemp.Add(nums[l]);
                                }
                            }
                            if (!Result.Any(x => x.SequenceEqual(ToTurnTemp)))
                            {
                                Result.Add(ToTurnTemp);
                            }
                        }
                    }

                }
            }
            return Result;
        }
        public IList<IList<int>> Permute(int[] nums)
        {
            var Result = new List<IList<int>>();
            permuteDFS(nums.ToList(), 0, Result);

            return Result;
        }
        void permuteDFS(List<int> num, int start, List<IList<int>> res)
        {
            if (start >= num.Count())
            {
                res.Add(num.ToArray());
            }
            for (int i = start; i < num.Count(); i++)
            {
                //邏輯：直到遍歷到最後前，都重新CALL一次交換式
                //如果遍歷到最後時，將當前的Nums加入結果
                //只考慮後一數的交換，所以不會重複，所以最後一數只跟自己交換，第一輪的FOR迴圈不起變化
                //一次換兩個數 2->2;1->2、1->1;0->1、0->2、0->0 => 一次換三個數
                //從交換最多數字做到交換最少數字
                (num[start], num[i]) = (num[i], num[start]);//把數字換過去
                //Console.Write("Before i=" + i + ", " + "Start=" + start + "\n");
                //Console.Write("Start permuteDFS\n");
                permuteDFS(num, start + 1, res);
                (num[start], num[i]) = (num[i], num[start]);//把數字換回來
                //Console.Write("After i=" + i + ", " + "Start=" + start + "\n");
                //Console.Write("Quit permuteDFS\n");
            }
        }
        void permuteDFSLeastMemory(List<int> num, int start, List<IList<int>> res)
        {
            if (start >= num.Count())
            {
                res.Add(num.ToArray());
            }
            else
            {
                for (int i = start; i < num.Count(); i++)
                {
                    (num[start], num[i]) = (num[i], num[start]);
                    permuteDFS(num, start + 1, res);
                    (num[start], num[i]) = (num[i], num[start]);
                }
            }
        }
    }
}
