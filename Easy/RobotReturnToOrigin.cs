using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class RobotReturnToOrigin
    {
        public bool JudgeCircle(string moves)
        {
            int[] JudgeResult = new int[2];
            var StrToIntDict = new Dictionary<char, int>()
            {
                {'U', 1 },
                {'D', -1 },
                {'L', -1 },
                {'R', 1 }
            };
            foreach (char C in moves)
            {
                if (C == 'U' || C == 'D')
                {
                    JudgeResult[0] += StrToIntDict[C];
                }
                else
                {
                    JudgeResult[1] += StrToIntDict[C];
                }
            }
            return JudgeResult[0] == 0 && JudgeResult[1] == 0;
        }
    }
}
