using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    internal class LargestNumber
    {
        public string LargestNumberFail(int[] nums)
        {
            string Result = nums[0].ToString();
            int ToCheck = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                while (ToCheck < Result.Length + 1)
                {
                    if (ToCheck == Result.Length)
                    {
                        Result = Result + nums[i].ToString();
                        ToCheck = 0;
                        break;
                    }
                    else if (ToCheck == nums[i].ToString().Length)
                    {
                        Result = nums[i].ToString() + Result;
                        ToCheck = 0;
                        break;
                    }

                    if (Result[ToCheck] - 48 > nums[i].ToString()[ToCheck] - 48)
                    {
                        Result = Result + nums[i].ToString();
                        ToCheck = 0;
                        break;
                    }
                    else if (Result[ToCheck] - 48 < nums[i].ToString()[ToCheck] - 48)
                    {
                        Result = nums[i].ToString() + Result;
                        ToCheck = 0;
                        break;
                    }
                    else
                    {
                        ToCheck++;
                    }
                }
            }

            return Result;
        }
        public string LargestNumber1Fail2(int[] nums)
        {
            //ex:10,2,9,39,17
            string Result = nums[0].ToString();
            for (int i = 1; i < nums.Length; i++)
            {
                string Temp1 = nums[i].ToString() + Result;
                string Temp2 = Result + nums[i].ToString();
                for (int j = 0; j < Temp1.Length; j++)
                {
                    if (Temp1[j] > Temp2[j])
                    {
                        Result = Temp1;
                        break;
                    }
                    else if (Temp1[j] < Temp2[j])
                    {
                        Result = Temp2;
                        break;
                    }

                    if (j == Temp1.Length - 1)
                    {
                        Result = Temp1;
                        break;
                    }
                }
            }

            return Result;
        }
        public string LargestNumberFail3(int[] nums)
        {
            //ex:111311, 1113 
            int MaxInNums = nums.Max();
            int PowOfMax = 0;
            string Result = "";
            while (MaxInNums >= Math.Pow(10, PowOfMax))
            {
                PowOfMax++;
            }
            //RedoValue,OriValue
            var NewNums = new List<int[]>();
            foreach (int i in nums)
            {
                int digit = (int)Math.Pow(10, PowOfMax - 1);
                if (i / digit < 1)
                {
                    NewNums.Add(new int[] {
                        (int)(i * (Math.Pow(10, PowOfMax - i.ToString().Length))), i
                    });
                }
                else
                {
                    NewNums.Add(new int[] { i, i });
                }
            }
            NewNums = NewNums.OrderByDescending(i => i[0]).ToList();
            foreach (var Redo in NewNums)
            {
                Result += Redo[1].ToString();
            }

            return Result;
        }
        public string LargestNumber1(int[] nums)
        {
            string Result = "";
            var NewNums = nums.Select(x => x.ToString()).ToList();
            NewNums.Sort((string x, string y) =>
            {
                //比較長短，首先比的是字串長度
                //長度一樣的時候，比較ASCII碼，所以比得出數字的大小
                return (y + x).CompareTo(x + y);
            });
            foreach (var Redo in NewNums)
            {
                //避開不合理的數值
                //ex: 00
                //同時要防止最尾數是0
                if (Result.Length < 1 && Redo.Equals("0"))
                {
                    continue;
                }
                Result += Redo;
            }
            return Result.Length < 1 ? "0" : Result;
        }
    }
}
