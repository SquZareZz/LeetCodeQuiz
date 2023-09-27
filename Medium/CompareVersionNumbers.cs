using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class CompareVersionNumbers
    {
        public int CompareVersionFail(string version1, string version2)
        {
            string[] SplitVer1 = version1.Split('.');
            string[] SplitVer2 = version2.Split(".");
            if (Int32.Parse(SplitVer1[0]) > Int32.Parse(SplitVer2[0]))
            {
                return 1;
            }
            else if (Int32.Parse(SplitVer1[0]) < Int32.Parse(SplitVer2[0]))
            {
                return -1;
            }
            else
            {
                if (SplitVer2.Length > SplitVer1.Length && SplitVer2[SplitVer2.Length - 1] != "0")
                {
                    return -1;
                }
                else if (SplitVer2.Length < SplitVer1.Length && SplitVer1[SplitVer1.Length - 1] != "0")
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
        public int CompareVersion(string version1, string version2)
        {
            string[] SplitVer1 = version1.Split('.');
            string[] SplitVer2 = version2.Split(".");
            int Len1 = SplitVer1.Length, Len2 = SplitVer2.Length;
            int MaxLength = Math.Max(Len1, Len2);
            for (int i = 0; i < MaxLength; i++)
            {
                if (i == Len1)
                {
                    return SplitVer2.Skip(i).Where(x => Int32.Parse(x) == 0).Count() == Len2 - i ? 0 : -1;
                }
                else if (i == Len2)
                {
                    return SplitVer1.Skip(i).Where(x => Int32.Parse(x) == 0).Count() == Len1 - i ? 0 : 1;
                }

                if (Int32.Parse(SplitVer1[i]) == Int32.Parse(SplitVer2[i]))
                {
                    continue;
                }
                else if (Int32.Parse(SplitVer1[i]) > Int32.Parse(SplitVer2[i]))
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            return 0;
        }
    }
}
