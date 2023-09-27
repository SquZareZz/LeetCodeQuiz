using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class DegreeOfAnArray
    {
        public int FindShortestSubArraySlowly(int[] nums)
        {
            var DictNums = new Dictionary<int, int>();
            int Result = nums.Length;
            foreach (int num in nums)
            {
                if (!DictNums.ContainsKey(num))
                {
                    DictNums.Add(num, 1);
                }
                else
                {
                    DictNums[num]++;
                }
            }
            int maxValue = DictNums.Values.Max();
            int maxIndex = DictNums.FirstOrDefault(x => x.Value == DictNums.Values.Max()).Key;
            while (DictNums.Count > 0 && DictNums.Values.Max() == maxValue)
            {
                int temp = Array.LastIndexOf(nums, maxIndex) - Array.IndexOf(nums, maxIndex) + 1;
                Result = temp < Result ? temp : Result;
                DictNums.Remove(maxIndex);
                maxIndex = DictNums.FirstOrDefault(x => x.Value == DictNums.Values.Max()).Key;
            }
            return Result;
        }
        public int FindShortestSubArrayFail(int[] nums)
        {
            var DictNums = new Dictionary<int, int>();
            var DictNumsFirstIndex = new Dictionary<int, int>();
            var DictNumsLastIndex = new Dictionary<int, int>();
            int Result = nums.Length;
            int Count = 0;
            foreach (int num in nums)
            {
                if (!DictNums.ContainsKey(num))
                {
                    DictNums.Add(num, 1);
                    DictNumsFirstIndex.Add(num, Count);
                }
                else
                {
                    DictNums[num]++;
                    if (!DictNumsLastIndex.ContainsKey(num))
                    {
                        DictNumsLastIndex.Add(num, Count);
                    }
                    else
                    {
                        DictNumsLastIndex[num] = Count;
                    }
                }
                Count++;
            }
            if (DictNums.Count < 2)
            {
                return Result;
            }
            int maxValue = DictNums.Values.Max();
            int maxIndex = DictNums.FirstOrDefault(x => x.Value == DictNums.Values.Max()).Key;
            while (DictNums.Count > 0 && DictNums.Values.Max() == maxValue)
            {
                int temp = DictNumsLastIndex[maxIndex] - DictNumsFirstIndex[maxIndex] + 1;
                Result = temp < Result ? temp : Result;
                DictNums.Remove(maxIndex);
                maxIndex = DictNums.FirstOrDefault(x => x.Value == DictNums.Values.Max()).Key;
            }
            return Result;
        }
        public int FindShortestSubArray(int[] nums)
        {
            var DictNums = new Dictionary<int, int>();
            int Result = nums.Length;
            var DictCoor = new Dictionary<int, int>();
            int Count = 0;
            int degree = 1;
            foreach (int num in nums)
            {
                if (!DictNums.ContainsKey(num))
                {
                    DictNums.Add(num, 1);
                    DictCoor.Add(num, Count);
                }
                else
                {
                    DictNums[num]++;
                    if (DictNums[num] > degree)
                    {
                        degree++;
                        Result = Count - DictCoor[num] + 1;
                    }
                    else if (DictNums[num] == degree)
                    {
                        int temp = Count - DictCoor[num] + 1;
                        Result = Result < temp ? Result : temp;
                    }
                }
                Count++;
            }
            return degree == 1 ? 1 : Result;
        }
    }
}
