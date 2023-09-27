using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class FindFirstAndLastPositionOfElementInSortedArray
    {
        public int[] SearchRangeNoBinary(int[] nums, int target)
        {
            if (nums.Length == 0)
            {
                return new int[2] { -1, -1 };
            }
            int FirstIndex = Array.IndexOf(nums, target), LastIndex = FirstIndex;
            if (FirstIndex == -1)
            {
                return new int[2] { -1, -1 };
            }
            else
            {
                for (int i = FirstIndex + 1; i < nums.Length; i++)
                {
                    if (nums[i] != nums[FirstIndex])
                    {
                        return new int[2] { FirstIndex, LastIndex };
                    }
                    else
                    {
                        LastIndex++;
                    }
                }
            }
            return new int[2] { FirstIndex, LastIndex };
        }
        public int[] SearchRangeByBinary(int[] nums, int target)
        {
            int Len = nums.Length;
            //長度0跟1的解是固定的
            if (Len == 0)
            {
                return new int[2] { -1, -1 };
            }
            else if (Len == 1)
            {
                return nums[0] == target ? new int[2] { 0, 0 } : new int[2] { -1, -1 };
            }

            //其他的解從正中間二元搜尋
            int LeftTemp = -1, RightTemp = -1;

            for (int i = Len / 2; i > -1; i--)
            {
                if (nums[i] == target)
                {
                    LeftTemp = i;
                }
                else if (nums[i] < target)
                {
                    break;
                }
            }

            for (int i = LeftTemp + 1; i < Len; i++)
            {
                if (nums[i] == target)
                {
                    switch (LeftTemp)
                    {
                        case -1:
                            LeftTemp = i;
                            break;
                        default:
                            RightTemp = i;
                            break;
                    }
                }
                else if (nums[i] > target)
                {
                    break;
                }
            }
            if (LeftTemp == -1 && RightTemp > -1)
            {
                return new int[] { RightTemp, RightTemp };
            }
            else if (LeftTemp > -1 && RightTemp == -1)
            {
                return new int[] { LeftTemp, LeftTemp };
            }
            return new int[] { LeftTemp, RightTemp };
        }
    }
}
