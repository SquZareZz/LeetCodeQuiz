using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class CanIWin
    {
        public bool CanIWinFail(int maxChoosableInteger, int desiredTotal)
        {
            //不是直接算
            if (desiredTotal <= maxChoosableInteger)
            {
                return true;
            }
            return (desiredTotal % maxChoosableInteger) % 2 == 1;
        }
        public bool CanIWin1(int maxChoosableInteger, int desiredTotal)
        {
            if (desiredTotal < 1) return true;

            int sum = (1 + maxChoosableInteger) * maxChoosableInteger / 2;
            // 如果所有數字的總和都小於desiredTotal，無論怎麼選，第一個玩家都贏不了
            if (sum < desiredTotal) return false;
            // 使用字典來儲存已經計算過的情況
            bool[] memo = new bool[1 << maxChoosableInteger];

            return CanWin(0, maxChoosableInteger, desiredTotal, memo);
        }
        private bool CanWin(int state, int maxChoosableInteger, int desiredTotal, bool[] memo)
        {
            //避免重用
            if (memo[state]) return true;

            for (int i = 1; i <= maxChoosableInteger; i++)
            {
                //初始遮罩從2^0次方開始，所以i-1
                int mask = 1 << (i - 1);
                //理想情況，兩位玩家都會從數字最小處選起
                //1、2、3、4........
                //
                if ((state & mask) == 0) // 如果該數字還沒被選擇過
                {
                    //desiredTotal <= i 代表可以直接選中，不用挑最小數字選
                    //或是下家的狀態是不能贏，也代表自己勝利
                    //回傳直至最上層 = 最終結果
                    if (desiredTotal <= i || !CanWin(state | mask, maxChoosableInteger, desiredTotal - i, memo))
                    {
                        memo[state] = true;
                        return true;
                    }
                }
            }
            memo[state] = false;
            return false;
        }
    }
}
