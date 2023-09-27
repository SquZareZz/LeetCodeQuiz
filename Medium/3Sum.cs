using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class _3Sum
    {
        public IList<IList<int>> ThreeSumFail(int[] nums)
        {
            IList<IList<int>> Result = new List<IList<int>>();
            //int[] Temp = new int[3];
            int i = 0, j = 1;
            for (int k = 2; k < nums.Length; i++, j++, k++)
            {

                int[] NumsToken = nums.ToArray().Where((val, idx) => idx != i && idx != j).ToArray();
                int Target = Array.IndexOf(NumsToken, 0 - nums[i] - nums[j]);
                if (Target != -1)
                {
                    int[] temp = new int[] { nums[i], nums[j], NumsToken[Target] };
                    Array.Sort(temp);
                    if (!Result.Any(c => c.SequenceEqual(temp)))
                    {
                        Result.Add(temp);
                    }
                    //if(Result.Except(Result).Count()!=0)
                }
            }
            return Result;
        }
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> Result = new List<IList<int>>();
            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 2; i++)
            {
                int j = i + 1, k = nums.Length - 1;
                //兩個相同數重疊的時候，確認是否為第一次計算
                //所以要-1
                if (i > 0 && nums[i] == nums[i - 1])
                {
                    continue;
                }
                while (j != k)
                {
                    //兩個相同數重疊的時候，確認是否為第一次計算
                    //所以要-1
                    //而且要確認這兩個數不是相鄰數，因為相鄰數要先算一次
                    if (nums[j] == nums[j - 1] && j > i + 1)
                    {
                        j++;
                        continue;
                    }
                    int temp = nums[i] + nums[j] + nums[k];
                    if (temp == 0)
                    {
                        Result.Add(new int[] { nums[i], nums[j], nums[k] });
                        j++;
                    }
                    else if (temp < 0)
                    {
                        j++;
                    }
                    else
                    {
                        k--;
                    }
                }
            }
            return Result;
        }
    }
}
