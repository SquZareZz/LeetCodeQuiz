using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class TwoSumII_InputArrayIsSorted
    {
        public int[] TwoSum(int[] numbers, int target)
        {
            var NoDumplicate = new Dictionary<int, int>();
            foreach(int temp in numbers) 
            {
                if(!NoDumplicate.ContainsKey(temp)) 
                {
                    NoDumplicate.Add(temp, 1);
                }
            }
            foreach (int i in NoDumplicate.Keys)
            {
                int Index1 = Array.IndexOf(numbers, i);
                int Index2 = Array.LastIndexOf(numbers, target - i);
                if (Index1 != Index2 && Index2 > 0)
                {
                    return new int[] { Index1 + 1, Index2 + 1 };
                }
            }
            return new int[] { 0, 0 };
        }
        public int[] TwoSumSlower(int[] numbers, int target)
        {
            int Another;
            var NoDumplicate = new Dictionary<int, int>();
            foreach (int temp in numbers)
            {
                if (!NoDumplicate.ContainsKey(temp))
                {
                    NoDumplicate.Add(temp, 1);
                }
            }
            foreach (int i in NoDumplicate.Keys)
            {
                Another = target - i;
                if (Array.IndexOf(numbers, i) != Array.LastIndexOf(numbers, Another) && Array.LastIndexOf(numbers, Another) > 0)
                {
                    return new int[] { Array.IndexOf(numbers, i) + 1, Array.LastIndexOf(numbers, Another) + 1 };
                }
            }
            return new int[] { 0, 0 };
        }
        public int[] TwoSum2(int[] numbers, int target)
        {
            var NoDumplicate = new HashSet<int>(numbers);
            foreach (int i in NoDumplicate)
            {
                int Index1 = Array.IndexOf(numbers, i);
                int Index2 = Array.LastIndexOf(numbers, target - i);
                if (Index1 != Index2 && Index2 > 0)
                {
                    return new int[] { Index1 + 1, Index2 + 1 };
                }
            }
            return new int[] { 0, 0 };
        }
    }
}
