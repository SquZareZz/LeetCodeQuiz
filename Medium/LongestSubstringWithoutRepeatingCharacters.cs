using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class LongestSubstringWithoutRepeatingCharacters
    {
        public int LengthOfLongestSubstring_SlowlyStringFun(string s)
        {
            string Result = "";
            int Len = s.Length;
            for (int i = 0; i < Len; i++)
            {

                string temp = "" + s[i];
                for (int j = i + 1; j < Len; j++)
                {
                    if (!temp.Contains(s[j]))
                    {
                        temp += s[j];
                    }
                    else
                    {
                        break;
                    }
                }
                if (temp.Length > Result.Length)
                {
                    Result = temp;
                    if (Result.Length > Len - i)
                    {
                        break;
                    }
                }
            }
            return Result.Length;
        }
        public int LengthOfLongestSubstring_SlowlyDictFun(string s)
        {
            int Result = 0, Len = s.Length;
            for (int i = 0; i < Len; i++)
            {
                var DictS = new Dictionary<char, int>();
                foreach (char c in s.Substring(i, Len - i))
                {
                    if (!DictS.ContainsKey(c))
                    {
                        DictS.Add(c, 0);
                    }
                    else
                    {
                        break;
                    }
                }
                Result = Math.Max(Result, DictS.Count);
            }
            return Result;
        }
        public int LengthOfLongestSubstring3(string s)
        {
            BitArray RecordLight = new BitArray(128, false);//字元在ASCII的編碼是32~127
            int Result = 0, Len = s.Length, First = 0, Second = 0;
            for (int i = 0; i < Len; i++)
            {
                while (First < Len)
                {
                    //判定它在map裡面有沒有記錄到、出現過
                    if (RecordLight[s[First]])
                    {
                        Result = Math.Max(Result, First - Second);//比較大的時候刷新紀錄
                        while (s[Second] != s[First])
                        {
                            RecordLight[s[Second]] = false;
                            Second++;
                        }
                        //掃過一次以後，起始點改變
                        First++;
                        Second++;
                    }
                    else//沒出現過把它點亮
                    {
                        RecordLight[s[First]] = true;
                        First++;
                    }
                }
                Result = Math.Max(Result, First - Second);
            }
            return Result;
        }
    }
}
