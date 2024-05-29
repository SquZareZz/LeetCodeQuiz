using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class DiagonalTraverse
    {
        public int[] FindDiagonalOrderFail(int[][] mat)
        {
            //因為索引值從 0 開始，所以順序來說：
            //偶數是左下到右上，所以起點會在mat[n-1][0]，y座標-1、x座標+1，終點會在mat[0][n-1]
            //奇數是右上到左下，所以起點會在mat[0][n-1]，y座標+1、x座標-1，終點會在mat[n-1][0]
            //要走多長 => (0 => i && i => 0) => Width*2-1 => 拆兩個迴圈
            //倒序：
            //偶數還是左下到右上，所以起點會在mat[n-1][Width]，y座標-1、x座標+1，終點會在mat[Width][n-1]
            //奇數還是右上到左下，但是起點會在mat[Width][n-1]，y座標+1、x座標-1，終點會在mat[n-1][Width]

            int Width = mat[0].Length;
            int Length = mat.Length;
            var Result = new List<int>();
            if (Width == 1)
            {
                foreach (var IntNum in mat)
                {
                    Result.Add(IntNum[0]);
                }
                return Result.ToArray();
            }
            else if (Length == 1)
            {
                foreach (var IntNum in mat[0])
                {
                    Result.Add(IntNum);
                }
                return Result.ToArray();
            }

            if (Width >= Length)
            {
                for (int i = 0; i < Width; i++)
                {
                    switch (i % 2)
                    {
                        case 0:
                            for (int j = Length - 1, k = 0; j > -1 && k < Width; j--, k++)
                            {
                                Result.Add(mat[j][k]);
                            }
                            break;
                        case 1:
                            for (int j = 0, k = i; j < Width && k > -1; j++, k--)
                            {
                                Result.Add(mat[j][k]);
                            }
                            break;
                    }
                }
                for (int i = 1; i < Length; i++)
                {
                    switch (i % 2)
                    {
                        case 0:
                            for (int j = i, k = Width - 1; j > -1 && k < Width; j--, k++)
                            {
                                Result.Add(mat[j][k]);
                            }
                            break;
                        case 1:
                            for (int j = i, k = Width - 1; j < Length && k > -1; j++, k--)
                            {
                                Result.Add(mat[j][k]);
                            }
                            break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < Length; i++)
                {
                    switch (i % 2)
                    {
                        case 0:
                            for (int j = Length - 1, k = i; j > -1 && k < Width; j--, k++)
                            {
                                Result.Add(mat[j][k]);
                            }
                            break;
                        case 1:
                            for (int j = Width - 1, k = i; j < Length && k > -1; j++, k--)
                            {
                                Result.Add(mat[j][k]);
                            }
                            break;
                    }
                }
                for (int i = 0; i < Length; i++)
                {
                    switch (i % 2)
                    {
                        case 0:
                            for (int j = Length - 1, k = i; j > -1 && k < Width; j--, k++)
                            {
                                Result.Add(mat[j][k]);
                            }
                            break;
                        case 1:
                            for (int j = Width - 1, k = i; j < Length && k > -1; j++, k--)
                            {
                                Result.Add(mat[j][k]);
                            }
                            break;
                    }
                }
            }




            return Result.ToArray();
        }
        public int[] FindDiagonalOrder(int[][] mat)
        {
            //直接用座標變換
            int Width = mat[0].Length;
            int Length = mat.Length;
            var Result = new List<int>();
            bool Change = false;
            //X、Y 座標起始位置
            int Xc = 0, Yc = 0;
            for (int i = 0; i < Width * Length; i++)
            {
                Result.Add(mat[Yc][Xc]);
                if (i != Width * Length - 1)
                {
                    switch (Change)
                    {
                        case true://↙
                            Xc -= 1;
                            Yc += 1;
                            if (Yc > Length - 1)
                            {
                                Xc += 2;
                                Yc -= 1;
                                Change = false;
                            }
                            else if (Xc < 0)
                            {
                                Xc += 1;
                                Change = false;
                            }
                            break;
                        case false://↗
                            Xc += 1;
                            Yc -= 1;
                            if (Xc > Width - 1)
                            {
                                Yc += 2;
                                Xc -= 1;
                                Change = true;
                            }
                            else if (Yc < 0)
                            {
                                Yc += 1;
                                Change = true;
                            }
                            break;
                    }
                }
            }
            return Result.ToArray();
        }
        public int[] FindDiagonalOrder2(int[][] mat)
        {
            //直接用座標變換
            int Width = mat[0].Length;
            int Length = mat.Length;
            var Result = new List<int>();
            bool Change = true;
            //X、Y 座標起始位置，從上一階段開始
            int Xc = 0, Yc = -1;
            for (int i = 0; i < Width * Length; i++)
            {
                //從上一階段開始，因此不用判別是否到最後
                switch (Change)
                {
                    case true://↙
                        Xc -= 1;
                        Yc += 1;
                        if (Yc > Length - 1)
                        {
                            Xc += 2;
                            Yc -= 1;
                            Change = false;
                        }
                        else if (Xc < 0)
                        {
                            Xc += 1;
                            Change = false;
                        }
                        break;
                    case false://↗
                        Xc += 1;
                        Yc -= 1;
                        if (Xc > Width - 1)
                        {
                            Yc += 2;
                            Xc -= 1;
                            Change = true;
                        }
                        else if (Yc < 0)
                        {
                            Yc += 1;
                            Change = true;
                        }
                        break;
                }
                Result.Add(mat[Yc][Xc]);
            }
            return Result.ToArray();
        }
    }
}
