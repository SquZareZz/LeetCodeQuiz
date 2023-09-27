using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class FizzBuzz
    {
        public IList<string> FizzBuzz1(int n)
        {
            var Result = new List<string>();
            Result.Add("1");
            for (int i = 2; i < n + 1; i++)
            {
                int ToJudge = 0;
                if (i % 3 == 0 && i % 5 == 0)
                {
                    ToJudge = 1;
                }
                else if (i % 3 == 0)
                {
                    ToJudge = 2;
                }
                else if (i % 5 == 0)
                {
                    ToJudge = 3;
                }
                switch (ToJudge)
                {
                    case 1:
                        Result.Add("FizzBuzz");
                        break;
                    case 2:
                        Result.Add("Fizz");
                        break;
                    case 3:
                        Result.Add("Buzz");
                        break;
                    default:
                        Result.Add(i.ToString());
                        break;
                }
            }
            return Result;
        }
    }
}
