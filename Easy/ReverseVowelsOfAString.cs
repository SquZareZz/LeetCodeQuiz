using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class ReverseVowelsOfAString
    {
        //不懂問這個芭樂意義在哪裡
        //=> 先用 Stack 記錄所有母音位置，依照 Stack 先進後出特性，重新列出來即為答案
        public string ReverseVowelsFail(string s)
        {
            var DicS = new Dictionary<int, char>();
            int DicNo = 0;
            string ReturnStr = "";
            int TarLen = s.Length;
            for (int i = 0; i < TarLen; i++)
            {
                char c = char.ToLower(s[i]);
                if (!DicS.ContainsKey(c))
                {
                    if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
                    {
                        DicS.Add(DicNo, s[i]);
                        DicNo++;
                    }
                }
            }
            for (int i = 0; i < TarLen; i++)
            {
                if (s[i] == DicS[0])
                {
                    ReturnStr += DicS[1];
                }
                else if (s[i] == DicS[1])
                {
                    ReturnStr += DicS[0];
                }
                else
                {
                    ReturnStr += s[i];
                }
            }
            return ReturnStr;
        }
        public string ReverseVowelsFail2(string s)
        {
            int StartArrow = 0;
            int TarLen = s.Length;
            int EndArrow = TarLen - 1;
            while (StartArrow < EndArrow)
            {
                while (!"AEIOUaeiou".Contains(s[StartArrow]) || s[StartArrow] == s[StartArrow + 1])
                {
                    StartArrow++;
                    if (StartArrow + 1 >= TarLen)
                    {
                        break;
                    }
                }
                while (!"AEIOUaeiou".Contains(s[EndArrow]) || s[StartArrow] == s[EndArrow])
                {
                    EndArrow--;
                    if (EndArrow < 0)
                    {
                        break;
                    }
                }
                if (StartArrow < EndArrow)
                {
                    return s.Substring(0, StartArrow) + s[EndArrow] +
                     s.Substring(StartArrow + 1, EndArrow - StartArrow - 1) + s[StartArrow] + s.Substring(EndArrow + 1, TarLen - EndArrow - 1);
                }
            }
            return s;
        }

        public string ReverseVowels(string s)
        {
            var VowelIndex = new Stack<char>();
            var Result = new StringBuilder();
            foreach (var c in s)
            {
                if ("AEIOUaeiou".Contains(c))
                {
                    VowelIndex.Push(c);
                }
            }
            foreach (var c in s)
            {
                if ("AEIOUaeiou".Contains(c))
                {
                    Result.Append(VowelIndex.Pop());
                }
                else
                {
                    Result.Append(c);
                }
            }
            return Result.ToString();
        }
    }
}
