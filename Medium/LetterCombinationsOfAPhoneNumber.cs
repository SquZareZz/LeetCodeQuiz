using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class LetterCombinationsOfAPhoneNumber
    {
        public IList<string> LetterCombinations(string digits)
        {
            int Len = digits.Length;
            var Result = new List<string>();
            if (Len == 0)
            {
                return Result;
            }
            var TransList = new List<string>()
            {
                "",
                "abc",
                "def",
                "ghi",
                "jkl",
                "mno",
                "pqrs",
                "tuv",
                "wxyz"
            };
            int[] EachPossible = new int[Len];
            int CountButtonLetters = 1;
            for (int i = Len - 1; i > -1; i--)
            {
                if (digits[i] == '1')
                {
                    continue;
                }
                CountButtonLetters *= TransList[digits[i] - 49].Length;//48='0',Index再減一號
                EachPossible[i] = CountButtonLetters;
            }
            for (int i = 0; i < EachPossible[0]; i++)
            {
                string temp = "";
                for (int j = Len - 1; j > -1; j--)
                {
                    int Target;
                    if (j < Len - 1)
                    {
                        Target = i / EachPossible[j + 1] % TransList[digits[j] - 49].Length;//48='0',Index再減一號
                    }
                    else
                    {
                        Target = i % EachPossible[j];
                    }
                    temp = TransList[digits[j] - 49][Target] + temp;//48='0',Index再減一號
                }
                Result.Add(temp);
            }
            return Result;
        }
    }
}
