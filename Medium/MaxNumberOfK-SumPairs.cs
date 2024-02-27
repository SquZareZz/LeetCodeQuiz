using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class MaxNumberOfK_SumPairs
    {
        public int MaxOperationsFail(int[] nums, int k)
        {
            //花費時間太長
            var DetectList = nums.ToList();
            int Now = 0;
            int Turns = 0;
            while (DetectList.Count > 0 && Now < DetectList.Count)
            {
                int NowNum = DetectList[Now];
                if (NowNum > k || DetectList.IndexOf(k - NowNum) == -1 || DetectList.IndexOf(k - NowNum) == Now)
                {
                    Now++;
                    continue;
                }
                DetectList.RemoveAt(Now);
                DetectList.RemoveAt(DetectList.IndexOf(k - NowNum));
                Now = 0;
                Turns++;
            }
            return Turns;
        }
        public int MaxOperationsFail2(int[] nums, int k)
        {
            //還是太慢
            int Turns = 0;
            for (int i = 0; i < k / 2; i++)
            {
                int Second = k - i - 1;
                if (!nums.Contains(i + 1) || !nums.Contains(Second)) continue;
                if (Second != i + 1)
                {
                    int FirstCount = nums.Count(x => x == i + 1);
                    int SecondCount = nums.Count(x => x == Second);
                    Turns += Math.Min(FirstCount, SecondCount);
                }
                else
                {
                    Turns += nums.Count(x => x == Second) / 2;
                }
            }
            return Turns;
        }
        public int MaxOperationsFail3(int[] nums, int k)
        {
            //還是太慢
            var DetectList = nums.ToList();
            int Turns = 0;
            while (DetectList.Count > 0)
            {
                int Second = k - DetectList.First();
                if (!DetectList.Contains(Second))
                {
                    int ToRemove = DetectList.First();
                    DetectList.RemoveAll(x => x == ToRemove);
                    continue;
                }
                if (Second != DetectList.First())
                {
                    int ToRemove = DetectList.First();
                    int FirstCount = DetectList.Count(x => x == ToRemove);
                    int SecondCount = DetectList.Count(x => x == Second);
                    Turns += Math.Min(FirstCount, SecondCount);
                    DetectList.RemoveAll(x => x == ToRemove);
                    DetectList.RemoveAll(x => x == Second);
                }
                else
                {
                    int ToRemove = DetectList.First();
                    Turns += DetectList.Count(x => x == Second) / 2;
                    DetectList.RemoveAll(x => x == ToRemove);
                }
            }
            return Turns;
        }
        public int MaxOperations(int[] nums, int k)
        {
            //用一個 Dict 來偵測
            int Res = 0;
            var DictNums = new Dictionary<int, int>();

            foreach (int num in nums)
            {
                //第一次偵測到可以配對的數值時，加入 Dict 
                //該配對的數 => k - num
                //如果存在候補數字並且數量大過 1，配對並把對應數 -1，而且不置入當前數字，所以當前數字不增加
                if (DictNums.TryGetValue(k - num, out int count) && count > 0)
                {
                    DictNums[k - num] = count - 1;
                    Res++;
                }
                else
                {
                    //Key 必定是 num。如果 Value 配對不到的情況，將該數加入進候補並賦值 1
                    //如果配對的到，那麼就是現有存在數 +1
                    DictNums[num] = DictNums.TryGetValue(num, out int existingCount) ? existingCount + 1 : 1;
                }
            }

            return Res;
        }
    }
}
