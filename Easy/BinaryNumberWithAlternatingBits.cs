using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class BinaryNumberWithAlternatingBits
    {
        public bool HasAlternatingBits(int n)
        {
            string BinStr = Convert.ToString(n, 2);
            bool OneOrZero = BinStr[0] == '1';
            for (int i = 1; i < BinStr.Length; i++)
            {
                //1==(s==1) || 0==(s==0)
                //OneOrZero=0;!OneOrZero=-1
                if (OneOrZero == (BinStr[i] == '1') || !OneOrZero == (BinStr[i] == '0'))
                {
                    return false;
                }
                else
                {
                    OneOrZero = !OneOrZero;
                }
            }
            return true;
        }
    }
}
