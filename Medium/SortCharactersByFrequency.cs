using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class SortCharactersByFrequency
    {
        public string FrequencySort(string s)
        {
            var DictS=new Dictionary<char, int>();
            foreach(var CharS in s)
            {
                if (DictS.ContainsKey(CharS))
                {
                    DictS[CharS]++;
                }
                else
                {
                    DictS.Add(CharS, 1);
                }
            }
            var ResultList = DictS.OrderByDescending(x => x.Value).Select(x => x.Key);
            var Result = "";
            foreach (var ResultItem in ResultList)
            {
                Result += String.Concat(Enumerable.Repeat(ResultItem.ToString(), DictS[ResultItem]));
            }
            return Result;
        }
    }
}
