using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class FindKPairsWithSmallestSums
    {
        public IList<IList<int>> KSmallestPairsFail(int[] nums1, int[] nums2, int k)
        {
            var Result = new List<IList<int>>();
            Result.Add(new List<int>() { nums1[0], nums2[0] });
            int Len1 = nums1.Length, Len2 = nums2.Length;
            for (int i = 1, j = 1; Result.Count < k;)
            {
                if (j == Len2)
                {
                    j = 0;
                    Result.Add(new List<int>() { nums1[i], nums2[0] });
                    i++;
                    continue;
                }
                else if (i == Len1)
                {
                    i = 0;
                    Result.Add(new List<int>() { nums1[0], nums2[j] });
                    j++;
                    continue;
                }
                int Target1 = Len1 > 1 ? nums1[i] + Result.Last()[1] : Result.Last()[0] + Result.Last()[1];//動1號
                int Target2 = Len2 > 1 ? Result.Last()[0] + nums2[j] : Result.Last()[0] + Result.Last()[1];//動2號
                if (Target1 <= Target2 && i < Len1)
                {
                    Result.Add(new List<int>() { nums1[i], Result.Last()[1] });
                    i++;

                }
                else if (Target2 < Target1 && j < Len2)
                {
                    Result.Add(new List<int>() { Result.Last()[0], nums2[j] });
                    j++;
                }

            }
            int Target = Math.Min(Len1 * Len2, k);
            return Result.Take(Target).ToList();
        }
        public IList<IList<int>> KSmallestPairsFail2(int[] nums1, int[] nums2, int k)
        {
            //不能先抓在排列
            //有可能檔案過大
            int Len1 = nums1.Length, Len2 = nums2.Length;
            var Result = new List<IList<int>>();
            var Candidate = new List<Tuple<int, List<int>>>();
            for (int i = 0; i < Len1; i++)
            {
                for (int j = 0; j < Len2; j++)
                {
                    Candidate.Add(new Tuple<int, List<int>>
                        (nums1[i] + nums2[j], new List<int> { nums1[i], nums2[j] }));
                }
            }
            var TakeOut = Candidate.OrderBy(a => a.Item1).Select(a => a.Item2).Take(k).ToList();
            foreach (var item in TakeOut)
            {
                Result.Add(item);
            }
            return Result;
        }
        public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
        {

            var Result = new List<IList<int>>();
            if (nums1.Length == 0 || nums2.Length == 0) return Result;
            int Size = k / nums1.Length < nums2.Length ? k : nums1.Length * nums2.Length;
            //表示Nums2"接下來"要指到哪一項
            var idx = new int[nums1.Length];
            for (int i = 0; i < Size; i++)
            {
                int t = 0, sum = Int32.MaxValue;
                for (int j = 0; j < nums1.Length; j++)
                {
                    //nums2的Index必須小於長度且
                    //總和看的數是上一階段的數字，所以比nums1最大可能小於等於
                    //因為是升序，所以下一個數勢必大於等於當前數
                    if (idx[j] < nums2.Length && sum >= nums1[j] + nums2[idx[j]])
                    {
                        t = j;
                        sum = nums1[j] + nums2[idx[j]];
                    }
                }
                Result.Add(new List<int> { nums1[t], nums2[idx[t]] });
                idx[t]++;
            }
            return Result;
        }
    }
}
