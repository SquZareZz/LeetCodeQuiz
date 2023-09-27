using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class NextPermutation
    {
        public void NextPermutationFail(int[] nums)
        {
            bool TurnFirst = false;
            int[] Maxima = nums.OrderByDescending(x => x).ToArray();
            int Len = nums.Length - 1;
            if (nums.SequenceEqual(Maxima))
            {
                for (int i = 0; i < Len + 1; i++)
                {
                    nums[i] = Maxima[Len - i];
                }
            }
            else
            {
                for (int i = Len; i > 1; i--)
                {
                    if (nums[Len] > nums[i - 1])
                    {
                        int Left = nums[Len], Right = nums[i - 1];
                        nums[i - 1] = Left;
                        nums[Len] = Right;
                        TurnFirst = true;
                        break;
                    }
                }
                if (!TurnFirst)
                {
                    int[] Temp = nums.Where((val, idx) => idx != 0).ToArray();
                    int LeftNum = Temp.Min(), Right = nums[0];
                    for (int i = 1; i < Len; i++)
                    {
                        nums[i + 1] = nums[i];
                    }
                    nums[0] = LeftNum;
                    nums[1] = Right;
                }
            }
        }
        public void NextPermutation1(int[] nums)
        {
            int Len = nums.Length, i = Len - 2, j = Len - 1;
            while (i >= 0 && nums[i] >= nums[i + 1])//先確定左邊是不是最小的數字
            {
                i--;
            }
            if (i >= 0)//如果左邊有最小值的話，接著找右邊第一個比最小值大的值，找到後對調
            {
                while (nums[j] <= nums[i])
                {
                    j--;
                }
                int Left = nums[j], Right = nums[i];
                nums[i] = Left;
                nums[j] = Right;
            }
            int[] Temp = nums.ToArray();
            if (i < 0)//都找不到，整個反轉
            {
                for (int k = 0; k < Len; k++)
                {
                    nums[k] = Temp[Len - 1 - k];
                }
            }
            else //接著把反轉點的兩段數列對調
            {
                for (int k = i + 1; k < Len; k++)
                {
                    nums[k] = Temp[Len - (k - i)];
                }
            }
        }
    }
}
