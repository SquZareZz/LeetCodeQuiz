using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class IntegerToRoman
    {
        public string IntToRoman(int num)
        {
            Dictionary<int, string> RomanTrans = new()
            {
                {  1,"I" },
                {  5 ,"V" },
                { 10 ,"X" },
                {  50,"L" } ,
                { 100, "C" } ,
                { 500,  "D" },
                { 1000 ,"M" }
            };
            string Result = "";
            int divideNum = 10;
            while (num > 0)
            {
                int temp = num % divideNum, temp2 = divideNum / 10;//找餘數、餘數的位數
                num -= temp;
                switch (temp / temp2)
                {
                    case 0:
                        break;
                    case < 4:
                        while (temp > 0)
                        {
                            Result = RomanTrans[temp2] + Result;
                            temp -= temp2;
                        }
                        break;
                    case 4:
                        Result = RomanTrans[temp - 3 * temp2] + RomanTrans[5 * temp2] + Result;//1+5
                        break;
                    case 5:
                        Result = RomanTrans[5 * temp2] + Result;
                        break;
                    case 9:
                        Result = RomanTrans[temp - 8 * temp2] + RomanTrans[temp + temp2] + Result;//1+10 
                        break;
                    default:
                        temp -= 5 * temp2;
                        while (temp > 0)
                        {
                            Result = RomanTrans[temp2] + Result;
                            temp -= temp2;
                        }
                        Result = RomanTrans[5 * temp2] + Result;
                        break;
                }

                divideNum *= 10;

            }
            return Result;
        }
    }
}
