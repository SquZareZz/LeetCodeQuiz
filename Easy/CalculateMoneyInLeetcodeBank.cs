using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class CalculateMoneyInLeetcodeBank
    {
        public int TotalMoney(int n)
        {
            int week = 0;
            int day = 0;
            int money = 0;
            for (int i = 0; i < n; i++)
            {
                day++;
                money += (day + week);
                if (day == 7)
                {
                    day = 0;
                    week++;
                }
            }
            return money;
        }
        public int TotalMoney2(int n)
        {
            int day = 0;
            int money = 0;
            for (int i = 0; i < n; i++)
            {
                day++;
                money += (day + i/7);
                if (day == 7)
                {
                    day = 0;
                }
            }
            return money;
        }
    }
}
