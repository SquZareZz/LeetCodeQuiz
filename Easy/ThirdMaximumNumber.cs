using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class ThirdMaximumNumber
    {
        public int ThirdMax(int[] nums)
        {
            var numDict = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                if (!numDict.ContainsKey(num))
                {
                    numDict.Add(num, num);
                }
            }
            switch (numDict.Count())
            {
                case 1:
                    return numDict.Keys.Max();
                case 2:
                    numDict.Remove(numDict.Keys.Min());
                    return numDict.Keys.Max();
                default:
                    numDict.Remove(numDict.Keys.Max());
                    numDict.Remove(numDict.Keys.Max());
                    return numDict.Keys.Max();
            }
        }
    }
}
