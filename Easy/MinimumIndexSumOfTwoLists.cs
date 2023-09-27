using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class MinimumIndexSumOfTwoLists
    {
        public string[] FindRestaurant(string[] list1, string[] list2)
        {
            var DictList = new Dictionary<string, int>();
            int CountList = 0;
            foreach (string str in list1)
            {
                if (!DictList.ContainsKey(str))
                {
                    DictList.Add(str, CountList);
                }
                else
                {
                    DictList[str] += CountList;
                }
                CountList++;
            }
            CountList = 0;
            foreach (string str in list2)
            {
                if (DictList.ContainsKey(str))
                {
                    DictList[str] += CountList;
                }
                CountList++;
            }
            foreach (string key in DictList.Keys)
            {
                if (!list1.Contains(key) || !list2.Contains(key))
                {
                    DictList.Remove(key);
                }
            }
            int target = DictList.Values.Min();
            return DictList.Where(x => x.Value == target).Select(p => p.Key).ToArray();
        }
        public string[] FindRestaurant2(string[] list1, string[] list2)
        {
            var DictList = new Dictionary<string, int>();
            int TarLen;
            if (list1.Length > list2.Length)
            {
                TarLen = list1.Length;
                for (int i = 0; i < TarLen; i++)
                {
                    int TarTemp = Array.IndexOf(list2, list1[i]);
                    if (TarTemp != -1)
                    {
                        DictList.Add(list1[i], i + TarTemp);
                    }
                }
            }
            else
            {
                TarLen = list2.Length;
                for (int i = 0; i < TarLen; i++)
                {
                    int TarTemp = Array.IndexOf(list1, list2[i]);
                    if (TarTemp != -1)
                    {
                        DictList.Add(list2[i], i + TarTemp);
                    }
                }
            }

            int target = DictList.Values.Min();
            return DictList.Where(x => x.Value == target).Select(p => p.Key).ToArray();
        }
        public string[] FindRestaurant3(string[] list1, string[] list2)
        {
            var DictList = new Dictionary<string, int>();
            int MinStemp = 0;
            int TarLen;
            if (list1.Length > list2.Length)
            {
                TarLen = list1.Length;
                for (int i = 0; i < TarLen; i++)
                {
                    int TarTemp = Array.IndexOf(list2, list1[i]);
                    if (TarTemp != -1)
                    {
                        if (i + TarTemp <= MinStemp || MinStemp == 0)
                        {
                            MinStemp = i + TarTemp;
                            DictList.Add(list1[i], MinStemp);
                        }

                    }
                }
            }
            else
            {
                TarLen = list2.Length;
                for (int i = 0; i < TarLen; i++)
                {
                    int TarTemp = Array.IndexOf(list1, list2[i]);
                    if (TarTemp != -1)
                    {
                        if (i + TarTemp <= MinStemp || MinStemp == 0)
                        {
                            MinStemp = i + TarTemp;
                            DictList.Add(list2[i], MinStemp);
                        }
                    }
                }
            }

            return DictList.Where(x => x.Value == DictList.Values.Min()).Select(p => p.Key).ToArray();
        }
        public string[] FindRestaurant4(string[] list1, string[] list2)
        {
            int MinStep = -1, TarLen;
            var Result = new List<string>();
            if (list1.Length < list2.Length)
            {
                TarLen = list1.Length;
                for (int i = 0; i < TarLen; i++)
                {
                    int TarTemp = Array.IndexOf(list2, list1[i]);
                    if (TarTemp != -1)
                    {
                        if (i + TarTemp < MinStep || MinStep == -1)
                        {
                            Result.Clear();
                            MinStep = i + TarTemp;
                            Result.Add(list1[i]);
                        }
                        else if (i + TarTemp == MinStep)
                        {
                            Result.Add(list1[i]);
                        }
                    }
                }
            }
            else
            {
                TarLen = list2.Length;
                for (int i = 0; i < TarLen; i++)
                {
                    int TarTemp = Array.IndexOf(list1, list2[i]);
                    if (TarTemp != -1)
                    {
                        if (i + TarTemp < MinStep || MinStep == -1)
                        {
                            Result.Clear();
                            MinStep = i + TarTemp;
                            Result.Add(list2[i]);
                        }
                        else if (i + TarTemp == MinStep)
                        {
                            Result.Add(list2[i]);
                        }
                    }
                }
            }

            return Result.ToArray();
        }
    }
}
