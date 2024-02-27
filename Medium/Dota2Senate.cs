using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class Dota2Senate
    {
        public string PredictPartyVictoryFail(string senate)
        {
            var LineUp = new Queue<char>();
            bool R_Ban = false;
            bool D_Ban = false;
            foreach (var c in senate)
            {
                if (LineUp.Count == 0)
                {
                    LineUp.Enqueue(c);
                    if (c == 'R')
                    {
                        R_Ban = true;
                    }
                    else
                    {
                        D_Ban = true;
                    }
                    continue;
                }
                if (c != LineUp.Peek())
                {
                    if (c == 'R' && D_Ban == true)
                    {
                        D_Ban = false;
                        continue;
                    }
                    else if (c == 'R' && D_Ban == false)
                    {
                        LineUp.Dequeue();
                        LineUp.Enqueue(c);
                        R_Ban = true;
                    }
                    else if (c == 'D' && R_Ban == true)
                    {
                        R_Ban = false;
                        continue;
                    }
                    else if (c == 'D' && R_Ban == false)
                    {
                        LineUp.Dequeue();
                        LineUp.Enqueue(c);
                        D_Ban = true;
                    }
                }
                else
                {
                    LineUp.Enqueue(c);
                }
            }
            return LineUp.Dequeue() == 'R' ? "Radiant" : "Dire";
        }
        public string PredictPartyVictory(string senate)
        {
            int n = senate.Length;
            //Queue 記錄順位
            Queue<int> R_Team = new Queue<int>();
            Queue<int> Q_Team = new Queue<int>();
            for (int i = 0; i < n; ++i)
            {
                if (senate[i] == 'R')
                {
                    R_Team.Enqueue(i);
                }
                else
                {
                    Q_Team.Enqueue(i);
                }                    
            }

            while (R_Team.Count > 0 && Q_Team.Count > 0)
            {
                //比較順位大小，決定誰 Ban 誰，數字小的留下來
                int i = R_Team.Dequeue();
                int j = Q_Team.Dequeue();
                //Ban 過的走到隊伍最後面，如果有下一輪可以繼續執行 Ban 位
                if (i < j) 
                {
                    //加上隊伍長度可以保證一定不會重複位號
                    R_Team.Enqueue(i + n);
                }
                else 
                {
                    Q_Team.Enqueue(j + n);
                }                    
            }

            return (R_Team.Count > Q_Team.Count) ? "Radiant" : "Dire";
        }
    }
}
