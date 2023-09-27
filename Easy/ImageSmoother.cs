using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class ImageSmoother
    {
        public int[][] ImageSmoother1(int[][] img)
        {

            int HLen = img.Length;
            int WLen = img[0].Length;
            int[][] Result = new int[HLen][];

            for (int h = 0; h < HLen; h++)//高
            {
                int[] ReRow = new int[WLen];
                for (int w = 0; w < WLen; w++)//寬
                {
                    int Element = 0;
                    int CountElements = 0;
                    for (int j = h, k = w; j < h + 3;)//單個元素
                    {
                        if (j - 1 > -1 && k - 1 > -1 && j - 1 < HLen && k - 1 < WLen)
                        {
                            Element += img[j - 1][k - 1];
                            CountElements++;
                        }
                        if (k - w == 2)
                        {
                            j++;
                            k = w;
                        }
                        else
                        {
                            k++;
                        }
                    }
                    ReRow[w] = Element != 0 ? Convert.ToInt32(Math.Floor((double)Element / CountElements)) : 0;
                }
                Result[h] = ReRow;
            }
            return Result;
        }
    }
}
