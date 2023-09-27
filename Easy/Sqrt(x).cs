using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class Sqrt_x_
    {

        public int MySqrtSlowAnswer(int x)
        {
            //100 10000 10000000
            long a;
            if (x > 10000 * 10000)
            {
                a = x / 10000;
            }
            else if (x > 1000 * 1000)
            {
                a = x / 1000;
            }
            else if (x > 100 * 100)
            {
                a = x / 100;
            }
            else if (x > 10 * 10)
            {
                a = x / 10;
            }
            else
            {
                a = x / 2;
            }

            bool LeftCK = false;
            while (!LeftCK || a > 0)
            {
                if (a * a <= x)
                {
                    LeftCK = true;
                    a++;
                }
                else
                {
                    a--;
                }
                if (LeftCK)
                {
                    if (x == 1)
                    {
                        return 1;
                    }
                    else
                    {
                        a--;
                        break;
                    }
                }
            }
            return Convert.ToInt32(a);
        }
        public int MySqrtBisectionMethod(int x)
        {
            //int 只到2^32，所以從2^16次方砍下來看
            if (x <= 1) return x;
            int left = 0, right = x;
            if (x > 536872070) right = 46341;//(2^15)^2;2^16
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (x / mid >= mid)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }
            return right - 1;
        }
        public int MySqrtNewton(int x)
        {
            long res = x;
            if (res > 536872070) res = 46341;
            while (res * res > x)
            {
                res = (res + x / res) / 2;
            }
            return Convert.ToInt32(res);
        }
    }
}
