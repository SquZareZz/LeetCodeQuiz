using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class FractionToRecurringDecimal
    {
        public string FractionToDecimal(int numerator, int denominator)
        {
            //防止分子*分母過大，所以換成正負整數1表示
            int s1 = numerator >= 0 ? 1 : -1;
            int s2 = denominator >= 0 ? 1 : -1;
            // 32位元正負，故處理的時候用 64 位元的 long
            var Divisor = Math.Abs((long)denominator);
            var Output = Math.Abs((long)numerator) / Divisor;
            var Remainder = Math.Abs((long)numerator) % Divisor;
            var UnOrdered_Map = new Dictionary<long, int>();
            string res = Output.ToString();
            if (Remainder == 0)
            {
                return (Output * s1 * s2).ToString();
            }
            if (s1 * s2 == -1 && (Output > 0 || Remainder > 0))
            {
                res = "-" + res;
            }
            res += ".";
            string s = "";
            int pos = 0;
            while (Remainder != 0)
            {
                //如果商重複了，代表在商第一次出現的右手邊開始是循環小數
                if (UnOrdered_Map.ContainsKey(Remainder))
                {
                    s = s.Insert(UnOrdered_Map[Remainder], "(");
                    return res + s + ")";
                }
                else
                {
                    UnOrdered_Map.Add(Remainder, pos);
                    s += ((Remainder * 10) / Divisor).ToString(); //餘數再乘以 10 就可以再除一次
                    Remainder = (Remainder * 10) % Divisor; //取得新的餘數
                    pos++;
                }
            }
            return res + s;//無理數

        }
    }
}
