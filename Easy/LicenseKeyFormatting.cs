using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class LicenseKeyFormatting
    {
        public string LicenseKeyFormatting1(string s, int k)
        {
            string Result = "";
            int TarLen = string.Join("", s.Where(x => x != '-')).Length % k;
            switch (TarLen)
            {
                case 0:
                    Result = ResetKeyStr(s, Result, k).Trim('-');
                    break;
                default:
                    int CountK = 0;
                    string Temp2 = "";
                    while (CountK < TarLen)
                    {
                        if (s[CountK] != '-')
                        {
                            Temp2 += s[CountK];
                        }
                        else
                        {
                            TarLen++;
                        }
                        CountK++;
                    }
                    Result += Temp2 + "-";
                    s = s.Substring(TarLen, s.Length - TarLen);
                    Result = ResetKeyStr(s, Result, k).Trim('-');
                    break;
            }
            return Result.ToUpper();
        }
        public string LicenseKeyFormatting2(string s, int k)
        {
            s = string.Join("", s.Where(x => x != '-'));//== s = s.Replace(@"-", "");
            string Result = "";
            int TarLen = s.Length % k;
            switch (TarLen)
            {
                case 0:
                    for (int i = 0; i < s.Length / k; i++)
                    {
                        Result += s.Substring(i * k, k) + "-";
                    }
                    Result = Result.Trim('-');
                    break;
                default:
                    Result += s.Substring(0, TarLen) + "-";
                    for (int i = 0; i < s.Length / k; i++)
                    {
                        Result += s.Substring(i * k + TarLen, k) + "-";
                    }
                    Result = Result.Trim('-');
                    break;
            }
            return Result.ToUpper();
        }
        public string LicenseKeyFormatting3(string s, int k)
        {
            string Result = "", Temp = "";
            int CountK = 0;
            for (int i = s.Length - 1; i > -1; i--)
            {
                if (s[i] != '-')
                {
                    Temp = s[i] + Temp;
                    CountK++;
                }
                if (CountK == k)
                {
                    Result = Temp + "-" + Result;
                    Temp = ""; CountK = 0;
                }
            }
            Result = (Temp + "-" + Result).Trim('-');

            return Result.ToUpper();
        }
        public string LicenseKeyFormatting4(string s, int k)
        {
            string Result = "";
            int CountK = 0;
            for (int i = s.Length - 1; i > -1; i--)
            {
                char c = s[i];
                if (c != '-')
                {
                    Result = c + Result;
                    CountK++;
                    if (CountK == k)
                    {
                        Result = "-" + Result;
                        CountK = 0;
                    }
                }
            }
            Result = Result.Trim('-');
            return Result.ToUpper();
        }
        public string LicenseKeyFormatting5(string s, int k)
        {
            string Result = "";
            s = s.Replace(@"-", "");
            int Count = 0, Len = s.Length;
            for (int i = Len - k; i > -1; i -= k)
            {
                if (i + k > k)
                {
                    Result = "-" + s.Substring(i, k) + Result;
                    Count += k;
                }
            }
            Result = s.Substring(0, Len - Count) + Result;
            return Result.ToUpper();
        }
        public string LicenseKeyFormatting6(string s, int k)
        {

            s = s.Replace(@"-", "");
            int Len = s.Length;
            int Count = 0;
            while (Count < Len)
            {
                switch (Count)
                {
                    case 0:
                        Count += Len % k;
                        break;
                    default:
                        Count += k;
                        break;
                }
                s = s.Insert(Count, "-");
                Count++;
                Len++;
            }
            return s.Trim('-').ToUpper();
        }
        public string ResetKeyStr(string s, string Result, int k)
        {
            int CountK = 1;
            string Temp2 = "";
            foreach (char t in s)
            {
                if (t != '-')
                {
                    if (CountK < k)
                    {
                        Temp2 += t;
                        CountK++;
                    }
                    else
                    {
                        Result += Temp2 + t + "-";
                        Temp2 = "";
                        CountK = 1;
                    }
                }
            }
            return Result;
        }
    }
}
