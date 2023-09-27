using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class HappyNumber
    {
        public bool IsHappy(int n)
        {
            string HappyStr = n.ToString();
            var HappyDic = new Dictionary<int, int>();
            if (n == 0 || n == 1)
            {
                return true;
            }
            while (n != 0)
            {
                int TarLen = HappyStr.Length;
                double result = 0;
                for (int i = 0; i < TarLen; i++)
                {
                    result += Math.Pow(short.Parse(HappyStr[i].ToString()), 2);
                }
                if (HappyDic.ContainsKey(Convert.ToInt16(result)))
                {
                    return false;
                }
                else if (result == 1)
                {
                    return true;
                }
                HappyStr = result.ToString();
                HappyDic.Add(Convert.ToInt16(result), 1);
            }
            return false;
        }

    }
}
