using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class NumberComplement
    {
        public int FindComplement(int num)
        {
            string ResTemp = "";
            foreach (char t in Convert.ToString(num, 2))
            {
                switch (t)
                {
                    case '0':
                        ResTemp += "1";
                        break;
                    case '1':
                        ResTemp += "0";
                        break;
                }
            }
            return Convert.ToInt32(ResTemp, 2);
        }
    }
}
