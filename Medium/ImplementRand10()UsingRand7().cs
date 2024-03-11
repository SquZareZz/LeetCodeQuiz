using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class ImplementRand10__UsingRand7__
    {
        public int Rand10()
        {
            //每個數字出現次數要等多
            //所以答案不能直接用 Rand7() + Rand7() % 4，會造成出現率不相等
            //假設它是倆維度，最小是 0 、最大是 n*n ，所以先讓 RandX()-1 以確保下一次有加減空間
            //再用原數 + 一個 RandX()，那 X=7 的極限就是 42+7=49 => Rand(49)
            //所以如果是 40 以下的數字，取餘數 +1，那每個數字的機率都是 10%
            //如果是 40 以上的數字，只有 1~9 沒有 10，所以必須拒絕採樣，重新呼叫函式
            int Result = (Rand7() - 1) * 7 + Rand7();
            return Result >= 40 ? Result % 10 + 1 : Rand10();
        }
        public int Rand7()
        {
            return new Random().Next(1, 7);
        }
    }
}
