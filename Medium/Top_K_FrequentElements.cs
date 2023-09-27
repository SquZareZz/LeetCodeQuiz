using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class Top_K_FrequentElements
    {
        public int[] TopKFrequent(int[] nums, int k)
        {
            var Dict = new Dictionary<int, int>();
            foreach(int num in nums) 
            {
                if (Dict.ContainsKey(num))
                {
                    Dict[num]++;
                }
                else
                {
                    Dict.Add(num, 1);
                }
            }
            return Dict.OrderByDescending(x => x.Value)
                .Take(k)
                .Select(x=>x.Key).ToArray();
        }
        public int[] TopKFrequentFastest(int[] nums, int k)
        {
            var Dict = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                if (Dict.ContainsKey(num))
                {
                    Dict[num]++;
                }
                else
                {
                    Dict.Add(num, 1);
                }
            }
            var Result = Dict.OrderByDescending(x => x.Value);
            return Result.Take(k).ToList().Select(x => x.Key).ToArray();
        }
    }
}
