using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class JewelsAndStones
    {
        public int NumJewelsInStones(string jewels, string stones)
        {
            return stones.Count(x => jewels.Contains(x));
        }
    }
}
