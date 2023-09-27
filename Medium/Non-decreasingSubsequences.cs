using Microsoft.IdentityModel.Tokens;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class Non_decreasingSubsequences
    {
        IList<IList<int>> Result = new List<IList<int>>();
        HashSet<string> NoDumplicate =new HashSet<string>();
        public IList<IList<int>> FindSubsequencesFail(int[] nums)
        {
            var Limit = nums.Length;
            if (Limit < 2)
            {
                return Result;
            }
            for (int i = 2; i <= Limit; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    var Candidate = new List<int>();
                    PossibleFail(nums, j, i, Candidate, 0);
                }
            }
            return Result;
        }
        public void PossibleFail(int[] nums, int Now, int Len, List<int> Candidate, int Start)
        {
            if (Now == nums.Length) return;
            if (Candidate.Count == 0 || Candidate.Last() <= nums[Now])
            {
                Candidate.Add(nums[Now]);
            }
            if (Candidate.Count == Len)
            {
                if (!Result.Any(x => x.SequenceEqual(Candidate)))
                {
                    Result.Add(Candidate.ToList());
                }
                Candidate.RemoveAt(Candidate.Count - 1);
            }
            //Possible(nums, Now + 1, Len, Candidate.ToList(), Start + 1);
        }

        public IList<IList<int>> FindSubsequences(int[] nums)
        {
            Possible(nums, 0, new List<int>(), new HashSet<string>());
            return Result;
        }
        public void Possible(int[] nums, int Start, List<int> Candidate, HashSet<string> Dumplicate)
        {
            //置入的條件是 >= 2，因此每次堆疊開始前檢查
            if (Candidate.Count >= 2)
            {
                var temp = String.Join(",", Candidate);
                //不加分隔符號，會有數字部分重複的問題
                if (!Dumplicate.Contains(temp))
                {
                    Result.Add(Candidate.ToList());
                }
                //HashSet 自動排除重複
                Dumplicate.Add(temp);
            }
            for (int i = Start; i < nums.Length; i++)
            {
                //如果下一號沒比這一號大或一樣，跳過
                if (Candidate.Count() > 0 && Candidate.Last() > nums[i]) continue;
                Candidate.Add(nums[i]);
                Possible(nums, i + 1, Candidate, Dumplicate);
                //跳出堆疊後，這數字都已經找完，所以移除掉
                Candidate.RemoveAt(Candidate.Count - 1);
            }
        }
        public IList<IList<int>> FindSubsequences2(int[] nums)
        {
            Possible2(nums, 0, new List<int>());
            var Result = new List<IList<int>>(); 
            foreach(var num in NoDumplicate)
            {
                Result.Add(num.Split(',').Select(x => Int32.Parse(x)).ToList());
            }
            return Result;
        }
        public void Possible2(int[] nums, int Start, List<int> Candidate)
        {
            if (Candidate.Count >= 2)
            {
                NoDumplicate.Add(String.Join(",", Candidate));
            }
            for (int i = Start; i < nums.Length; i++)
            {
                //如果下一號沒比這一號大或一樣，跳過
                if (Candidate.Count() > 0 && Candidate.Last() > nums[i]) continue;
                Candidate.Add(nums[i]);
                Possible2(nums, i + 1, Candidate);
                //跳出堆疊後，這數字都已經找完，所以移除掉
                Candidate.RemoveAt(Candidate.Count - 1);
            }
        }
    }
}
