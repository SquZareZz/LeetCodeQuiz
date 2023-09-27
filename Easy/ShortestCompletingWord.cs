using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class ShortestCompletingWord
    {
        public string ShortestCompletingWordSlowest(string licensePlate, string[] words)
        {
            var DictLicense = new Dictionary<char, int>();
            var Candidates = new List<int>();
            licensePlate = licensePlate.ToLower();
            foreach (char c in licensePlate)
            {
                if (c > 57)
                {
                    if (DictLicense.ContainsKey(c))
                    {
                        DictLicense[c]++;
                    }
                    else
                    {
                        DictLicense.Add(c, 1);
                    }
                }
            }
            for (int i = 0; i < words.Length; i++)
            {
                var DictTemp = new Dictionary<char, int>();
                int Score = 0;
                foreach (char c in words[i])
                {
                    if (DictTemp.ContainsKey(c))
                    {
                        DictTemp[c]++;
                    }
                    else
                    {
                        DictTemp.Add(c, 1);
                    }
                }
                foreach (var Compare in DictLicense)
                {
                    if (DictTemp.ContainsKey(Compare.Key))
                    {
                        Score += Compare.Value > DictTemp[Compare.Key] ? DictTemp[Compare.Key] : Compare.Value;
                    }
                }
                Candidates.Add(Score);
            }
            var CandidatesIndex = new List<int>();
            for (int j = 0; j < Candidates.Count; j++)
            {
                if (Candidates[j] == Candidates.Max())
                {
                    CandidatesIndex.Add(j);
                }
            }
            string Result = words[CandidatesIndex[0]];
            int Len = Result.Length;

            switch (CandidatesIndex.Count)
            {
                case 1:
                    return words[CandidatesIndex[0]];
                default:
                    foreach (int temp in CandidatesIndex)
                    {
                        if (words[temp].Length < Len)
                        {
                            Result = words[temp];
                            Len = Result.Length;
                        }
                    }
                    return Result;
            }
        }
        public string ShortestCompletingWord1(string licensePlate, string[] words)
        {
            var DictLicense = new Dictionary<char, int>();
            var Candidates = new List<int>();
            licensePlate = licensePlate.ToLower();
            foreach (char c in licensePlate)
            {
                if (c > 57)
                {
                    if (DictLicense.ContainsKey(c))
                    {
                        DictLicense[c]++;
                    }
                    else
                    {
                        DictLicense.Add(c, 1);
                    }
                }
            }
            for (int i = 0; i < words.Length; i++)
            {
                var DictTemp = new Dictionary<char, int>();
                int Score = 0;
                foreach (char c in words[i])
                {
                    if (DictTemp.ContainsKey(c))
                    {
                        DictTemp[c]++;
                    }
                    else
                    {
                        DictTemp.Add(c, 1);
                    }
                }
                foreach (var Compare in DictLicense)
                {
                    if (DictTemp.ContainsKey(Compare.Key))
                    {
                        Score += Compare.Value > DictTemp[Compare.Key] ? DictTemp[Compare.Key] : Compare.Value;
                    }
                }
                Candidates.Add(Score);
            }
            int MaxScore = Candidates.Max();
            string Result = words[Candidates.IndexOf(MaxScore)];
            int Len = Result.Length;
            for (int i = 0; i < words.Length; i++)
            {
                int LenTemp = words[i].Length;
                if (Candidates[i] == MaxScore && LenTemp < Len)
                {
                    Result = words[i];
                    Len = LenTemp;
                }
            }
            return Result;
        }
    }
}
