using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class NumberOfStepsToReduceANumberInBinaryRepresentationToOne
    {
        public int NumStepsFail(string s)
        {
            //硬解會溢位
            int Res = 0;
            Int64 ResTemp = Convert.ToInt64(s, 2);
            while (ResTemp > 1)
            {
                if (ResTemp % 2 == 1)
                {
                    ResTemp++;
                }
                else
                {
                    ResTemp /= 2;
                }
                Res++;
            }
            return Res;
        }
        public int NumSteps(string s)
        {
            //由右往左
            //如果遇到 0，直接除以二，一步
            //如果遇到 1，要先加一再除以二，所以兩步
            //另外，如果現在是 1，但上一位是 1，那上一步已經進位過了，這一步就可以省下
            //同理 0 遇到 0 也是，結論是 0 與 1 的 AND 閘
            int Res = 0, carry = 0;
            //但如果只有一位數是例外，1 => 0
            //還有，最前面一位一定會是 1，不會有 0 開頭
            //到最左一位時，如果餘數為 0，結果加一，反之維持原結果
            if (s.Length == 1)
            {
                return 0;
            }
            foreach (char c in s.Skip(1).Reverse())
            {
                if (c == '0')
                {
                    if (carry == 0)
                    {
                        Res += 1;
                    }
                    else
                    {
                        Res += 2;
                        carry = 1;
                    }                    
                }
                else
                {
                    if (carry == 1)
                    {
                        Res += 1;
                    }
                    else
                    {
                        Res += 2;
                    }
                    carry = 1;
                }
            }
            return Res + carry;
        }
    }
}
