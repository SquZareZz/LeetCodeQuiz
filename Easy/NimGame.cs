using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class NimGame
    {
        //數字小於4時，我方必勝
        //數字介於5~7之間時，我方必勝
        //數字等於4或其倍數時，我方必敗
        public bool CanWinNim(int n)
        {
            if (n < 4)
            {
                return true;
            }
            else
            {
                if (n % 4 != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
    }
}
