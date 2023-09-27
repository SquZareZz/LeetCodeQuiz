using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class LargestTriangleArea
    {
        public double LargestTriangleArea1(int[][] points)
        {
            bool[] Result = new bool[3];
            double res = 0;
            //給出三個點 (x1,x2),(y1,y2),(z1,z2)
            //使用鞋帶公式 |x1  x2|
            //             |y1  y2|
            //             |z1  z2|
            //  x1*y2-x2*y1、y1*z2-y2*z1、z1*x2-z2*x1
            //面積沒有正負，而且因為是三角形，所以絕對值後/2
            foreach (var i in points)
            {
                foreach (var j in points)
                {
                    foreach (var k in points)
                    {
                        res = Math.Max(res, 0.5 * 
                            Math.Abs(i[0] * j[1] + j[0] * k[1] + k[0] * i[1] - j[0] * i[1] - k[0] * j[1] - i[0] * k[1]));
                    }
                }
            }
            return res;
        }
    }
}
