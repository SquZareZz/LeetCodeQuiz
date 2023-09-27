using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class CanPlaceFlowers
    {
        public bool CanPlaceFlowers1(int[] flowerbed, int n)
        {
            int Len = flowerbed.Length;
            bool LeftFlower = flowerbed[0] == 1, MidFlower, RightFlower;
            for (int i = 0; i < Len; i++)
            {
                MidFlower = flowerbed[i] == 1;
                if (MidFlower != true)
                {
                    RightFlower = i + 1 < Len ? flowerbed[i + 1] == 1 : MidFlower;
                    if (!LeftFlower && !RightFlower)
                    {
                        n--;
                        LeftFlower = true;
                        flowerbed[i] = 1;
                    }
                    else
                    {
                        LeftFlower = flowerbed[i] == 1;
                    }
                }
                else
                {
                    LeftFlower = true;
                }
            }
            return n <= 0;
        }
        public bool CanPlaceFlowers2(int[] flowerbed, int n)
        {
            int Len = flowerbed.Length;
            bool LeftFlower = flowerbed[0] == 1, MidFlower;
            for (int i = 0; i < Len; i++)
            {
                MidFlower = flowerbed[i] == 1;
                if (!MidFlower)
                {
                    if (!LeftFlower && !(i + 1 < Len ? flowerbed[i + 1] == 1 : MidFlower))
                    {
                        n--;
                        LeftFlower = true;
                        flowerbed[i] = 1;
                    }
                    else
                    {
                        LeftFlower = flowerbed[i] == 1;
                    }
                }
                else
                {
                    LeftFlower = true;
                }
            }
            return n <= 0;
        }
        public bool CanPlaceFlowers3(int[] flowerbed, int n)
        {
            int Len = flowerbed.Length;

            switch (Len)
            {
                case 0:
                    return false;
                case 1:
                    n = flowerbed[0] == 0 ? n - 1 : n;
                    return n <= 0;
                case 2:
                    n = flowerbed[0] != 1 && flowerbed[1] != 1 ? n - 1 : n;
                    return n <= 0;
                default:
                    int Count = 0;
                    int i = 0;
                    foreach (var Land in flowerbed)
                    {
                        Count = Land == 0 ? Count + 1 : 0;
                        if (Count > 2 || Count > 1 && i == Len - 1 || Count > 1 && i - 1 == 0)
                        {
                            n--;
                            Count = 1;
                        }
                        i++;
                    }
                    return n <= 0;
            }
            //string Flower = string.Join("", flowerbed);
        }
    }
}
