using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class Base7
    {
        public string ConvertToBase7(int num)
        {
            string Result = "";
            int Count = 0;
            string Reverse = "";
            if (num < 0)
            {
                Reverse = "-";
                num = Math.Abs(num);
            }
            else if (num == 0)
            {
                return "0";
            }

            while (Math.Pow(7, Count) <= num)
            {
                Count++;
            }
            Count--;
            while (Count > -1)
            {
                int temp = Convert.ToInt32(Math.Floor(num / Math.Pow(7, Count)));
                Result += temp.ToString();
                if (temp != 0)
                {
                    num -= Convert.ToInt32(Math.Pow(7, Count) * temp);
                }
                Count--;
            }
            return Reverse + Result;
        }
        public string ConvertToBase7_2(int num)
        {
            string Result = "";
            string Reverse = "";
            if (num < 0)
            {
                Reverse = "-";
                num = Math.Abs(num);
            }
            else if (num == 0)
            {
                return "0";
            }

            while (num > 0)
            {
                double temp = num;
                int Count = 0;
                while (temp >= 7)
                {
                    temp = Convert.ToInt32(Math.Floor(temp / 7));
                    if (temp != 0)
                    {
                        Count++;
                    }
                }
                int temp2;
                while (Count > -1)
                {
                    temp2 = Convert.ToInt32(Math.Floor(num / Math.Pow(7, Count)));
                    Result += temp2.ToString();
                    num -= Convert.ToInt32(Math.Pow(7, Count) * temp2);
                    Count--;
                }

            }
            return Reverse + Result;
        }
    }
}
