using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class KidsWithTheGreatestNumberOfCandies
    {
        public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
        {
            var Result= new List<bool>();
            int Tar = candies.Max();
            foreach (var candy in candies)
            {
                Result.Add(candy + extraCandies >= Tar);
            }
            return Result;
        }
        public IList<bool> KidsWithCandies2(int[] candies, int extraCandies)
        {
            return candies.Select(x=>x+extraCandies>= candies.Max()).ToList();
        }
    }
}
