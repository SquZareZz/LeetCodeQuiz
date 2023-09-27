using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class Repeated_DNA_Sequences
    {
        public IList<string> FindRepeatedDnaSequences(string s)
        {
            var Result = new List<string>();
            var Dict = new Dictionary<string, int>();
            if (s.Length < 10)
            {
                return new List<string>() { };
            }
            for (int i = 9; i < s.Length; i++)
            {
                string Target = s.Substring(0 + i - 9, 10);
                if (!Dict.ContainsKey(Target))
                {
                    Dict.Add(Target, 1);
                }
                else
                {
                    Dict[Target]++;
                }
            }
            foreach (var temp in Dict)
            {
                if (temp.Value > 1)
                {
                    Result.Add(temp.Key);
                }
            }
            return Result;
        }
        public IList<string> FindRepeatedDnaSequences2(string s)
        {
            var Dict = new Dictionary<string, int>();
            if (s.Length < 10)
            {
                return new List<string>() { };
            }
            for (int i = 9; i < s.Length; i++)
            {
                string Target = s.Substring(0 + i - 9, 10);
                if (!Dict.ContainsKey(Target))
                {
                    Dict.Add(Target, 1);
                }
                else
                {
                    Dict[Target]++;
                }
            }
            int[] a = { 1, 2, 3, 4, 5, 6 };
            (a[1], a[3]) = (a[3],a[1]);
            return Dict.Where(x => x.Value > 1).Select(x => x.Key).ToList();
        }
    }
}
