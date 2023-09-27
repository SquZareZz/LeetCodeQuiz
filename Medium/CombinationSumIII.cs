using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class CombinationSumIII
    {
        public List<IList<int>> Result { get; set; } = new List<IList<int>>();
        public IList<IList<int>> CombinationSum3(int k, int n)
        {
            if (n > 45)
            {
                return Result;
            }
            for (int i = 1; i < 10; i++)
            {
                var temp = new List<int>() { i };
                if (i < n)
                {
                    CombineRoutine(Result, temp, k, n);
                }
                else if (i == n && k == 1)
                {
                    Result.Add(temp);
                }
                else
                {
                    break;
                }
            }
            return Result;
        }
        public IList<IList<int>> CombinationSum3_2(int k, int n)
        {
            var NowList = new List<int>();
            CombineRoutine2(Result, NowList, k, n, 1);
            return Result;
        }
        public void CombineRoutine(List<IList<int>> Result, List<int> NowList, int LimitNums, int LimitValue)
        {
            int Target = LimitValue - NowList.Sum();
            if (NowList.Count == LimitNums)
            {
                if (Target == 0)
                {
                    foreach (var temp in Result)
                    {
                        if (temp.OrderBy(e => e).SequenceEqual(NowList.OrderBy(e => e)))
                        {
                            return;
                        }
                    }
                    Result.Add(new List<int>(NowList));
                }
                return;
            }
            else
            {
                for (int i = 1; i < 10; i++)
                {
                    if (!NowList.Contains(i))
                    {
                        NowList.Add(i);
                        CombineRoutine(Result, NowList, LimitNums, LimitValue);
                        NowList.RemoveAt(NowList.Count - 1);
                    }
                }
            }
        }

        public void CombineRoutine2(List<IList<int>> Result, List<int> NowList, int LimitNums, int LimitValue, int start)
        {
            if (LimitValue < 0)
            {
                return;
            }
            if (LimitValue == 0 && NowList.Count() == LimitNums)
            {
                Result.Add(new List<int>(NowList));
            }
            for (int i = start; i <= 9; ++i)
            {
                NowList.Add(i);
                CombineRoutine2(Result, NowList, LimitNums, LimitValue - i, i + 1);
                NowList.RemoveAt(NowList.Count - 1);
            }
        }
    }
}
