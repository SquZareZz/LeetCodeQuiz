using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class MergeStringsAlternately
    {
        public string MergeAlternately(string word1, string word2)
        {
            int i = 0, j = 0;
            var Result = new StringBuilder();
            while (i <= word1.Length && j <= word2.Length)
            {
                if (i < word1.Length)
                {
                    Result.Append(word1[i]);
                    i++;
                }
                if (j < word2.Length)
                {
                    Result.Append(word2[j]);
                    j++;
                }
                if (i == word1.Length && j == word2.Length)
                {
                    break;
                }
            }
            return Result.ToString();  
        }
    }
}
