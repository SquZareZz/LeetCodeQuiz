using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class ValidSquare
    {
        public bool ValidSquareFail(int[] p1, int[] p2, int[] p3, int[] p4)
        {
            //失敗，因為不見得每次都對得到斜邊
            //畢氏定理
            var Gap = new double[3];
            //如果三點同一直線上 => 畫不出矩形(斜線不算))
            //兩點不算，因為可能另兩點在靜像側
            var Xpoint = new List<int>() { p1[0], p2[0], p3[0], p4[0] };
            var Ypoint = new List<int>() { p1[1], p2[1], p3[1], p4[1] };
            if (Xpoint.GroupBy(n => n).Any(g => g.Count() == 3) || Ypoint.GroupBy(n => n).Any(g => g.Count() == 3)) return false;
            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        //第一個點距離的平方
                        Gap[i] = Math.Pow((p1[0] - p2[0]), 2) + Math.Pow((p1[1] - p2[1]), 2);
                        break;
                    case 1:
                        Gap[i] = Math.Pow((p1[0] - p3[0]), 2) + Math.Pow((p1[1] - p3[1]), 2);
                        break;
                    case 2:
                        Gap[i] = Math.Pow((p1[0] - p4[0]), 2) + Math.Pow((p1[1] - p4[1]), 2);
                        break;
                }
            }
            Array.Sort(Gap);
            if (Gap[0] != Gap[1])
            {
                return false;
            }
            Double Total = Gap[0] + Gap[1];
            if (Total != Gap[2])
            {
                return false;
            }
            return true;
        }
        public bool ValidSquare1(int[] p1, int[] p2, int[] p3, int[] p4)
        {
            //定位出四個點，其中有菱形和正方形兩個選項
            //如果它有 X 軸最高，但 X 軸有兩個點
            //　　→比較兩個點的 Y 軸，就可以找出直邊
            //如果它有 X 軸最高，但 X 軸有一個點
            //　　→那同一條 X 軸上一定有一個點，讓它維持 90 度，這個點跟它的距離為斜邊，其他兩點為直邊
            //→換句話說，同一條 X 軸和 Y 軸上必定各有一個點，差別只在是斜邊還是直邊

            //如果三點同一直線上 => 畫不出矩形(斜線不算))
            //兩點不算，因為可能另兩點在靜像側
            var Xpoint = new List<int>() { p1[0], p2[0], p3[0], p4[0] };
            var Ypoint = new List<int>() { p1[1], p2[1], p3[1], p4[1] };
            if (Xpoint.GroupBy(n => n).Any(g => g.Count() >= 3) ||
                Ypoint.GroupBy(n => n).Any(g => g.Count() >= 3)) return false;
            int Xmax = Xpoint.Max(), Xmin = Xpoint.Min();
            int Ymax = Ypoint.Max(), Ymin = Ypoint.Min();
            var Gap = new double[3];
            bool Trans = Xpoint.Count(x => x == Xmax) != 2 || Ypoint.Count(y => y == Ymax) != 2;
            int j = 0;
            for (int i = 1; i < 4; i++)
            {
                //第一個點當基準點。如果是菱形，那同軸的是斜邊
                //菱形有分正菱形和非正菱形，所以要找 X 或 Y 的極值決定直邊或斜邊
                if (Trans)
                {
                    //如果第一個點是左右的點
                    if (Xpoint[0] == Xmax || Xpoint[0] == Xmin)
                    {
                        //如果比較的點是左右的點
                        if (Xpoint[i] == Xmin || Xpoint[i] == Xmax)
                        {
                            Gap[2] = Math.Pow((Xpoint[0] - Xpoint[i]), 2) + Math.Pow((Ypoint[0] - Ypoint[i]), 2);
                        }
                        //如果比較的點是上下的點
                        else
                        {
                            Gap[j] = Math.Pow((Xpoint[0] - Xpoint[i]), 2) + Math.Pow((Ypoint[0] - Ypoint[i]), 2);
                            j++;
                        }
                    }
                    //如果是上下的點                    
                    else
                    {
                        //如果比較的點是左右的點
                        if (Ypoint[i] == Ymin || Ypoint[i] == Ymax)
                        {
                            Gap[2] = Math.Pow((Xpoint[0] - Xpoint[i]), 2) + Math.Pow((Ypoint[0] - Ypoint[i]), 2);
                        }
                        //如果比較的點是上下的點
                        else
                        {
                            Gap[j] = Math.Pow((Xpoint[0] - Xpoint[i]), 2) + Math.Pow((Ypoint[0] - Ypoint[i]), 2);
                            j++;
                        }
                    }
                }
                else
                {
                    if (Xpoint[0] != Xpoint[i] && Ypoint[0] != Ypoint[i])
                    {
                        Gap[2] = Math.Pow((Xpoint[0] - Xpoint[i]), 2) + Math.Pow((Ypoint[0] - Ypoint[i]), 2);
                    }
                    else
                    {
                        Gap[j] = Math.Pow((Xpoint[0] - Xpoint[i]), 2) + Math.Pow((Ypoint[0] - Ypoint[i]), 2);
                        j++;
                    }
                }
            }
            return Gap[0] == Gap[1] && Gap[0] + Gap[1] == Gap[2];
        }
        public bool ValidSquare2(int[] p1, int[] p2, int[] p3, int[] p4)
        {
            //定位出四個點，其中有菱形和正方形兩個選項
            //如果它有 X 軸最高，但 X 軸有兩個點
            //　　→比較兩個點的 Y 軸，就可以找出直邊
            //如果它有 X 軸最高，但 X 軸有一個點
            //　　→那同一條 X 軸上一定有一個點，讓它維持 90 度，這個點跟它的距離為斜邊，其他兩點為直邊
            //→換句話說，同一條 X 軸和 Y 軸上必定各有一個點，差別只在是斜邊還是直邊

            //如果三點同一直線上 => 畫不出矩形(斜線不算))
            //兩點不算，因為可能另兩點在靜像側
            var Xpoint = new List<int>() { p1[0], p2[0], p3[0], p4[0] };
            var Ypoint = new List<int>() { p1[1], p2[1], p3[1], p4[1] };
            int Xmax = Xpoint.Max(), Xmin = Xpoint.Min();
            int Ymax = Ypoint.Max(), Ymin = Ypoint.Min();
            var Gap = new double[3];
            bool Trans = Xpoint.Count(x => x == Xmax) != 2 || Ypoint.Count(y => y == Ymax) != 2;
            int j = 0;
            for (int i = 1; i < 4; i++)
            {
                //第一個點當基準點。如果是菱形，那同軸的是斜邊
                //菱形有分正菱形和非正菱形，所以要找 X 或 Y 的極值決定直邊或斜邊
                var temp = Math.Pow((Xpoint[0] - Xpoint[i]), 2) + Math.Pow((Ypoint[0] - Ypoint[i]), 2);
                //點重疊 => 不可能是正方形
                if (temp == 0) return false;
                if (Trans)
                {
                    //如果第一個點是左右的點
                    if (Xpoint[0] == Xmax || Xpoint[0] == Xmin)
                    {
                        //如果比較的點是左右的點
                        if (Xpoint[i] == Xmin || Xpoint[i] == Xmax)
                        {
                            Gap[2] = temp;
                        }
                        //如果比較的點是上下的點
                        else
                        {
                            Gap[j] = temp;
                            j++;
                        }
                    }
                    //如果是上下的點                    
                    else
                    {
                        //如果比較的點是左右的點
                        if (Ypoint[i] == Ymin || Ypoint[i] == Ymax)
                        {
                            Gap[2] = temp;
                        }
                        //如果比較的點是上下的點
                        else
                        {
                            Gap[j] = temp;
                            j++;
                        }
                    }
                }
                else
                {
                    if (Xpoint[0] != Xpoint[i] && Ypoint[0] != Ypoint[i])
                    {
                        Gap[2] = temp;
                    }
                    else
                    {
                        Gap[j] = temp;
                        j++;
                    }
                }
            }
            return Gap[0] == Gap[1] && Gap[0] + Gap[1] == Gap[2];
        }
    }
}