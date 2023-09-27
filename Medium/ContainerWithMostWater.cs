using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    internal class ContainerWithMostWater
    {
        public int MaxArea(int[] height)
        {
            int Len = height.Length, Left = 0, Right = Len - 1, Area = 0;
            while (Left < Right)
            {
                Area = Math.Max(Area, Math.Min(height[Right], height[Left]) * (Right - Left));
                if (height[Right] > height[Left])
                {
                    Left++;
                }
                else
                {
                    Right--;
                }

            }
            return Area;

        }
    }
}
