using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class RepeatedSubstringPattern
    {
        public bool RepeatedSubstringPatternFail(string s)
        {
            if (s.Length == 1)
            {
                return false;
            }
            else
            {
                char Head = s[0];
                string Result = "" + Head;
                int i = 1;
                while (Head != s[i])
                {
                    Result += s[i];
                    i++;
                }
                int LenRe = Result.Length;
                int LenS = s.Length;
                for (int j = LenRe - 1; j < LenS - 1;)
                {
                    if (LenS - 1 - j >= LenRe)
                    {
                        if (s.Substring(j + 1, LenRe) != Result)
                        {
                            return false;
                        }
                        else
                        {
                            j += LenRe;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        public bool RepeatedSubstringPatternSlowly(string s)
        {
            if (s.Length == 1)
            {
                return false;
            }
            else
            {
                string Result;
                for (int i = 1; i < s.Length / 2 + 1; i++)
                {
                    Result = s.Substring(0, i);
                    int LenRe = Result.Length;
                    int LenS = s.Length - 1;
                    for (int j = LenRe - 1; j < LenS;)
                    {
                        if (LenS - j >= LenRe)
                        {
                            if (s.Substring(j + 1, LenRe) != Result)
                            {
                                break;
                            }
                            else if (s.Substring(j + 1, LenRe) == Result && LenS - j == LenRe)
                            {
                                return true;
                            }
                            else
                            {
                                j += LenRe;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                return false;
            }
        }
        public bool RepeatedSubstringPatternFastest(string s)
        {
            int LenS = s.Length;
            for (int i = LenS / 2; i > 0; i--)//極限一定是一半的字串
            {
                if (LenS % i == 0)//無法整除不往下考慮
                {
                    string Result = s.Substring(0, i);//拿第一個跟後續幾個比
                    //如果比到最後一號分割都還相同=>終止+回傳
                    //如果比到一半不同，直接跳出
                    for (int j = i; j <= LenS; j += i)
                    {
                        if (Result == s.Substring(j, i) && j + i == LenS)
                        {
                            return true;
                        }
                        else if (Result != s.Substring(j, i))
                        {
                            break;
                        }
                    }
                }
            }
            return false;
        }
    }
}
