using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class GenerateRandomPointInACircle
    {
        double radius;
        double[] center;
        public GenerateRandomPointInACircle(double radius, double x_center, double y_center)
        {
            this.radius = radius;
            center = new double[2] { x_center, y_center };
        }

        public double[] RandPoint()
        {
            Random r = new Random();
            //Math.Sqrt 為了隨機點能夠平均分配在圓上
            //因為計算的時候是用平方，如果不開根號，相當於取 0~1 之間的數值的「平方」
            double dist = Math.Sqrt(r.NextDouble()) * radius;
            //取極座標，2pi = 一個圓的圓弧，因為 r 在 0~1 之間，所以角度也是 0~360 度之間
            double degree = r.NextDouble() * 2 * Math.PI;
            //最後用座標 + 產生點的位置
            //x 座標要加上隨機點 * Cos 角度；y 座標要加上隨機點 * Sin 角度
            //因為是 0~1 360度，所以四個象限都有
            return new double[2] { center[0] + dist * Math.Cos(degree), center[1] + dist * Math.Sin(degree) };
        }
    }
}
