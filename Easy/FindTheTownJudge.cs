using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class FindTheTownJudge
    {
        public int FindJudge2(int n, int[][] trust)
        {
            if (trust.Length < n - 1)
            {
                return -1;
            }
            else if (trust.Length == 0)
            {
                return n - 1 == 0 ? n : -1;
            }
            var DictCounts = new Dictionary<int, int>();
            var NotJudge = new HashSet<int>();
            foreach (var pair in trust)
            {
                NotJudge.Add(pair[0]);
                if (DictCounts.ContainsKey(pair[1]))
                {
                    DictCounts[pair[1]]++;
                }
                else
                {
                    DictCounts[pair[1]] = 1;
                }
            }
            foreach (var Candidate in DictCounts)
            {
                if (Candidate.Value == n - 1 &&
                    !NotJudge.Contains(Candidate.Key))
                {
                    return Candidate.Key;
                }
            }
            return -1;
        }
        public int FindJudge(int n, int[][] trust)
        {
            if (trust.Length == 0)
            {
                return n - 1 == 0 ? n : -1;
            }
            var DictCounts = new Dictionary<int, int>();
            var NotJudge = new HashSet<int>();
            foreach (var pair in trust)
            {
                NotJudge.Add(pair[0]);
                if (DictCounts.ContainsKey(pair[1]))
                {
                    DictCounts[pair[1]]++;
                }
                else
                {
                    DictCounts[pair[1]] = 1;
                }
            }
            foreach (var Candidate in DictCounts)
            {
                if (Candidate.Value == n - 1 &&
                    !NotJudge.Contains(Candidate.Key))
                {
                    return Candidate.Key;
                }
            }
            return -1;
        }
    }
}
