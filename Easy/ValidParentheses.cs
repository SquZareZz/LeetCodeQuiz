using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class ValidParentheses
    {
        public bool IsValidFail(string s)
        {
            Dictionary<char, int> ParenthesesBool = new()
            {
                { '(', 1 },
                { ')', 2 },
                { '[', 3 },
                { ']', 4 },
                { '{', 5 },
                { '}', 6 }
            };
            int TarLength = s.Length;
            int[] Lock1 = new int[2]; int[] Lock2 = new int[2]; int[] Lock3 = new int[2];
            if (TarLength > 1)
            {
                for (int i = 0; i < TarLength; i++)
                {
                    ParenthesesBool.TryGetValue(s[i], out int JudgeRes);
                    if (JudgeRes % 2 != 0)
                    {
                        switch (JudgeRes)
                        {
                            case 1:
                                Lock1[0] = i + 1;
                                continue;
                            case 3:
                                Lock2[0] = i + 1;
                                continue;
                            case 5:
                                Lock3[0] = i + 1;
                                continue;
                        }
                    }
                    else
                    {
                        int JudgeRes2 = JudgeRes / 2;
                        switch (JudgeRes2)
                        {
                            case 1:
                                if (Lock1[0] != 0)
                                {
                                    Lock1[1] = i + 1;
                                    continue;
                                }
                                else
                                {
                                    return false;
                                }

                            case 2:
                                if (Lock2[0] != 0)
                                {
                                    Lock2[1] = i + 1;
                                    continue;
                                }
                                else
                                {
                                    return false;
                                }
                            case 3:
                                if (Lock3[0] != 0)
                                {
                                    Lock3[1] = i + 1;
                                    continue;
                                }
                                else
                                {
                                    return false;
                                }
                        }
                    }
                }
                if (Lock1[0] > Lock1[1] || Lock2[0] > Lock2[1] || Lock3[0] > Lock3[1])
                {
                    return false;
                }

                //(Lock2[0] == Lock2[1] && Lock2[0] == 0)&&
                //(Lock3[0] == Lock3[1] && Lock3[0] == 0)
                //(Lock2[0] + 1 != Lock2[1] || (Lock2[0] + Lock2[1]) % 7 == 0) ||
                //(Lock3[0] + 1 != Lock3[1] || (Lock3[0] + Lock3[1]) % 11 == 0)
                if (Lock1[0] != Lock1[1] || Lock1[0] != 0)
                {
                    if (Lock1[0] + 1 != Lock1[1] && (Lock1[0] + Lock1[1]) % 3 != 0)
                    {
                        return false;
                    }
                }
                if (Lock2[0] != Lock2[1] || Lock2[0] != 0)
                {
                    if (Lock2[0] + 1 != Lock2[1] && (Lock2[0] + Lock2[1]) % 3 != 0)
                    {
                        return false;
                    }
                }
                if (Lock3[0] != Lock3[1] || Lock3[0] != 0)
                {
                    if (Lock3[0] + 1 != Lock3[1] && (Lock3[0] + Lock3[1]) % 3 != 0)
                    {
                        return false;
                    }
                }

            }
            else
            {
                return false;
            }
            return true;
        }
        public bool IsValidFail2(string s)
        {
            Dictionary<char, int> ParenthesesBool = new()
            {
                { '(', 1 },
                { ')', 2 },
                { '[', 3 },
                { ']', 4 },
                { '{', 5 },
                { '}', 6 }
            };
            int TarLength = s.Length;
            bool Starter = false; int CountSym = 0;
            int[,] Checker = new int[TarLength, 2];
            if (TarLength % 2 != 0)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < TarLength; i++)
                {
                    ParenthesesBool.TryGetValue(s[i], out int JudgeRes);
                    Checker[i, 0] = JudgeRes;
                    if (JudgeRes % 2 != 0)
                    {
                        Starter = true;
                    }
                    else
                    {
                        Starter = false;
                    }
                    if (Starter == true)
                    {
                        CountSym++;
                    }
                    else
                    {
                        CountSym--;

                    }
                    Checker[i, 1] = CountSym;
                }

            }

            return true;
        }
        public bool IsValidFail3(string s)
        {
            Dictionary<char, int> ParenthesesBool = new()
            {
                { '(', 1 },
                { ')', 2 },
                { '[', 3 },
                { ']', 4 },
                { '{', 5 },
                { '}', 6 }
            };

            string sToken = s;
            int TarLength = sToken.Length;
            if (TarLength % 2 != 0)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < TarLength; i++)
                {
                    if (sToken != "")
                    {
                        ParenthesesBool.TryGetValue(sToken[i], out int TargetNo);
                        if (i + 1 < TarLength)
                        {
                            ParenthesesBool.TryGetValue(sToken[i + 1], out int TargetNo2);
                            if (TargetNo + 1 == TargetNo2)
                            {
                                sToken = sToken.Remove(i, 2);
                                i = -1;
                                TarLength = sToken.Length;
                            }
                        }
                    }
                }
                if (sToken != "")
                {
                    return false;
                }
            }

            return true;
        }
        public bool IsValidFail4(string s)
        {
            Dictionary<char, int> ParenthesesBool = new()
            {
                { '(', 1 },
                { ')', 2 },
                { '[', 3 },
                { ']', 4 },
                { '{', 5 },
                { '}', 6 }
            };
            int TarLength = s.Length;
            for (int i = 0; i < TarLength; i++)
            {
                if (s != "")
                {
                    ParenthesesBool.TryGetValue(s[i], out int TargetNo);
                    if (i + 1 < TarLength)
                    {
                        ParenthesesBool.TryGetValue(s[i + 1], out int TargetNo2);
                        if (TargetNo + 1 == TargetNo2)
                        {
                            s = s.Remove(i, 2);
                            i = -1;
                            TarLength = s.Length;
                        }
                    }
                }
            }
            if (s != "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool IsValid3(string s)
        {
            Dictionary<char, char> ParenthesesBool = new()
            {
                { '(', ')' },
                { '[', ']' },
                { '{', '}' },
            };
            int TarLength = s.Length;
            for (int i = 0; i < TarLength; i++)
            {
                if (TarLength > 1 && i < TarLength - 1)
                {
                    switch (s[i])
                    {
                        case '(':
                            ParenthesesBool.TryGetValue(s[i], out char CheckChar);
                            if (CheckChar == s[i + 1])
                            {
                                s = s.Remove(i, 2);
                                i = -1;
                                TarLength = s.Length;
                            }
                            continue;
                        case '[':
                            ParenthesesBool.TryGetValue(s[i], out char CheckChar2);
                            if (CheckChar2 == s[i + 1])
                            {
                                s = s.Remove(i, 2);
                                i = -1;
                                TarLength = s.Length;
                            }
                            continue;
                        case '{':
                            ParenthesesBool.TryGetValue(s[i], out char CheckChar3);
                            if (CheckChar3 == s[i + 1])
                            {
                                s = s.Remove(i, 2);
                                i = -1;
                                TarLength = s.Length;
                            }
                            continue;
                    }
                }
            }
            if (s != "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool IsValidBestWay(string s)
        {
            Dictionary<char, char> dic = new()
            {
                {'}', '{' },
                {']', '[' },
                {')', '(' }
            };

            if (s.Length % 2 == 1)
            {
                return false;
            }
            var stack = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];

                if (dic.ContainsValue(c))
                {
                    stack.Push(c);
                }
                else
                {
                    if (stack.Count == 0)
                        return false;
                    if (stack.Peek() == dic[c])
                        stack.Pop();
                    else if (dic[c] == '(' || dic[c] == '[' || dic[c] == '{')
                        return false;
                }
            }
            return stack.Count == 0;
        }
    }
}
