using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class NumberOf1Bits
    {
        public int HammingWeight(uint n)
        {
            //每個位數的數字進行檢查，檢查完以後右移一位，
            //代表該數字歸0，並檢查下一位數
            int count = 0;
            while (n > 0)
            {
                count += (int)(n & 1);// 檢查最右邊的位元是否為 1(ex:000000001)
                //，對 n 做 & 運算只會留下最右一位是否為 1 的結果
                n >>= 1;  // 右移一位
            }
            return count;
        }
    }
}
