using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class ReconstructOriginalDigitsFromEnglish
    {
        public string OriginalDigits(string s)
        {
            //zero、one、two、three、four、five、six、seven、eight、nine
            var Result = new StringBuilder();
            var UnitChar = new char[] { 'z', 'w', 'u', 'x', 'g' };
            var UnitChar2 = new char[] { 'o', 'h', 'f', 's', 'i' };
            var UnitNum = new int[] { 0, 2, 4, 6, 8 };
            var UnitNum2 = new int[] { 1, 3, 5, 7, 9 };
            //先找獨立出現的英文字母：z、w、u、x、g
            var UnitNumWord = new string[] { "zero", "two", "four", "six", "eight" };
            //再接著用刪去法，有 o 字的剩下 one、有 h 的剩下 three、f、s、i
            var UnitNumWord2 = new string[] { "one", "three", "five", "seven", "nine" };
            for (int i = 0; i < 5; i++)
            {
                if (s.Contains(UnitChar[i]))
                {
                    Result.Append(UnitNum[i]);
                    foreach (char c in UnitNumWord[i])
                    {
                        s = s.Remove(s.IndexOf(c), 1);
                    }
                    i--;
                }
            }
            for (int i = 0; i < 5; i++)
            {
                if (s.Contains(UnitChar2[i]))
                {
                    Result.Append(UnitNum2[i]);
                    foreach (char c in UnitNumWord2[i])
                    {
                        s = s.Remove(s.IndexOf(c), 1);
                    }
                    i--;
                }
            }
            return String.Join("", Result.ToString().OrderBy(x => x).ToList());
        }
        public string OriginalDigits2(string s)
        {
            //zero、one、two、three、four、five、six、seven、eight、nine
            var Result = new List<int>();
            var UnitChar = new char[] { 'z', 'w', 'u', 'x', 'g' };
            var UnitChar2 = new char[] { 'o', 'h', 'f', 's', 'i' };
            var UnitNum = new int[] { 0, 2, 4, 6, 8 };
            var UnitNum2 = new int[] { 1, 3, 5, 7, 9 };
            //先找獨立出現的英文字母：z、w、u、x、g
            var UnitNumWord = new string[] { "zero", "two", "four", "six", "eight" };
            //再接著用刪去法，有 o 字的剩下 one、有 h 的剩下 three、f、s、i
            var UnitNumWord2 = new string[] { "one", "three", "five", "seven", "nine" };
            var DictS = new Dictionary<char, int>();
            foreach (var CharOfS in s)
            {
                if (DictS.ContainsKey(CharOfS))
                {
                    DictS[CharOfS]++;
                }
                else
                {
                    DictS.Add(CharOfS, 1);
                }
            }
            for (int i = 0; i < 5; i++)
            {
                if (DictS.ContainsKey(UnitChar[i]) && DictS[UnitChar[i]] > 0)
                {
                    Result.Add(UnitNum[i]);
                    foreach (char c in UnitNumWord[i])
                    {
                        if (DictS.ContainsKey(c)) DictS[c]--;
                    }
                    i--;
                }
            }
            for (int i = 0; i < 5; i++)
            {
                if (DictS.ContainsKey(UnitChar2[i]) && DictS[UnitChar2[i]] > 0)
                {
                    Result.Add(UnitNum2[i]);
                    foreach (char c in UnitNumWord2[i])
                    {
                        if (DictS.ContainsKey(c)) DictS[c]--;
                    }
                    i--;
                }
            }
            return String.Join("", Result.OrderBy(x => x));
        }
    }
}
