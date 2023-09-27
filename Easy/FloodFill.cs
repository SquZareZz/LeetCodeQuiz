using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace QuizSolution.Easy
{
    public class FloodFill
    {
        public int[][] FloodFill1(int[][] image, int sr, int sc, int color)
        {
            int target = image[sr][sc];
            if (color != target)
            {
                FloodFill_byDFS(sr, sc, color, image, target);
            }
            return image;
        }
        void FloodFill_byDFS(int y, int x, int color, int[][] area, int target)
        {

            area[y][x] = area[y][x] == target ? color : area[y][x];
            if (x > 0 && area[y][x - 1] == target)
            {
                FloodFill_byDFS(y, x - 1, color, area, target);
            }
            if (y > 0 && area[y - 1][x] == target)
            {
                FloodFill_byDFS(y - 1, x, color, area, target);
            }
            if (x < area[0].Length - 1 && area[y][x + 1] == target)
            {
                FloodFill_byDFS(y, x + 1, color, area, target);
            }
            if (y < area.Length - 1 && area[y + 1][x] == target)
            {
                FloodFill_byDFS(y + 1, x, color, area, target);
            }
        }
    }
}
