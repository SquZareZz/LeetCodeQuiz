using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class SummaryRanges
    {
        public IList<string> SummaryRanges1(int[] nums)
        {
            var ReturnList = new List<string>();
            if (nums.Length == 0)
            {
                return ReturnList;
            }
            string ReturnStartTemp = nums[0].ToString();
            string ReturnEndTemp = "";
            if (nums.Length == 1)
            {
                ReturnList.Add(ReturnStartTemp);
                return ReturnList;
            }
            else
            {
                for (int i = 1; i < nums.Length; i++)
                {
                    if (nums[i - 1] + 1 == nums[i])
                    {
                        ReturnEndTemp = nums[i].ToString();
                        if (i == nums.Length - 1)
                        {
                            ReturnList.Add(ReturnStartTemp + "->" + ReturnEndTemp);
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(ReturnEndTemp))
                        {
                            ReturnList.Add(ReturnStartTemp.ToString());
                        }
                        else
                        {
                            ReturnList.Add(ReturnStartTemp + "->" + ReturnEndTemp);
                        }
                        ReturnStartTemp = nums[i].ToString();
                        ReturnEndTemp = "";
                        if (i == nums.Length - 1)
                        {
                            ReturnList.Add(ReturnStartTemp.ToString());
                        }
                    }
                }
                return ReturnList;
            }
        }
        public IList<string> SummaryRangesFastest(int[] nums)
        {
            var ReturnList = new List<string>();
            int TarLen = nums.Length;
            if (TarLen == 0)
            {
                return ReturnList;
            }
            string ReturnStartTemp = nums[0].ToString();
            string ReturnEndTemp = "";
            if (TarLen == 1)
            {
                ReturnList.Add(ReturnStartTemp);
                return ReturnList;
            }
            else
            {
                for (int i = 1; i < TarLen; i++)
                {
                    if (nums[i - 1] + 1 == nums[i])
                    {
                        ReturnEndTemp = nums[i].ToString();
                        if (i == nums.Length - 1)
                        {
                            ReturnList.Add(ReturnStartTemp + "->" + ReturnEndTemp);
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(ReturnEndTemp))
                        {
                            ReturnList.Add(ReturnStartTemp.ToString());
                        }
                        else
                        {
                            ReturnList.Add(ReturnStartTemp + "->" + ReturnEndTemp);
                        }
                        ReturnStartTemp = nums[i].ToString();
                        ReturnEndTemp = "";
                        if (i == nums.Length - 1)
                        {
                            ReturnList.Add(ReturnStartTemp.ToString());
                        }
                    }
                }
                return ReturnList;
            }
        }
    }
}
