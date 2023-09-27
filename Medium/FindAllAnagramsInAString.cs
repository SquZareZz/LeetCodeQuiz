using MathNet.Numerics.Distributions;
using NPOI.SS.UserModel;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class FindAllAnagramsInAString
    {
        public IList<int> FindAnagramsFail(string s, string p)
        {
            //太慢
            int TarLen = p.Length, LenS = s.Length;
            var Result = new List<int>();
            var Statistics = new int[26];
            foreach (var CharOfP in p)
            {
                Statistics[CharOfP - 'a']++;
            }
            for (int i = 0; i < LenS - TarLen + 1; i++)
            {
                bool Check = true;
                var TempStatistic = Statistics.ToArray();
                for (int j = i; j < i + TarLen; j++)
                {
                    if (TempStatistic[s[j] - 'a'] <= 0)
                    {
                        Check = false;
                        break;
                    }
                    else
                    {
                        TempStatistic[s[j] - 'a']--;
                    }
                }
                if (Check)
                {
                    Result.Add(i);
                }
            }
            return Result;
        }
        public IList<int> FindAnagrams(string s, string p)
        {
            int TarLen = p.Length, LenS = s.Length;
            var Result = new List<int>();
            var Statistics = new int[26];
            foreach (var CharOfP in p)
            {
                Statistics[CharOfP - 'a']++;
            }
            for (int i = 0; i < LenS - TarLen + 1; i++)
            {
                bool Check = true;
                var TempStatistic = Statistics.ToArray();
                for (int j = i; j < i + TarLen; j++)
                {
                    if (TempStatistic[s[j] - 'a'] == 0)
                    {
                        Check = false;
                        break;
                    }
                    else
                    {
                        TempStatistic[s[j] - 'a']--;
                    }
                }
                if (Check)
                {
                    Result.Add(i);
                }
            }
            return Result;
        }
    }
}
