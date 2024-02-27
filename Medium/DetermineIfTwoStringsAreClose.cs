using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class DetermineIfTwoStringsAreClose
    {
        public bool CloseStrings(string word1, string word2)
        {
            //字元長度不等，絕對不會成功
            if (word1.Length != word2.Length)
            {
                return false;
            }
            var DictW1 = new Dictionary<char, int>();
            var DictW2 = new Dictionary<char, int>();
            //統計兩組字串出現過的字元
            foreach (var c in word1)
            {
                if (DictW1.ContainsKey(c))
                {
                    DictW1[c] += 1;
                }
                else
                {
                    DictW1[c] = 1;
                }
            }
            foreach (var c in word2)
            {
                if (DictW2.ContainsKey(c))
                {
                    DictW2[c] += 1;
                }
                else
                {
                    DictW2[c] = 1;
                }
            }

            foreach (var Now in DictW1)
            {
                if (!DictW2.ContainsKey(Now.Key) || DictW2[Now.Key] != Now.Value)
                {
                    var Judge = DictW2.Where(x => x.Value == Now.Value);
                    if (Judge.Count() > 0)
                    {
                        bool Success = false;
                        //如果有字元數對得上的，必須確認原始字串有對應字母，才允許交換
                        foreach (var CanChange in Judge)
                        {
                            if (DictW1.ContainsKey(CanChange.Key))
                            {
                                DictW2.Remove(Judge.First().Key);
                                Success = true;
                                break;
                            }
                        }
                        if (!Success)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                //如果有對的上的字母，直接移除
                else
                {
                    DictW2.Remove(Now.Key);
                }
            }
            return true;
        }
    }
}
