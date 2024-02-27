using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class Largest3_Same_DigitNumberInString
    {
        public string LargestGoodInteger(string num)
        {
            var tempStr = new StringBuilder();
            char tempPrevious = num[0];
            var Candidate = new Dictionary<string, int>();
            foreach (char c in num)
            {
                if (tempStr.Length == 0 || c != tempPrevious)
                {
                    tempStr = new StringBuilder();
                    tempStr.Append(c);
                    tempPrevious = c;
                }
                else
                {
                    tempStr.Append(c);
                    if (tempStr.Length >= 3)
                    {
                        var temp = tempStr.ToString();
                        if (!Candidate.ContainsKey(temp))
                        {
                            Candidate.Add(temp, Int32.Parse(temp));
                        }
                        tempStr = new StringBuilder();
                    }
                }
            }

            return Candidate.Count == 0 ?
                "" : Candidate.Where(x => x.Value == Candidate.Values.Max()).FirstOrDefault().Key;
        }
        public string LargestGoodInteger2(string num)
        {
            var tempStr = new StringBuilder();
            var Candidate = new Dictionary<string, int>();
            for (int i = 0; i < num.Length; i++)
            {
                if (tempStr.Length == 0 || num[i] != num[i - 1])
                {
                    tempStr = new StringBuilder();
                    tempStr.Append(num[i]);
                }
                else
                {
                    tempStr.Append(num[i]);
                    if (tempStr.Length >= 3)
                    {
                        var temp = tempStr.ToString();
                        if (!Candidate.ContainsKey(temp))
                        {
                            Candidate.Add(temp, Int32.Parse(temp));
                        }
                        tempStr = new StringBuilder();
                    }
                }
            }
            return Candidate.Count == 0 ?
                "" : Candidate.Where(x => x.Value == Candidate.Values.Max()).FirstOrDefault().Key;
        }
        public string LargestGoodInteger3(string num)
        {
            var tempStr = new StringBuilder();
            char tempPrevious = num[0];
            var Result = "";
            foreach (char c in num)
            {
                if (tempStr.Length == 0 || c != tempPrevious)
                {
                    tempStr = new StringBuilder();
                    tempStr.Append(c);
                    tempPrevious = c;
                }
                else
                {
                    tempStr.Append(c);
                    if (tempStr.Length >= 3)
                    {
                        var temp = tempStr.ToString();
                        if (Result == "" || Int32.Parse(Result) < Int32.Parse(temp))
                        {
                            Result = temp;
                        }
                        tempStr = new StringBuilder();
                    }
                }
            }

            return Result;
        }
    }
}
