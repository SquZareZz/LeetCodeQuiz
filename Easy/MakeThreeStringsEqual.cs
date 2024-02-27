using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class MakeThreeStringsEqual
    {
        public int FindMinimumOperations(string s1, string s2, string s3)
        {
            int result = 0;
            if (s1 == s2 && s1 == s3)
            {
                return result;
            }
            int[] TempLen = new int[3];
            TempLen[0] = s1.Length;
            TempLen[1] = s2.Length;
            TempLen[2] = s3.Length;
            while ((s1 != s2 || s1 != s3) && TempLen.Count(x => x <= 1) != 3)
            {
                int MaxLen = TempLen.Max();
                if (TempLen[0] == MaxLen)
                {
                    if (TempLen[0] < 2) break;
                    s1 = s1.Substring(0, TempLen[0] - 1);
                    TempLen[0]--;
                }
                else if (TempLen[1] == MaxLen)
                {
                    if (TempLen[1] < 2) break;
                    s2 = s2.Substring(0, TempLen[1] - 1);
                    TempLen[1]--;
                }
                else if (TempLen[2] == MaxLen)
                {
                    if (TempLen[2] < 2) break;
                    s3 = s3.Substring(0, TempLen[2] - 1);
                    TempLen[2]--;
                }
                result++;
                if (s1 == s2 && s1 == s3)
                {
                    return result;
                }
            }
            return (s1 == s2 && s1 == s3) ? result : -1;
        }
    }
}
