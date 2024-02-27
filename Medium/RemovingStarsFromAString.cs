using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class RemovingStarsFromAString
    {
        public string RemoveStars(string s)
        {
            var ResultStack = new Stack<char>();
            foreach (var c in s)
            {
                if (c == '*')
                {
                    ResultStack.Pop();
                }
                else
                {
                    ResultStack.Push(c);
                }
            }
            return string.Join("", ResultStack.ToArray().Reverse());
        }
    }
}
