using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class SolutionLongestCommonPrefix
    {
        public string LongestCommonPrefix1(string[] strs)
        {
            char[] CharArray = strs[0].ToCharArray();
            for (int i = 1; i < strs.Length; i++)
            {
                int TarArrayLength = CharArray.Length;
                int j = 0;
                foreach (char CompareC in strs[i].ToCharArray())
                {
                    if (j < TarArrayLength)
                    {
                        if (CompareC == CharArray[j])
                        {
                            j++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                Array.Clear(CharArray, j, TarArrayLength - j);
            }
            return new string(CharArray).Trim('\0');
        }
    }
}
