using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class CountBinarySubstrings
    {
        public int CountBinarySubstringsFail(string s)
        {
            int Result = 0; bool Duplicate = false;

            for (int i = 0; i < s.Length - 1; i++)
            {
                char TarTemp = s[i];
                int DuplicateCount = 1;
                int NoDuplicate = 0;
                for (int j = i + 1; j < s.Length; j++)
                {
                    switch (Duplicate)
                    {
                        case true://重複

                            if (s[j] == TarTemp)
                            {
                                if (NoDuplicate != 0)
                                {
                                    Result += NoDuplicate >= DuplicateCount ? 1 : 0;
                                    j = s.Length - 1;//跳出去
                                    if (NoDuplicate > 1)
                                    {
                                        i += NoDuplicate - 2;
                                    }
                                    break;
                                }
                                DuplicateCount++;
                            }
                            else
                            {
                                NoDuplicate++;
                                if (NoDuplicate >= DuplicateCount)
                                {
                                    Result++;
                                    j = s.Length - 1;//跳出去
                                    break;
                                }
                            }
                            break;
                        case false://不重複或還沒偵測到重覆
                            if (s[j] != TarTemp)
                            {
                                Result++;
                                j = s.Length - 1;//跳出去
                            }
                            else
                            {
                                Duplicate = true;
                                DuplicateCount++;
                            }
                            break;
                    }

                }
                Duplicate = false;
            }
            return Result;
        }
        public int CountBinarySubstrings1(string s)
        {
            //如果變號，直到前面數字被補滿前，都能在該號找得到配對
            //所以記錄前一號重覆幾個，接下來再重複N個或變號前，都找得到配對
            int Result = 0, before = 0, cur = 1;
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == s[i - 1])
                {
                    cur++;
                }
                else
                {
                    before = cur;
                    cur = 1;
                }
                if (before >= cur)
                {
                    Result++;
                }
            }
            return Result;
        }
    }
}
