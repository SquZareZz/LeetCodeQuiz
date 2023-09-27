using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class EvaluateReversePolishNotation
    {
        public int EvalRPN(string[] tokens)
        {
            var Memory = new Stack<int>();
            foreach (var token in tokens)
            {
                if (Int32.TryParse(token, out int temp))
                {
                    Memory.Push(temp);
                }
                else
                {
                    int Last = Memory.Pop(), Last2 = Memory.Pop();
                    switch (token)
                    {
                        case "+":
                            Memory.Push(Last2 + Last);
                            break;
                        case "-":
                            Memory.Push(Last2 - Last);
                            break;
                        case "*":
                            Memory.Push(Last2 * Last);
                            break;
                        case "/":
                            Memory.Push(Last2 / Last);
                            break;
                    }
                }
            }
            return Memory.Pop();
        }
    }
}
