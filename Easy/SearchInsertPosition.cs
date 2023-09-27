using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class SearchInsertPosition
    {
        public int SearchInsert(int[] nums, int target)
        {
            int TarLen = nums.Length;
            switch (TarLen)
            {
                case 0:
                    return 1;
                case 1:
                    return target > nums[0] ? 1 : 0;
                default:
                    if (nums[TarLen - 1] < target)
                    {
                        return TarLen;
                    }
                    else if (nums[TarLen - 1] == target)
                    {
                        return TarLen - 1;
                    }
                    else
                    {
                        for (int i = 0; i < TarLen; i++)
                        {
                            if (nums[i] >= target)
                            {
                                return i;
                            }
                        }
                    }
                    break;
            }
            return 0;
        }
        public int SearchInsert2(int[] nums, int target)
        {
            switch (nums.Length)
            {
                case 0:
                    return 1;
                case 1:
                    return target > nums[0] ? 1 : 0;
                default:

                    if (nums[nums.Length - 1] < target)
                    {
                        return nums.Length;
                    }
                    else if (nums[nums.Length - 1] == target)
                    {
                        return nums.Length - 1;
                    }
                    else
                    {
                        for (int i = 0; i < nums.Length; i++)
                        {
                            if (nums[i] >= target)
                            {
                                return i;
                            }
                        }
                    }
                    break;
            }
            return 0;
        }
        public int SearchInsertBestTime(int[] nums, int target)
        {
            int TarLen = nums.Length;
            if (TarLen == 0)
            {
                return 1;
            }
            else
            {
                if (nums[TarLen - 1] < target)
                {
                    return TarLen;
                }
                else
                {
                    for (int i = 0; i < TarLen; i++)
                    {
                        if (nums[i] >= target)
                        {
                            return i;
                        }
                    }
                }
                return 0;
            }
        }//首選
        public int SearchInsertBestMemory(int[] nums, int target)
        {
            switch (nums.Length)
            {
                case 0:
                    return 1;
                default:
                    if (nums[nums.Length - 1] < target)
                    {
                        return nums.Length;
                    }
                    else
                    {
                        for (int i = 0; i < nums.Length; i++)
                        {
                            if (nums[i] >= target)
                            {
                                return i;
                            }
                        }
                    }
                    break;
            }
            return 0;
        }
    }
}
