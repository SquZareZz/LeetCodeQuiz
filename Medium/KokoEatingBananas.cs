using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class KokoEatingBananas
    {
        public int MinEatingSpeed(int[] piles, int h)
        {
            //用二元搜尋法，找出最佳解
            int Left = 1;
            int Result=piles.Max();//最慢的可能性是根據最大堆的香蕉來吃，一次吃一堆
            while(Left < Result)
            {
                int Mid = Left + (Result-Left) / 2;
                int temp = 0;
                foreach(int p in piles)
                {
                    //如果是剛好的話，只算一次
                    //所以多減一個1，如果小於這個數字，因為有加上除數，所以最少會是1
                    temp += (p + Mid - 1) / Mid;
                }
                if (temp > h)
                {
                    Left = Mid+1;
                }
                else
                {
                    Result = Mid;
                }
            }
            return Result;
        }
    }
}
