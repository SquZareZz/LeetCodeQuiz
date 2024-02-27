using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class SpecialPositionsInABinaryMatrix
    {
        public int NumSpecial(int[][] mat)
        {
            int Res = 0;
            for (int i = 0; i < mat.Length; i++)
            {
                for (int k = 0; k < mat[0].Length; k++)
                {
                    //有需要才做
                    if (mat[i][k] == 1)
                    {
                        //有合格才往下找
                        if (mat[i].Count(x => x == 1) != 1)
                        {
                            break;
                        }
                        int temp = 0;
                        for (int j = 0; j < mat.Length; j++)
                        {
                            if (mat[j][k] == 1)
                            {
                                temp++;
                            }
                        }
                        //沒合格直接換行
                        if (temp != 1)
                        {
                            continue;
                        }
                        Res++;
                    }
                }
            }
            return Res;
        }
    }
}
