using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class MoveZeroes
    {
        public void MoveZeroesFail(int[] nums)
        {
            //LeetCode不給賦值
            int[] temp = new int[nums.Length];
            Array.Sort(nums);
            nums = nums.Where(val => val != 0).ToArray();
            for (int i = 0; i < nums.Length; i++)
            {
                temp[i] = nums[i];
            }
            nums = temp;
        }
        public void MoveZeroesFail2(int[] nums)
        {
            //由原來排序不由小到大
            Array.Sort(nums);
            int j = 0;
            int Start = Array.LastIndexOf(nums, 0);
            int TarLen = nums.Length;
            for (int i = Start + 1; i < TarLen; i++)
            {
                nums[j] = nums[i];
                j++;
            }
            for (int i = TarLen - (Start + 1); i < TarLen; i++)
            {
                nums[i] = 0;
            }
        }
        public void MoveZeroes1(int[] nums)
        {
            if (Array.IndexOf(nums, 0) != -1)
            {
                int TarLen = nums.Length;
                int IndexZ = 0;
                int k = 0;
                for (int i = 0; i < TarLen; i++)
                {
                    k = 0;
                    if (nums[i] == 0)
                    {
                        IndexZ = i;
                    }
                    else
                    {
                        for (int j = i; j < TarLen; j++)
                        {
                            if (nums[j] != 0)
                            {
                                nums[k] = nums[j];
                                k++;
                            }
                            else
                            {
                                IndexZ = j;
                            }
                        }
                        for (int a = k; a < TarLen; a++)
                        {
                            nums[a] = 0;
                        }
                        break;
                    }
                }
            }
        }
        public void MoveZeroesFastest(int[] nums)
        {
            int IndexZ = Array.IndexOf(nums, 0);
            if (IndexZ != -1)
            {
                int TarLen = nums.Length;
                int k = IndexZ;
                for (int j = IndexZ + 1; j < TarLen; j++)
                {
                    if (nums[j] != 0)
                    {
                        nums[k] = nums[j];
                        k++;
                    }
                    else
                    {
                        IndexZ = j;
                    }
                }
                for (int a = k; a < TarLen; a++)
                {
                    nums[a] = 0;
                }
            }
        }

    }
}
