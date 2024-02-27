using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class GreatestCommonDivisorOfStrings
    {
        public string GcdOfStrings(string str1, string str2)
        {
            //先確認誰當模板、誰當主要
            if (str2.Length > str1.Length) (str1, str2) = (str2, str1);
            //確認主要字串是否涵蓋模板字串
            if (str1.Contains(str2))
            {
                int LimitLen = 1;
                var Pattern = "";
                while (LimitLen <= str2.Length)
                {
                    var ResultArray = new List<string>();
                    //模板長度必須同時是Len2和Len1的倍數
                    if (str2.Length % LimitLen != 0 || str1.Length % LimitLen != 0)
                    {
                        LimitLen++;
                        continue;
                    }
                    for (int i = 0; i < str2.Length;)
                    {
                        ResultArray.Add(str2.Substring(i, LimitLen));
                        i += LimitLen;
                    }
                    //如果每個都一樣，那每一項都會跟第一項一樣，且長度為總長
                    if (ResultArray.Where(x => x == ResultArray[0]).Count() == ResultArray.Count)
                    {
                        Pattern = ResultArray[0];
                    }
                    LimitLen++;
                }
                if (Pattern == "") return "";
                for (int i = 0; i < str1.Length;)
                {
                    if (str1.Substring(i, Pattern.Length) == Pattern)
                    {
                        i += Pattern.Length;
                    }
                    else
                    {
                        return "";
                    }
                }
                return Pattern;
            }
            else
            {
                return "";
            }
        }
    }
}
