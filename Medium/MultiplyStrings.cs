using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class MultiplyStrings
    {
        public string MultiplyFail(string num1, string num2)
        {
            //直接乘會因為溢位Fail
            //return (Convert.ToInt32(num1)* Convert.ToInt32(num2)).ToString();
            if (num1 == "0" || num2 == "0")
            {
                return "0";
            }
            if (num1.Length > num2.Length)
            {
                (num2, num1) = (num1, num2);
            }
            //不能直接換，因為它一定會出一個會溢位的數字搞你
            int Multiplicand = Convert.ToInt32(num1);
            string Result = "", temp = "0";
            //每次寫進去的長度為被乘數的最後一位，剩下都要進入加法
            for (int i = num2.Length - 1; i > -1; i--)
            {
                int ToAdd = temp.Length > 0 ? Convert.ToInt32(temp) : 0;
                temp = (Multiplicand * (num2[i] - '0') + ToAdd).ToString();
                Result = temp[^1] + Result;//temp.Len-1
                temp = temp.Remove(temp.Length - 1);
            }
            return temp + Result;
        }
        public string Multiply(string num1, string num2)
        {
            //直接乘會因為溢位Fail
            //return (Convert.ToInt32(num1)* Convert.ToInt32(num2)).ToString();
            if (num1 == "0" || num2 == "0")
            {
                return "0";
            }
            string Result = "";
            int digits = 0;
            //每次寫進去的長度為被乘數的最後一位，剩下都要進入加法
            foreach (var numTemp in num2.Reverse())
            {
                int Carry = 0;
                string TempStr = "", ResultTemp = "";
                foreach (var numTemp2 in num1.Reverse())
                {
                    TempStr = ((numTemp - '0') * (numTemp2 - '0') + Carry).ToString();
                    if (TempStr.Length > 1)
                    {
                        ResultTemp = TempStr[1] + ResultTemp;
                        Carry = TempStr[0] - '0';
                    }
                    else
                    {
                        ResultTemp = TempStr + ResultTemp;
                        Carry = 0;
                    }
                }
                if (Carry > 0)
                {
                    ResultTemp = TempStr[0] + ResultTemp;
                }
                Carry = 0;
                if (Result.Length != 0)
                {
                    for (int i = ResultTemp.Length - 1, j = Result.Length - 1 - digits; i > -1; i--, j--)
                    {
                        int ToAdd = j > -1 ? Result[j] - '0' : 0;
                        string CountTemp = (ResultTemp[i] - '0' + ToAdd + Carry).ToString();
                        if (j > -1)
                        {
                            Result = Result.Remove(j, 1);
                            if (i > 0)
                            {
                                if (CountTemp.Length > 1)
                                {
                                    Result = Result.Insert(j, CountTemp[1].ToString());
                                    Carry = CountTemp[0] - '0';
                                }
                                else
                                {
                                    Result = Result.Insert(j, CountTemp);
                                    Carry = 0;
                                }
                            }
                            else
                            {
                                Result = CountTemp + Result;
                            }
                        }
                        else
                        {
                            switch (i)
                            {
                                case 0:
                                    Result = CountTemp + Result;
                                    break;
                                case 1:
                                    Result = ((ResultTemp[0] - '0') * 10 + Convert.ToInt32(CountTemp)).ToString() + Result;
                                    i = 0;
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    Result = ResultTemp;
                }
                digits++;
            }
            return Result;
        }
        public string Multiply2(string num1, string num2)
        {
            //直接乘會因為溢位Fail
            //return (Convert.ToInt32(num1)* Convert.ToInt32(num2)).ToString();
            if (num1 == "0" || num2 == "0")
            {
                return "0";
            }
            string Result = "";
            int digits = 0;
            //每次寫進去的長度為被乘數的最後一位，剩下都要進入加法
            foreach (var numTemp in num2.Reverse())
            {
                int Carry = 0, TempNum;
                var ResultTemp = new List<int>();
                //第一段處理
                foreach (var numTemp2 in num1.Reverse())//一個位數一個位數算結果
                {
                    TempNum = (numTemp - '0') * (numTemp2 - '0') + Carry;
                    switch (TempNum)
                    {
                        case > 9:
                            {
                                ResultTemp.Add(TempNum % 10);
                                Carry = TempNum / 10;
                            }
                            break;
                        default:
                            {
                                ResultTemp.Add(TempNum);
                                Carry = 0;
                            }
                            break;
                    }
                }
                if (Carry > 0)
                {
                    ResultTemp.Add(Carry);
                }
                ResultTemp.Reverse();
                //第二段處理(相加)
                Carry = 0;
                if (Result.Length != 0)
                {
                    for (int i = ResultTemp.Count - 1, j = Result.Length - 1 - digits; i > -1; i--, j--)
                    {
                        int ToAdd = j > -1 ? Result[j] - '0' : 0;
                        int CountTemp = ResultTemp[i] + ToAdd + Carry;
                        switch (j)
                        {
                            case > -1:
                                Result = Result.Remove(j, 1);
                                switch (i)
                                {
                                    case > 0:
                                        switch (CountTemp)
                                        {
                                            case > 9:
                                                Result = Result.Insert(j, (CountTemp % 10).ToString());
                                                Carry = CountTemp / 10;
                                                break;
                                            default:
                                                Result = Result.Insert(j, CountTemp.ToString());
                                                Carry = 0;
                                                break;
                                        }
                                        break;
                                    default:
                                        Result = CountTemp + Result;
                                        break;
                                }
                                break;
                            default:
                                switch (i)
                                {
                                    case 0:
                                        Result = CountTemp + Result;
                                        break;
                                    case 1:
                                        Result = (ResultTemp[0] * 10 + CountTemp).ToString() + Result;
                                        i = 0;
                                        break;
                                }
                                break;
                        }
                    }
                }
                else
                {
                    Result = string.Join("", ResultTemp.Select(i => i.ToString()));
                }
                digits++;
            }
            return Result;
        }
    }
}
