using EnumsNET;
using NPOI.SS.Formula.Functions;
using SixLabors.Fonts.Tables.AdvancedTypographic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class MatchsticksToSquare
    {
        int[] Puzzle = new int[4];
        bool[]? BoolButton;
        int Len;
        int Edge;
        public bool Makesquare(int[] matchsticks)
        {
            Edge = matchsticks.Sum() / 4;
            Len = matchsticks.Length;
            if (matchsticks.Max() > Edge || Len < 4) return false;
            //比 LINQ 方法快
            Array.Sort(matchsticks, (a, b) => b - a);
            return MakeEdge(0, matchsticks);
        }
        public bool MakeEdge(int Start, int[] matchsticks)
        {
            //只需要找到唯一解，所以每個數字都有對應邊的位置，且會有唯一的組合
            //所以只要在4次迴圈後順利從起始位置滾到最後一格位置 => 排完邊
            //如果某處發現錯誤，把排過的邊拿掉(-= matchsticks[Start])，繼續看下一個邊
            //如果到最尾邊沒排完，還原回去上一段還沒到最尾邊的位置，跳下一個邊繼續排
            //每個邊最多可以到最大長度-4種組合，每種組合都會被試過
            if (Start == matchsticks.Length)
            {
                return true;
            }
            for (int i = 0; i < 4; i++)
            {
                if (Puzzle[i] + matchsticks[Start] > Edge) continue;
                Puzzle[i] += matchsticks[Start];
                if (MakeEdge(Start + 1, matchsticks)) return true;
                Puzzle[i] -= matchsticks[Start];
            }
            return false;
        }
        public bool MakesquareFail(int[] matchsticks)
        {
            //問題出在，第一個數字拚出的邊可能不是唯一解，同理第二、第三也可能
            int[] Puzzle = new int[4];
            Edge = matchsticks.Sum() / 4;
            Len = matchsticks.Length;
            BoolButton = new bool[Len];
            if (matchsticks.Max() > Edge || Len < 4) return false;
            Array.Sort(matchsticks);
            for (int i = 0; i < 4; i++)
            {
                if (!MakeEdgeFail(matchsticks, Edge, BoolButton, Len - 1)) return false;
            }
            return BoolButton.Where(x => x == false).Count() < 1;
        }
        public bool MakeEdgeFail(int[] matchsticks, int EdgeTemp, bool[] BoolButtonTemp, int Start)
        {
            if (EdgeTemp == 0)
            {
                BoolButton = BoolButtonTemp;
                return true;
            }
            for (int i = Start; i > -1; i--)
            {
                if (!BoolButtonTemp[i] && EdgeTemp >= matchsticks[i])
                {
                    var tempBool = BoolButtonTemp.ToArray();
                    tempBool[i] = true;
                    if (MakeEdgeFail(matchsticks, EdgeTemp - matchsticks[i], tempBool, i - 1)) return true;
                }
            }
            return false;
        }
    }
}
