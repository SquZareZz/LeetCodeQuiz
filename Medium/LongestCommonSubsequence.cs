using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class LongestCommonSubsequence
    {
        public int LongestCommonSubsequence1(string text1, string text2)
        {
            //棋盤法，找出最右下角的值
            //e.g. ABC、ABG
            //_ A B G
            //A 1 1 1
            //B 1 2 2
            //C 1 2 2
            int Len1 = text1.Length, Len2 = text2.Length;
            var Board = new int[Len1 + 1, Len2 + 1];
            for (int i = 1; i <= Len1; i++)
            {
                for (int j = 1; j <= Len2; j++)
                {
                    if (text1[i - 1] == text2[j - 1])
                    {
                        Board[i, j] = Board[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        Board[i, j] = Math.Max(Board[i, j - 1], Board[i - 1, j]);
                    }
                }
            }
            return Board[Len1, Len2];
        }
    }
}
