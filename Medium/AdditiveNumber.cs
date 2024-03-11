using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class AdditiveNumber
    {
        public bool IsAdditiveNumber(string num)
        {
            int Len = num.Length;
            //i長度不能比一半-1大，不然剩下的數字不可能是總和
            for (int i = 1; i <= (Len - 1) / 2; i++)
            {
                //避開0開頭
                if (num.StartsWith("0") && i >= 2)
                {
                    break;
                }
                //不管第一個數是大的或第二個數是大的，都不能比剩下的數字長度長
                //j至少從下一號起跳
                for (int j = i + 1; Len - j >= i && Len - j >= j - i; j++)
                {
                    //避開0開頭
                    //j - i >= 2 代表重複算過
                    if (num[i] == '0' && j - i >= 2)
                    {
                        break;
                    }
                    //long 防止溢位
                    long num1 = long.Parse(num.Substring(0, i));
                    long num2 = long.Parse(num.Substring(i, j - i));
                    if (AdditiveOrNot(num.Substring(j), num1, num2))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool AdditiveOrNot(string num, long num1, long num2)
        {
            if (num == "")
            {
                //切到沒字以後就是對的
                return true;
            }
            string SumStr = "" + (num1 + num2);
            //字串開頭=兩數的加總
            if (!num.StartsWith(SumStr))
            {
                return false;
            }
            return AdditiveOrNot(num.Substring(SumStr.Length), num2, num1 + num2);
        }
    }
}
