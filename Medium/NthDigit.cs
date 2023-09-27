using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class NthDigit
    {
        public int FindNthDigitFail(int n)
        {
            //一個個找太慢
            var ResStr = "";
            for (int i = 0; i < n + 1 && ResStr.Length <= n; i++)
            {
                ResStr += i;
            }
            return ResStr[n] - 48;
        }
        public int FindNthDigitFail2(int n)
        {
            if (n < 10)
            {
                return n;
            }
            else
            {
                long BeforeNum = 0;
                for (int i = 0; i < (int)Math.Log10(n); i++)
                {
                    BeforeNum += (int)(9 * Math.Pow(10, i) * (i + 1));
                    if (n / 10 < BeforeNum) break;
                }                
                long TarNum = (n - BeforeNum);
                int PowNum = (int)Math.Log10(BeforeNum);
                var Sup = (int)TarNum % ( + 1);
                var ResStr = Sup != 0 ? "" + Math.Pow(10, PowNum) + TarNum / (PowNum + 1):
                   "" + (Math.Pow(10, PowNum) + TarNum / (PowNum + 1) - 1);
                return Sup != 0 ? ResStr[Sup - 1] - 48 : ResStr.Last() - 48;
            }
        }
        public int FindNthDigit(int n)
        {
            //temp => 防止溢位
            long Len = 1, cnt = 9, start = 1, temp = n;
            //當temp減到比位數乘積小的時候，即為當前目標
            while (temp > Len * cnt)
            {
                temp -= Len * cnt;
                Len++;
                //每進一次位，需要加總的都*10
                cnt *= 10;
                start *= 10;
            }
            start += (temp - 1) / Len;
            string t = "" + start;
            return t[(int)((temp - 1) % Len)] - '0';
        }
    }
}
