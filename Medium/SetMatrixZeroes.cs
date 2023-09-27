using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class SetMatrixZeroes
    {
        public void SetZeroes(int[][] matrix)
        {
            //暴力硬解
            //第一次找0點，第二次根據0點的X、Y座標來重設數值
            var DictX=new Dictionary<int,int>();
            var DictY=new Dictionary<int,int>();
            for(int i = 0; i < matrix.Length; i++)
            {
                for(int j = 0; j < matrix[i].Length; j++)
                {
                    if(matrix[i][j] == 0)
                    {
                        if (!DictX.ContainsKey(j))
                        {
                            DictX.Add(j, 1);
                        }
                        if (!DictY.ContainsKey(i))
                        {
                            DictY.Add(i, 1);
                        }
                    }
                }
            }
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (DictX.ContainsKey(j)||DictY.ContainsKey(i))
                    {
                        matrix[i][j] = 0;
                    }
                }
            }
        }
        public void SetZeroes2(int[][] matrix)
        {
            //第一次找0點，第二次根據0點的X、Y座標來重設數值
            var DictX = new Dictionary<int, int>();
            //先把橫的都變0
            for (int i = 0; i < matrix.Length; i++)
            {
                var TempX = matrix[i].Select((value, index) => new { value, index })
                                    .Where(x => x.value == 0)
                                    .Select(x => x.index).ToArray();
                if (TempX.Length != 0)
                {
                    for(int j = 0; j < matrix[i].Length;j++)
                    {
                        matrix[i][j] = 0;
                    }
                    foreach (int j in TempX)
                    {
                        if (!DictX.ContainsKey(j))
                        {
                            DictX.Add(j,1);
                        }
                    }
                }
            }
            //再把直的都變0
            foreach (var Dict in DictX)
            {
                for(int i=0;i< matrix.Length; i++)
                {
                    matrix[i][Dict.Key] = 0;
                }
            }
        }
    }
}
