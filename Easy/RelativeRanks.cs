using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class RelativeRanks
    {
        public string[] FindRelativeRanks(int[] score)//少於3的時候會更快
        {
            int Len = score.Length;
            switch (Len)
            {
                case 1:
                    return new string[] { "Gold Medal" };
                case 2:
                    if (score[0] == score.Max())
                    {
                        return new string[] { "Gold Medal", "Silver Medal" };
                    }
                    else
                    {
                        return new string[] { "Silver Medal", "Gold Medal" };
                    }
                default:
                    int Count = 0;
                    var temp = score.ToArray();
                    Array.Sort(temp);
                    Array.Reverse(temp);
                    var DictScore = new Dictionary<int, string>();
                    while (Count < score.Length)
                    {
                        switch (Count)
                        {
                            case 0:
                                DictScore.Add(temp[Count], "Gold Medal");
                                break;
                            case 1:
                                DictScore.Add(temp[Count], "Silver Medal");
                                break;
                            case 2:
                                DictScore.Add(temp[Count], "Bronze Medal");
                                break;
                            default:
                                DictScore.Add(temp[Count], (Count + 1).ToString());
                                break;
                        }
                        Count++;
                    }
                    string[] Result = new string[Len];
                    for (int i = 0; i < Len; i++)
                    {
                        Result[i] = DictScore[score[i]];
                    }
                    return Result;
            }

        }
        public string[] FindRelativeRanks2(int[] score)
        {
            int Len = score.Length;
            int Count = 0;
            var temp = score.ToArray();
            Array.Sort(temp);
            Array.Reverse(temp);
            var DictScore = new Dictionary<int, string>();
            while (Count < Len)
            {
                switch (Count)
                {
                    case 0:
                        DictScore.Add(temp[Count], "Gold Medal");
                        break;
                    case 1:
                        DictScore.Add(temp[Count], "Silver Medal");
                        break;
                    case 2:
                        DictScore.Add(temp[Count], "Bronze Medal");
                        break;
                    default:
                        DictScore.Add(temp[Count], (Count + 1).ToString());
                        break;
                }
                Count++;
            }
            string[] Result = new string[Len];
            for (int i = 0; i < Len; i++)
            {
                Result[i] = DictScore[score[i]];
            }
            return Result;
        }
        public string[] FindRelativeRanksLastMemory(int[] score)
        {
            int Len = score.Length;
            var temp = score.ToArray();
            string[] Result = new string[Len];
            Array.Sort(temp);
            Array.Reverse(temp);
            for (int i = 0; i < Len; i++)
            {
                int index = Array.IndexOf(temp, score[i]);
                switch (index)
                {
                    case 0:
                        Result[i] = "Gold Medal";
                        break;
                    case 1:
                        Result[i] = "Silver Medal";
                        break;
                    case 2:
                        Result[i] = "Bronze Medal";
                        break;
                    default:
                        Result[i] = (index + 1).ToString();
                        break;
                }
            }
            return Result;
        }
    }
}
