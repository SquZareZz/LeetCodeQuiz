using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class BaseballGame
    {
        public int CalPoints(string[] operations)
        {
            var ResultList = new List<string>();
            foreach (string S in operations)
            {
                switch (S)
                {
                    case "C":
                        ResultList.RemoveRange(ResultList.Count - 1, 1);
                        break;
                    case "D":
                        ResultList.Add((Convert.ToInt32(ResultList[ResultList.Count - 1]) * 2).ToString());
                        break;
                    case "+":
                        ResultList.Add((Convert.ToInt32(ResultList[ResultList.Count - 1]) + Convert.ToInt32(ResultList[ResultList.Count - 2])).ToString());
                        break;
                    default:
                        ResultList.Add(S);
                        break;
                }
            }
            int Result = 0;
            foreach (var s in ResultList)
            {
                Result += Convert.ToInt32(s);
            }
            return Result;
        }
        public int CalPoints2(string[] operations)
        {
            var ResultList = new List<int>();
            foreach (string S in operations)
            {
                switch (S)
                {
                    case "C":
                        ResultList.RemoveRange(ResultList.Count - 1, 1);
                        break;
                    case "D":
                        ResultList.Add(Convert.ToInt32(ResultList[ResultList.Count - 1]) * 2);
                        break;
                    case "+":
                        ResultList.Add(Convert.ToInt32(ResultList[ResultList.Count - 1]) + Convert.ToInt32(ResultList[ResultList.Count - 2]));
                        break;
                    default:
                        ResultList.Add(Convert.ToInt32(S));
                        break;
                }
            }
            return ResultList.Sum();
        }

    }
}
