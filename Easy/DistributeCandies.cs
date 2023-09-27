using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class DistributeCandies
    {
        public int DistributeCandies1(int[] candyType)
        {
            var DicCandy = new Dictionary<int, int>();
            int Count = 0, Len = candyType.Length / 2;
            foreach (var candy in candyType)
            {
                if (!DicCandy.ContainsKey(candy))
                {
                    DicCandy.Add(candy, candy);
                    Count++;
                }
            }
            return Count < Len ? Count : Len;
        }
    }
}
