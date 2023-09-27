using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class SolutionRomanToInt
    {
        public int RomanToInt(string s)
        {
            string[] SplitRoman = new string[s.Length];
            int ResultNum = 0;
            for (int i = 0; i < s.Length; i++)
            {
                SplitRoman[i] += s.Substring(i, 1);
                switch (s.Substring(i, 1))
                {
                    case "I":
                        if (i + 1 < s.Length && s.Substring(i + 1, 1) == "V")
                        {
                            ResultNum += 4;
                            i++;
                            break;
                        }
                        else if (i + 1 < s.Length && s.Substring(i + 1, 1) == "X")
                        {
                            ResultNum += 9;
                            i++;
                            break;
                        }
                        else
                        {
                            ResultNum += 1;
                            break;
                        }
                    case "V":
                        ResultNum += 5;
                        break;
                    case "X":
                        if (i + 1 < s.Length && s.Substring(i + 1, 1) == "L")
                        {
                            ResultNum += 40;
                            i++;
                            break;
                        }
                        else if (i + 1 < s.Length && s.Substring(i + 1, 1) == "C")
                        {
                            ResultNum += 90;
                            i++;
                            break;
                        }
                        else
                        {
                            ResultNum += 10;
                            break;
                        }
                    case "L":
                        ResultNum += 50;
                        break;
                    case "C":
                        if (i + 1 < s.Length && s.Substring(i + 1, 1) == "D")
                        {
                            ResultNum += 400;
                            i++;
                            break;
                        }
                        else if (i + 1 < s.Length && s.Substring(i + 1, 1) == "M")
                        {
                            ResultNum += 900;
                            i++;
                            break;
                        }
                        else
                        {
                            ResultNum += 100;
                            break;
                        }
                    case "D":
                        ResultNum += 500;
                        break;
                    case "M":
                        ResultNum += 1000;
                        break;
                }
            }

            if (ResultNum <= 3999)
            {
                return ResultNum;
            }
            else
            {
                return 0;
            }
        }
    }
    public class SolutionRomanToInt3
    {
        public int RomanToInt(string s)
        {
            string[] SplitRoman = new string[s.Length];
            int StringLength = s.Length;
            int ResultNum = 0;
            for (int i = 0; i < StringLength; i++)
            {
                SplitRoman[i] += s.Substring(i, 1);
                switch (s.Substring(i, 1))
                {
                    case "I":
                        if (i + 1 < StringLength && s.Substring(i + 1, 1) == "V")
                        {
                            ResultNum += 4;
                            i++;
                            break;
                        }
                        else if (i + 1 < StringLength && s.Substring(i + 1, 1) == "X")
                        {
                            ResultNum += 9;
                            i++;
                            break;
                        }
                        else
                        {
                            ResultNum += 1;
                            break;
                        }
                    case "V":
                        ResultNum += 5;
                        break;
                    case "X":
                        if (i + 1 < StringLength && s.Substring(i + 1, 1) == "L")
                        {
                            ResultNum += 40;
                            i++;
                            break;
                        }
                        else if (i + 1 < StringLength && s.Substring(i + 1, 1) == "C")
                        {
                            ResultNum += 90;
                            i++;
                            break;
                        }
                        else
                        {
                            ResultNum += 10;
                            break;
                        }
                    case "L":
                        ResultNum += 50;
                        break;
                    case "C":
                        if (i + 1 < StringLength && s.Substring(i + 1, 1) == "D")
                        {
                            ResultNum += 400;
                            i++;
                            break;
                        }
                        else if (i + 1 < StringLength && s.Substring(i + 1, 1) == "M")
                        {
                            ResultNum += 900;
                            i++;
                            break;
                        }
                        else
                        {
                            ResultNum += 100;
                            break;
                        }
                    case "D":
                        ResultNum += 500;
                        break;
                    case "M":
                        ResultNum += 1000;
                        break;
                }
            }
            return ResultNum;
        }
    }
    public class SolutionRomanToInt2
    {
        public int RomanToInt(string s)
        {
            string[] SplitRoman = new string[s.Length];
            int StringLength = s.Length;
            int ResultNum = 0;

            for (int i = 0; i < StringLength; i++)
            {
                string TargetWord = s.Substring(i, 1);
                string TargetWord2 = "";
                if (i + 1 < StringLength)
                {
                    TargetWord2 = s.Substring(i + 1, 1);
                }
                SplitRoman[i] += TargetWord;
                switch (TargetWord)
                {
                    case "I":
                        if (i + 1 < StringLength && TargetWord2 == "V")
                        {
                            ResultNum += 4;
                            i++;
                            break;
                        }
                        else if (i + 1 < StringLength && TargetWord2 == "X")
                        {
                            ResultNum += 9;
                            i++;
                            break;
                        }
                        else
                        {
                            ResultNum += 1;
                            break;
                        }
                    case "V":
                        ResultNum += 5;
                        break;
                    case "X":
                        if (i + 1 < StringLength && TargetWord2 == "L")
                        {
                            ResultNum += 40;
                            i++;
                            break;
                        }
                        else if (i + 1 < StringLength && TargetWord2 == "C")
                        {
                            ResultNum += 90;
                            i++;
                            break;
                        }
                        else
                        {
                            ResultNum += 10;
                            break;
                        }
                    case "L":
                        ResultNum += 50;
                        break;
                    case "C":
                        if (i + 1 < StringLength && TargetWord2 == "D")
                        {
                            ResultNum += 400;
                            i++;
                            break;
                        }
                        else if (i + 1 < StringLength && TargetWord2 == "M")
                        {
                            ResultNum += 900;
                            i++;
                            break;
                        }
                        else
                        {
                            ResultNum += 100;
                            break;
                        }
                    case "D":
                        ResultNum += 500;
                        break;
                    case "M":
                        ResultNum += 1000;
                        break;
                }
            }
            return ResultNum;
        }
    }
    public class SolutionRomanToInt5
    {
        public int RomanToInt(string s)
        {
            int ResultNum = 0;
            int StringLength = s.Length;
            Dictionary<string, int> RomanTrans = new()
            {
                { "I", 1 },
                { "V", 5 },
                { "X", 10 },
                { "L", 50 },
                { "C", 100 },
                { "D", 500 },
                { "M", 1000 }
            };
            for (int i = 0; i < StringLength; i++)
            {
                string TargetWord = s.Substring(i, 1);
                ResultNum += RomanTrans[TargetWord];
                switch (TargetWord)
                {
                    case "I":
                        if (i + 1 < StringLength && s.Substring(i + 1, 1) == "V")
                        {
                            ResultNum += 3;
                            i++;
                        }
                        else if (i + 1 < StringLength && s.Substring(i + 1, 1) == "X")
                        {
                            ResultNum += 8;
                            i++;
                        }
                        break;
                    case "X":
                        if (i + 1 < StringLength && s.Substring(i + 1, 1) == "L")
                        {
                            ResultNum += 30;
                            i++;
                        }
                        else if (i + 1 < StringLength && s.Substring(i + 1, 1) == "C")
                        {
                            ResultNum += 80;
                            i++;
                        }
                        break;
                    case "C":
                        if (i + 1 < StringLength && s.Substring(i + 1, 1) == "D")
                        {
                            ResultNum += 300;
                            i++;
                        }
                        else if (i + 1 < StringLength && s.Substring(i + 1, 1) == "M")
                        {
                            ResultNum += 800;
                            i++;
                        }
                        break;
                }
            }
            return ResultNum;
        }
    }
    public class SolutionRomanToInt4
    {
        public int RomanToInt(string s)
        {
            int ResultNum = 0;
            Dictionary<string, int> RomanTrans = new()
            {
                { "I", 1 },
                { "V", 5 },
                { "X", 10 },
                { "L", 50 },
                { "C", 100 },
                { "D", 500 },
                { "M", 1000 }
            };
            for (int i = 0; i < s.Length; i++)
            {
                RomanTrans.TryGetValue(s.Substring(i, 1), out int num);
                ResultNum += num;
                if (i > 0)
                {
                    RomanTrans.TryGetValue(s.Substring(i - 1, 1), out int num2);
                    if (num > num2)
                    {
                        ResultNum -= 2 * num2;
                    }
                }
            }
            return ResultNum;
        }
    }
    public class SolutionRomanToIntBestWay
    {
        public int RomanToInt(string s)
        {
            Dictionary<char, int> RomanTrans = new()
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 }
            };
            int ResultNum = RomanTrans[s[0]], Before = ResultNum;
            for (int i = 1; i < s.Length; i++)
            {
                int First = RomanTrans[s[i]];
                ResultNum += First;
                if (First > Before)
                {
                    ResultNum -= 2 * Before;
                }
                Before = First;
            }
            return ResultNum;
        }
    }
}
