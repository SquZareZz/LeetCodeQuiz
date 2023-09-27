using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class ReverseInteger
    {
        public int Reverse(int x)
        {
            string temp = "";
            switch (x)
            {
                case < 0:
                    temp = "-";
                    if (x - 1 > x)//數學邏輯上不可能發生，但電腦邏輯的溢位會
                    {
                        return 0;
                    }
                    else
                    {
                        x = Math.Abs(x);
                    }
                    break;
            }
            string ReverseStr = new string(x.ToString().Reverse().ToArray());
            return int.TryParse(temp + ReverseStr, out int value) ? value : 0;//用TRY取代原本的Convert
        }
    }
}
