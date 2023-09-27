using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class GroupAnagrams
    {
        public IList<IList<string>> GroupAnagrams1(string[] strs)
        {
            var Result = new List<IList<string>>();
            var DictStrs = new Dictionary<string, List<string>>();
            foreach (var str in strs)
            {
                string temp = string.Concat(str.OrderBy(c => c));
                if (!DictStrs.ContainsKey(temp))
                {
                    DictStrs.Add(temp, new List<string>() { str });
                }
                else
                {
                    DictStrs[temp].Add(str);
                }
            }
            foreach (var ToTrans in DictStrs)
            {
                Result.Add(ToTrans.Value);
            }
            return Result;
        }
    }
}
