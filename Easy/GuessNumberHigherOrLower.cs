using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class GuessNumberHigherOrLower : GuessGame
    {
        //我也不知道錯在哪
        public int GuessNumberFail(int n)
        {
            if (guess(n) == 0)
            {
                return n;
            }
            else
            {
                int Bot = 1;
                int End = n;
                while (n > 0)
                {
                    if (guess(n) == 0)
                    {
                        return n;
                    }
                    else if (guess(n) == 1)
                    {
                        n = (Bot + n) / 2;
                    }
                    else
                    {
                        Bot = n;
                        n *= 2;

                    }
                }
                return n;
            }
        }
        public int GuessNumber(int n)
        {
            if (guess(n) == 0)
            {
                return n;
            }
            else
            {
                int Bot = 1;
                int End = n;
                while (n > 0)
                {
                    int mid = Bot + (End - Bot) / 2;
                    int midResult = guess(mid);
                    if (guess(End) == 1)
                    {
                        End += mid;
                    }
                    if (midResult == 0)
                    {
                        return mid;
                    }
                    else if (midResult == 1)
                    {
                        Bot = mid + 1;
                    }
                    else
                    {
                        End = mid;
                    }
                }
                return n;
            }
        }
    }
    public class GuessGame
    {
        public int guess(int num)
        {
            int z = 1702766719;
            if (num == z)
            {
                return 0;
            }
            else if (num > z)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
    }
}
