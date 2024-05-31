using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class UniqueSubstringsInWraparoundString
    {
        public int FindSubstringInWraproundString(string s)
        {
            //太慢
            var Result = new HashSet<string>();
            for (int i = 0; i < s.Length; i++)
            {
                Result.Add("" + s[i]);
                Result = ToAddOrNot(Result, s, i, i + 1);
            }
            return Result.Count;
        }
        public HashSet<string> ToAddOrNot(HashSet<string> Result, string s, int start, int now)
        {
            for (int i = now; i < s.Length; i++)
            {
                if (s[i - 1] == 'z')
                {
                    if (s[i] == 'a')
                    {
                        Result.Add(s.Substring(start, now - start + 1));
                    }
                }
                else
                {
                    if (s[i] == s[i - 1] + 1)
                    {
                        Result.Add(s.Substring(start, now - start + 1));
                    }
                }
                Result = ToAddOrNot(Result, s, start, now + 1);
            }
            return Result;
        }

        public int FindSubstringInWraproundString2(string s)
        {
            //會超時
            var Result = new HashSet<string>();
            for (int i = 0; i < s.Length; i++)
            {
                Result.Add("" + s[i]);
                for (int j = i + 1; j < s.Length; j++)
                {
                    if (s[j - 1] == 'z')
                    {
                        if (s[j] == 'a')
                        {
                            Result.Add(s.Substring(i, j - i + 1));
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        if (s[j] == s[j - 1] + 1)
                        {
                            Result.Add(s.Substring(i, j - i + 1));
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            return Result.Count;
        }
        public int FindSubstringInWraproundStringFail(string s)
        {
            //每當找出 n 個連續字串，就可以確保能切割成 n! 個子字串
            //所以可以先找出最長的連續字串有幾組，再看這幾組有誰有交集
            //把交集的子字串排掉，再算 n!
            //失敗原因：不見得是 n!，會有重疊的
            int Result = 0;
            var ResultTemplate = new HashSet<string>();
            for (int i = 0; i < s.Length;)
            {
                var temp = new StringBuilder();
                temp.Append(s[i]);
                int j;
                var ToInput = true;
                for (j = i + 1; j < s.Length; j++)
                {
                    if (s[j - 1] == 'z')
                    {
                        if (s[j] == 'a')
                        {
                            temp.Append(s[j]);
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        if (s[j] == s[j - 1] + 1)
                        {
                            temp.Append(s[j]);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                i += j;
                foreach (var Candidate in ResultTemplate)
                {
                    if (Candidate.Contains(temp.ToString()) || Candidate == temp.ToString())
                    {
                        ToInput = false;
                        break;
                    }
                }
                if (ToInput) ResultTemplate.Add(temp.ToString());
            }
            //最後階乘相加
            foreach (var Candidate in ResultTemplate)
            {
                //階乘
                int temp = 1;
                for (int i = 1; i <= Candidate.Length; i++)
                {
                    temp *= i;
                }
                Result += temp;
            }
            return Result;
        }

        public int FindSubstringInWraproundString3(string s)
        {
            //只要找出每個字母開頭，最大長度字串
            //代表該字母開頭，有可能的字串組數
            //之後把 26 個字母都統計進去就行了
            var Result = new int[26];
            int MaxLenTemp = 1;
            Result[s[0] - 'a'] = 1;
            for (int i = 1; i < s.Length; i++)
            {
                //a => b || z => a
                if (s[i] == s[i - 1] + 1 || s[i] == s[i - 1] - 25)
                {
                    MaxLenTemp++;
                }
                else
                {
                    MaxLenTemp = 1;
                }
                Result[s[i] - 'a'] = Math.Max(MaxLenTemp, Result[s[i] - 'a']);
            }
            return Result.Sum();
        }
    }
}
