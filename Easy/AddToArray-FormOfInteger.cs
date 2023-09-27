using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class AddToArray_FormOfInteger
    {
        public IList<int> AddToArrayFormByString(int[] num, int k)
        {
            var Result = new List<int>();
            int temp = 0;
            string StrK = k.ToString();
            int StrKLen = StrK.Length - 1;
            for (int i = num.Length - 1; i > -1 || StrKLen > -1; i--, StrKLen--)
            {
                int temp2 = 0;
                if (StrKLen > -1 && i > -1)
                {
                    temp2 = num[i] + (int)char.GetNumericValue(StrK[StrKLen]) + temp;
                }
                else if (i < 0)
                {
                    temp2 = (int)char.GetNumericValue(StrK[StrKLen]) + temp;
                }
                else if (StrKLen < 0)
                {
                    temp2 = num[i] + temp;
                }

                if (temp2 > 9)
                {
                    temp2 -= 10;
                    temp = 1;
                }
                else
                {
                    temp = 0;
                }
                Result.Add(temp2);
            }
            if (temp != 0)
            {
                Result.Add(temp);
            }
            return Enumerable.Reverse(Result).ToList();
        }
        public IList<int> AddToArrayFormFastest(int[] num, int k)
        {
            var Result = new List<int>();
            var kList = new List<int>();
            int temp = 0;
            while (k > 0)
            {
                kList.Add(k % 10);
                k = k / 10;
            }
            kList.Reverse();
            int kLen = kList.Count - 1;
            for (int i = num.Length - 1; i > -1 || kLen > -1; i--, kLen--)
            {
                int temp2 = 0;
                if (kLen > -1 && i > -1)
                {
                    temp2 = num[i] + kList[kLen] + temp;
                }
                else if (i < 0)
                {
                    temp2 = kList[kLen] + temp;
                }
                else if (kLen < 0)
                {
                    temp2 = num[i] + temp;
                }
                switch (temp2)
                {
                    case > 9:
                        temp2 -= 10;
                        temp = 1;
                        Result.Add(temp2);
                        break;
                    default:
                        temp = 0;
                        Result.Add(temp2);
                        break;
                }
            }
            if (temp != 0)
            {
                Result.Add(temp);
            }
            return Enumerable.Reverse(Result).ToList();
        }
        public IList<int> AddToArrayFormBySQL(int[] num, int k)
        {
            var Result = new List<int>();
            int[] kNumArr = k.ToString().Select(o => Convert.ToInt32(o) - 48).ToArray();
            int temp = 0, kLen = kNumArr.Length - 1;

            for (int i = num.Length - 1; i > -1 || kLen > -1; i--, kLen--)
            {
                int temp2 = 0;
                if (kLen > -1 && i > -1)
                {
                    temp2 = num[i] + kNumArr[kLen] + temp;
                }
                else if (i < 0)
                {
                    temp2 = kNumArr[kLen] + temp;
                }
                else if (kLen < 0)
                {
                    temp2 = num[i] + temp;
                }
                switch (temp2)
                {
                    case > 9:
                        temp2 -= 10;
                        temp = 1;
                        Result.Add(temp2);
                        break;
                    default:
                        temp = 0;
                        Result.Add(temp2);
                        break;
                }
            }
            if (temp != 0)
            {
                Result.Add(temp);
            }
            return Enumerable.Reverse(Result).ToList();
        }
    }
}
