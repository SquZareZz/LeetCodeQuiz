using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class RotateFunction
    {
        public int MaxRotateFunctionFail(int[] nums)
        {
            //太慢
            var Result = new List<int>();
            int Times = nums.Length;
            for (int i = 0; i < Times; i++)
            {
                int Total = 0;
                for (int j = 0; j < Times; j++)
                {
                    int Target = j - i < 0 ? Times + (j - i) : j - i;
                    Total += nums[Target] * j;
                }
                Result.Add(Total);
            }
            return Result.Max();
        }
        public int MaxRotateFunction(int[] nums)
        {
            //假設有四個數A、B、C、D
            //首先統計四個數總和0A 1B 2C 3D
            //第一個組合完成，接著依序加上4A、4B、4C......
            //並且依序減掉 1*ABCD、2*ABCD、3*......
            //這樣數字組合就會依序變成：
            //3A 0B 1C 2D ↓
            //2A 3B 0C 1D ↓
            //1A 2B 3C 0D ↓
            int Len = nums.Length, First = 0, Offset = 0, Sup = 0;
            for(int i = 0; i < Len; i++)
            {
                First += i * nums[i];
                Offset += nums[i];
            }
            int Max = First;
            for (int i = 0; i < Len - 1; i++)
            {
                Sup += Len * nums[i];
                int F = First - Offset * (i + 1) + Sup;
                Max = Max > F ? Max : F;
            }
            return Max;
        }
        public int MaxRotateFunction2(int[] nums)
        {
            int Len = nums.Length, First = 0, Offset = nums.Sum(), Sup = 0;
            for (int i = 0; i < Len; i++)
            {
                First += i * nums[i];
            }
            int Max = First;
            for (int i = 0; i < Len - 1; i++)
            {
                Sup += Len * nums[i];
                int F = First - Offset * (i + 1) + Sup;
                Max = Max > F ? Max : F;
            }
            return Max;
        }
    }
}
