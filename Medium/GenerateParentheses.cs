using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class GenerateParentheses
    {
        public IList<string> GenerateParenthesis1(int n)
        {
            string s = "";
            GenerateParenthesisWord(n, n, s);
            return Result;
        }
        List<string> Result = new List<string>();

        //先做左極限，當左極限到了換右邊做到極限，之後每一層會讓左極限減一，追加的條件是左=右=0
        private void GenerateParenthesisWord(int Left, int Right, string s)
        {
            if (Left == 0 && Right == 0)
            {
                Result.Add(s);
            }
            if (Left > 0)
            {
                GenerateParenthesisWord(Left - 1, Right, s + '(');
            }
            if (Right > 0 && Left < Right)
            {
                GenerateParenthesisWord(Left, Right - 1, s + ')');
            }

        }
    }
}
