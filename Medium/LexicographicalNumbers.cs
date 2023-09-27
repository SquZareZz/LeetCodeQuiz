using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class LexicographicalNumbers
    {
        public IList<int> LexicalOrderFail(int n)
        {
            var Result = new List<int>();
            var DictNums = new Dictionary<int, int>();
            int KeyNum = (int)Math.Log10(n);
            int[] CountList = new int[10];
            for (int i = 1; i < n + 1; i++)
            {
                var temp = i.ToString();
                int ToAdd = (temp[0] - 48) % 10;
                DictNums.Add(i, (ToAdd - 1) * (int)Math.Pow(10, KeyNum) + CountList[ToAdd]);
                CountList[ToAdd]++;
            }
            var ResultTemp = from entry
                             in DictNums
                             orderby entry.Value
                             ascending
                             select entry;
            foreach (var temp in ResultTemp)
            {
                Result.Add(temp.Key);
            }
            return Result;
        }
        public IList<int> LexicalOrder(int n)
        {
            var ResultTemp = new List<string>();
            var Result = new List<int>();
            for (int i = 1; i < n+1; i++)
            {
                ResultTemp.Add(i.ToString());
            }
            ResultTemp = ResultTemp.OrderBy(x => x).ThenBy(x => x.Length).ToList();
            return ResultTemp.Select(x => Int32.Parse(x)).ToList();
        }
    }
}
