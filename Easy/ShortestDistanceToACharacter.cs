using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class ShortestDistanceToACharacter
    {
        public int[] ShortestToChar(string s, char c)
        {
            int[] result = new int[s.Length];
            int Loc = 0, Index = s.IndexOf(c);
            foreach (var word in s)
            {
                if (word == c)
                {
                    result[Loc] = 0;
                    Index = Loc;
                }
                else
                {
                    var newIndex = s.IndexOf(c, Loc);
                    if (newIndex > -1)
                    {
                        result[Loc] = Math.Min(Math.Abs(Loc - Index), Math.Abs(Loc - newIndex));
                        Index = Math.Min(Index, newIndex);
                    }
                    else
                    {
                        result[Loc] = Math.Abs(Loc - Index);
                    }
                }
                Loc++;
            }
            return result;
        }
    }
}
