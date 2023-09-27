using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace QuizSolution.Easy
{
    public class UniqueMorseRepresentations
    {
        public int UniqueMorseRepresentations1(string[] words)
        {
            string[] MorseCodeTable = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..",
                ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-",
                "...-", ".--", "-..-", "-.--", "--.." };
            var Result = new string[words.Length];
            int i = 0;
            string TempCode;
            foreach (var word in words)
            {
                TempCode = "";
                foreach (var alphabet in word)
                {
                    TempCode += MorseCodeTable[alphabet - 97];
                }
                Result[i] = TempCode;
                i++;
            }
            return Result.Distinct().Count();
        }
        public int UniqueMorseRepresentations2(string[] words)
        {
            string[] MorseCodeTable = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..",
                ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-",
                "...-", ".--", "-..-", "-.--", "--.." };
            var Result = new HashSet<string>();
            string TempCode;
            foreach (var word in words)
            {
                TempCode = "";
                foreach (var alphabet in word)
                {
                    TempCode += MorseCodeTable[alphabet - 97];
                }
                Result.Add(TempCode);
            }
            return Result.Count();
        }
    }
}
